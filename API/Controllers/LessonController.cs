using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.RequestDto;
using API.Dtos.ResponseDto;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LessonController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;


        public LessonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ApiResponse> InsertNewLessonAsync(LessonDto lesson)
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

    }
}
