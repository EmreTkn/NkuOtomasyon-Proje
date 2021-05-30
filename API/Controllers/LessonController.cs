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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LessonController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private UserManager<User> _userManager;


        public LessonController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("add")]
        public async Task<ApiResponse> InsertNewLessonAsync(API.Dtos.RequestDto.LessonDto lesson)
        {
            return new ApiResponse(200);
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
                var educationSpec = new StudentEducationInformationSpecification(user.Id);
                var educationInformation = await _unitOfWork.Repository<StudentInformation>().GetWithSpec(educationSpec);
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
            
            if(user == null) return BadRequest(new ApiResponse(400, "Giriş yaparak tekrar deneyiniz."));

            var educationSpec = new StudentEducationInformationSpecification(user.Id);
            var educationInformation = await _unitOfWork.Repository<StudentInformation>().GetWithSpec(educationSpec);

            var lessonsSpec = new SyllabusSpecification(user.Id, educationInformation.Semester.Id);
            var lessons = (await _unitOfWork.Repository<StudyLesson>().ListAsync(lessonsSpec))
                .Select(sl => sl.Lesson)
                .Select(_mapper.Map<LessonDateDto>).ToList();

            return Ok(lessons);
        }
    }
}
