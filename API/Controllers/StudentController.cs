using System.Threading.Tasks;
using API.Dtos.ResponseDto;
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
    public class StudentController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-information")]
        public async Task<EducationInformationDto> GetStudentEducationInformation()
        {
            var user =await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var spec = new StudentEducationInformationSpecification(user.Id);

            var result = await _unitOfWork.Repository<StudentInformation>().GetWithSpec(spec);

            return _mapper.Map<EducationInformationDto>(result);
        }

        [HttpGet("get-personal-information")]
        public async Task<PersonalInformationDto> GetStudentPersonalInformation()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            var spec = new StudentPersonalInformationSpecification(user.Id);

            var result = await _unitOfWork.Repository<StudentPersonalityInformation>().GetWithSpec(spec);

            return _mapper.Map<PersonalInformationDto>(result);
        }
    }
}
