using System.Threading.Tasks;
using API.Errors;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specification;
using Core.Specification.UpdateSpecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StudentAffairsController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinary;
       

        public StudentAffairsController(UserManager<User> userManager,IUnitOfWork unitOfWork,ICloudinaryService cloudinary)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _cloudinary = cloudinary;
        }

        [HttpPost("upload-photo")]
        public async Task<ActionResult> UploadPhotoForStudent([FromForm]string studentNumber,[FromForm]IFormFile fileToCome)
        {
            var spec= new StudentWithIncludesSpecification(studentNumber);
            var student = await _unitOfWork.Repository<Student>().GetWithSpec(spec);

            var photoSpec = new StudentPhotoSpecification(student.Id);
            var photo = await _unitOfWork.Repository<Photo>().GetWithSpec(photoSpec);

            if (photo == null)
            {
                return await PhotoRepository(fileToCome, student);
            }
            else
            {
                _unitOfWork.Repository<Photo>().Delete(photo);
                await _unitOfWork.Complete();
                return await PhotoRepository(fileToCome, student);
            }
        }

        private async Task<ActionResult> PhotoRepository(IFormFile fileToCome, Student student)
        {
            var result = await _cloudinary.UploadPhoto(student.Id, fileToCome);
            if (result != null)
            {
                _unitOfWork.Repository<Photo>().Add(result);
                await _unitOfWork.Complete();
                return Ok(new ApiObjectResponse<string>(200, result.Url,"Fotoğraf başarı ile yüklendi."));
            }
            return BadRequest(new ApiResponse(500, "Yükleme işleme sırasında bir hata oluştu."));
        }
    }
}
