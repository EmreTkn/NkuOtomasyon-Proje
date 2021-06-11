using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.ResponseDto;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specification;
using Core.Specification.StudentSpecs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalInformationDto = API.Dtos.ResponseDto.PersonalInformationDto;

namespace API.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, IStudentService studentService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpGet("get-information")]
        public async Task<ActionResult<EducationInformationDto>> GetStudentEducationInformation()
        {
            var user =await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            if (user == null) return BadRequest(new ApiResponse(400, "Kullanıcı bulunamadı."));


            var spec = new StudentEducationInformationSpecification(user.Id);

            var result = await _unitOfWork
                .Repository<StudentInformation>().GetWithSpec(spec);

            return Ok(_mapper.Map<EducationInformationDto>(result));
        }

        [HttpGet("get-personal-information")]
        public async Task<ActionResult<PersonalInformationDto>> GetStudentPersonalInformation()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            if (user == null) return BadRequest(new ApiResponse(400, "Kullanıcı bulunamadı."));

            var spec = new StudentPersonalInformationSpecification(user.Id);

            var result = await _unitOfWork.
                Repository<StudentPersonalityInformation>().GetWithSpec(spec);

            return Ok(_mapper.Map<PersonalInformationDto>(result));
        }

        [HttpGet("get-lessons")]
        public async Task<ActionResult<IReadOnlyList<Dtos.LessonDto>>> GetLessonsBySemester()
        {
            var information = await _studentService.GetStudentInformation(HttpContext.User);

            var spec = new StudentGradesSpecification(information.StudentId, information.Semester.Id);

            var lessons = (await _unitOfWork.Repository<Grade>().ListAsync(spec))
                .Select(src => src.Lesson)
                .Select(_mapper.Map<Dtos.LessonDto>).ToList();
            if (lessons.Count == 0)
            {
                return BadRequest(new ApiResponse(500, "Döneme ait dersiniz bulunamadı."));
            }
            return lessons;
        }

        [HttpGet("get-pdf")]
        public async Task<ActionResult<IReadOnlyList<Dtos.ResponseDto.PdfDto>>> GetPdfFilesByLesson(string lessonCode)
        {
            var spec = new PdfFilesByLessonsSpecification(lessonCode);
            var pdfFiles = (await _unitOfWork.Repository<PdfFile>().ListAsync(spec))
                .Select(_mapper.Map<Dtos.ResponseDto.PdfDto>)
                .ToList();
            if (pdfFiles.Count == 0)
            {
                return BadRequest(new ApiResponse(404, "Derse ait pdf dosyası bulunamadı."));
            }

            return pdfFiles;
        }

    }
}
