using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
  
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,ITokenService tokenService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user==null)
            {
                return Unauthorized(new ApiResponse(401, "Böyle bir kullanıcı bulunamadı."));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
         

            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401, "Şifrenizi kontrol ederek tekrar deneyin."));
            }

         
            return new UserDto
            {
                Email = user.Email,
                SchoolNumber = user.UserName,
                Type=user.Type,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterStudent(RegisterDto registerDto)
        {
            if (CheckEmailExistAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse{Errors = new []{"Email adresi kullanılıyor."}});
            }

            var user = new User()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.SchoolNumber,
                Type = registerDto.Type
            };

            var result =await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400, "Ekleme işlemi sırasında bir hata oluştu."));
            }

            if (user.Type == Types.Student) // Type gönder type göre ekleme yapsın. if else aradan çıkar.
            {
                _unitOfWork.Repository<Student>().Add(_mapper.Map<User,Student>(user));
            }
            else if (user.Type == Types.Teacher)
            {
                _unitOfWork.Repository<Teacher>().Add(_mapper.Map<User,Teacher>(user));
            }else if (user.Type == Types.StudentAffairs)
            {
                _unitOfWork.Repository<StudentAffairs>().Add(_mapper.Map<User,StudentAffairs>(user));
            }

            await _unitOfWork.Complete();

            return new UserDto
            {  
                Email = user.Email,
                SchoolNumber = user.UserName,
                Type = user.Type,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser() 

        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            return new UserDto
            {
                Email = user.Email,
                SchoolNumber = user.UserName,
                Type = user.Type,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}
