using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.ResponseDto;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specification.LessonSpecs;
using Core.Specification.StudentSpecs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LessonController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private IStudentService _studentService;


        public LessonController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _studentService = studentService;
        }

        [HttpGet("get-lesson-params")]
        public async Task<AddLessonDto> GetAllParamsForAddLessonAsync()
        {
            var lessonParams = new AddLessonDto
            {
                ClassRooms = (await _unitOfWork.Repository<Classroom>().ListAllAsync())
                    .Select(_mapper.Map<ClassRoomDto>).ToList(),
                Programs = (await _unitOfWork.Repository<StudyProgram>().ListAllAsync())
                    .Select(_mapper.Map<StudyProgramDto>).ToList(),
                Semesters = (await _unitOfWork.Repository<Semester>().ListAllAsync())
                    .Select(_mapper.Map<SemesterDto>).ToList(),
                Teachers = (await _unitOfWork.Repository<Teacher>().ListAllAsync())
                    .Select(_mapper.Map<TeacherDto>).ToList()
            };

            return lessonParams;
        }

        [HttpGet("get-grade-cards")]
        public async Task<ActionResult<IReadOnlyList<GradeCardDto>>> GetGradeCardsAsync()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            if (user != null)
            {
                var spec = new StudentGradesSpecification(user.Id);

                return Ok(
                    (await _unitOfWork.Repository<Grade>().ListAsync(spec))
                    .Select(_mapper.Map<GradeCardDto>)
                    .ToList()
                    );
            }

            return BadRequest(new ApiResponse(400, "Kullanıcı bulunamadı."));
        }

        [HttpGet("get-curriculum-card")]
        public async Task<ActionResult<IReadOnlyList<CurriculumGradeCardDto>>> GetCurriculumCardAsync()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            
            if (user != null)
            {
                List<CurriculumGradeCardDto> result = new List<CurriculumGradeCardDto>();

                var educationInformation = await _studentService.GetStudentInformation(HttpContext.User);
                var semesterSpec = new LessonsBySemesterIdSpecification(educationInformation.Semester.Id);
                

                var studentGradesSpec = new StudentGradesSpecification(user.Id);
                var studentGrades =
                    (await _unitOfWork.Repository<Grade>().ListAsync(studentGradesSpec)).Select(
                        _mapper.Map<CurriculumGradeCardDto>).ToList();
                result.AddRange(studentGrades);

                var semesterLessons = await _unitOfWork.Repository<Lesson>().ListAsync(semesterSpec);
                foreach (var item in semesterLessons)
                {
                    var data = studentGrades.FirstOrDefault(x => x.LessonCode == item.LessonCode);
                    if (data == null)
                    {
                       result.Add(_mapper.Map<CurriculumGradeCardDto>(item)); 
                    }

                }
                return result;
            }

            return BadRequest(new ApiResponse(400, "Giriş yaparak tekrar deneyiniz."));
        }

        [HttpGet("get-lessons-dates")]
        public async Task<ActionResult<IReadOnlyList<LessonDateDto>>> GetLessonDatesAsync()
        { 
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            
            if(user == null) return BadRequest(new ApiResponse(400, "Lütfen giriş yaparak tekrar deneyiniz."));

            var educationInformation = await _studentService.GetStudentInformation(HttpContext.User);

            var lessonsSpec = new SyllabusSpecification(user.Id, educationInformation.Semester.Id);
            var lessons = (await _unitOfWork.Repository<StudyLesson>().ListAsync(lessonsSpec))
                .Select(sl => sl.Lesson)
                .Select(_mapper.Map<LessonDateDto>).ToList();

            return Ok(lessons);
        }

        [HttpGet("get-mid-exam")]
        public async Task<ActionResult<IReadOnlyList<MidExamDto>>> GetMidExamDateAsync()
        {
            var educationInformation = await _studentService.GetStudentInformation(HttpContext.User);

            if (educationInformation == null) return BadRequest(new ApiResponse(400, "Lütfen giriş yaparak tekrar deneyiniz."));

            var lessonsSpec = new StudentLessonsSpecification(educationInformation.StudentId, educationInformation.Semester.Id);

            var lessons = (await _unitOfWork.Repository<StudyLesson>().ListAsync(lessonsSpec))
                .Select(sl => sl.Lesson)
                .Select(_mapper.Map<MidExamDto>).ToList();

            return Ok(lessons);
        }

        [HttpGet("get-final-exam")]
        public async Task<ActionResult<IReadOnlyList<MidExamDto>>> GetFinalExamDateAsync()
        {
            var educationInformation = await _studentService.GetStudentInformation(HttpContext.User);

            if (educationInformation == null) return BadRequest(new ApiResponse(400, "Lütfen giriş yaparak tekrar deneyiniz."));

            var lessonsSpec = new StudentLessonsSpecification(educationInformation.StudentId, educationInformation.Semester.Id);

            var lessons = (await _unitOfWork.Repository<StudyLesson>().ListAsync(lessonsSpec))
                .Select(sl => sl.Lesson)
                .Select(_mapper.Map<FinalExamDto>).ToList();

            return Ok(lessons);
        }

        [HttpGet("get-semester-lesson")]
        public async Task<ActionResult<IReadOnlyList<LessonToAdd>>> GetLessonsBySemester()
        {
            var educationInformation = await _studentService.GetStudentInformation(HttpContext.User); //refaktor yapılacak.
            if (educationInformation == null) return BadRequest(new ApiResponse(400, "Lütfen giriş yaparak tekrar deneyiniz."));

            var semesterLessonSpec = new CurrentSemesterLessonsSpecification(educationInformation.Semester.Id);
            var semesterLessons =
                (await _unitOfWork.Repository<Lesson>().ListAsync(semesterLessonSpec))
                .Select(_mapper.Map<LessonToAdd>).ToList();

            if (educationInformation.Semester.Id - 2 > 0)
            {
                var failedLessonsSpec = new FailedLessonsSpecification(educationInformation.Semester.Id - 2);
                var failedLessons = (await _unitOfWork.Repository<Grade>().ListAsync(failedLessonsSpec))
                    .Select(src => src.Lesson)
                    .Select(_mapper.Map<LessonToAdd>)
                    .Select(_mapper.Map<LessonToAdd>).ToList(); //son mapper tekrar ders olduğunu belirtmek için Repetition true döndürüyor.

                semesterLessons.AddRange(failedLessons);
            }

            return semesterLessons;
        }
    }
}
