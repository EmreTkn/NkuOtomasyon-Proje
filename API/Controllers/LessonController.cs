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

    }
}
