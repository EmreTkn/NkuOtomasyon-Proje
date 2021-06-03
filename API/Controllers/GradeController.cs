using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.ResponseDto;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification.GradeSpecs;
using Core.Specification.SemesterSpecs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GradeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public GradeController(IUnitOfWork unitOfWork, IStudentService studentService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet("get-grades")]
        public async Task<ActionResult<IReadOnlyList<SemesterGradeCardDto>>> GetCurrentSemesterGrade()
        {
            var information = await _studentService.GetStudentInformation(HttpContext.User);

            if (information == null) return BadRequest(new ApiResponse(400, "Lütfen giriş yaparak tekrar deneyiniz."));

            var spec = new CurrentSemesterGradeSpecification(information.Semester.Id);

            var grades =
                (await _unitOfWork.Repository<Grade>().ListAsync(spec)).Select(_mapper.Map<SemesterGradeCardDto>).ToList();

            return Ok(grades);
        }

  
        [HttpGet("get-grades-by-id")]
        public async Task<ActionResult<IReadOnlyList<SemesterGradeCardDto>>> GetSemesterGradeById(int semesterId)
        {
            var spec = new CurrentSemesterGradeSpecification(semesterId);
            return Ok((await _unitOfWork.Repository<Grade>().ListAsync(spec))
                .Select(_mapper.Map<SemesterGradeCardDto>).ToList());
        }

        [Authorize]
        [HttpGet("get-semesters")]
        public async Task<ActionResult<IReadOnlyList<SemesterDto>>> GetStudentSemesters()
        {
            var information = await _studentService.GetStudentInformation(HttpContext.User);
            var spec = new StudentSemestersSpecification(information.Semester.Id);

            return (await _unitOfWork.Repository<Semester>().ListAsync(spec))
                .Select(_mapper.Map<SemesterDto>).ToList();
        }
    }
}
