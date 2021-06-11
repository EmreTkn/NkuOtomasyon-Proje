using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.RequestDto;
using API.Dtos.ResponseDto;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specification.GradeSpecs;
using Core.Specification.TeacherSpecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TeacherController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinary;
        private readonly IStudentService _studentService;

        public TeacherController(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinary, IStudentService studentService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinary = cloudinary;
            _studentService = studentService;
        }

        [HttpGet("get-lessons")]
        public async Task<IReadOnlyList<Dtos.LessonDto>> GetLessonsByTeacher()
        {
            var teacher = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var spec = new LessonsByTeacherIdAndSemester(teacher.Id);

            return (await _unitOfWork.Repository<Lesson>().ListAsync(spec))
                .Select(_mapper.Map<Dtos.LessonDto>).ToList();
        }

        [HttpGet("get-student-by-lesson")]
        public async Task<IReadOnlyList<StudentBasicDto>> GetStudentsByLesson(string lessonCode)
        {
            var spec = new StudentsByLessonSpecification(lessonCode);

            var students = (await _unitOfWork.Repository<StudyLesson>().ListAsync(spec))
                .Select(src => src.Student)
                .Select(_mapper.Map<StudentBasicDto>)
                .ToList();
            return students;
        }
        [HttpGet("get-lessons-by-semester")]
        public async Task<IReadOnlyList<Dtos.LessonDto>> GetLessonsByTeacher(int semesterId)
        {
            var teacher = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var spec = new LessonsByTeacherIdAndSemester(teacher.Id, semesterId);

            return (await _unitOfWork.Repository<Lesson>().ListAsync(spec))
                .Select(_mapper.Map<Dtos.LessonDto>).ToList();
        }

        [HttpPost("upload-pdf")]
        public async Task<ActionResult<ApiResponse>> UploadPdfAsync([FromForm] IFormFile fileToCome, string lessonCode, string name)
        {
           var pdf = await _cloudinary.UploadPdf(lessonCode, name, fileToCome);
           if (pdf != null)
           {
               _unitOfWork.Repository<PdfFile>().Add(pdf);
               await _unitOfWork.Complete();
               return Ok(new ApiResponse(200, $"{pdf.Url}"));
           }
           return new BadRequestObjectResult(new ApiResponse(500));
        }

        [HttpPost("update-grade")]
        public async Task<ActionResult<ApiResponse>> UpdateGradesByStudent(GradesUpdateDto model)
        {
            if (model != null)
            {
                var student = await _studentService.GetStudentByNumber(model.StudentNumber);

                var spec = new CurrentSemesterGradeSpecification(student.Information.Semester.Id, student.Id,
                    model.LessonCode);
                var grade = await _unitOfWork.Repository<Grade>().GetWithSpec(spec);

                if (grade != null)
                {
                    if (model.FinalExam != null) grade.FinalExam = model.FinalExam;
                    if (model.MidTerm != null) grade.MidTerm = model.MidTerm;
                    if (model.MakeUpExam != null) grade.MakeUpExam = model.MakeUpExam;
                    grade.FailedAbsenteeism = model.FailedAbsenteeism;
                    grade.FailedLowGrade = model.FailedLowGrade;
                    _unitOfWork.Repository<Grade>().Update(grade);
                    await _unitOfWork.Complete();
                    return Ok(new ApiResponse(200, "Not başarı ile güncellendi."));
                }
                return BadRequest(new ApiResponse(404, "istenen not bulunamadı."));
            }
            return BadRequest(new ApiResponse(500, "Bilgileri kontrol ederek tekrar deneyiniz."));
        }
    }
}
