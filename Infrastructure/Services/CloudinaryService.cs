using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
   public class CloudinaryService : ICloudinaryService
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IUnitOfWork _unitOfWork;
        private  Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> cloudinaryConfig,IUnitOfWork unitOfWork)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _unitOfWork = unitOfWork;
            Account account=new Account(_cloudinaryConfig.Value.CloudName,_cloudinaryConfig.Value.ApiKey,_cloudinaryConfig.Value.ApiSecret); //Daha öncesinde bir nesneye atanan veriler ile cloudinary account bilgileri oluşturuluyor.
            _cloudinary=new Cloudinary(account);
        }
        public  Photo UploadPhoto(string studentId, IFormFile formFile) //fotoğraf cloud'a yükleniyor.
        {
            var file = formFile;
            var uploadResult = new ImageUploadResult();
            using (var stream=file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.Name, stream)
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }
            var photo = new Photo();
            photo.PublicId = uploadResult.PublicId;
            photo.Url = uploadResult.Url.ToString();
            photo.StudentId = studentId; 
            _unitOfWork.Repository<Photo>().Add(photo); //Veriler eklendikten sonra daha önceden resim olup olmadığı kontrol edilecek.
            return photo;

        }
    }
}
