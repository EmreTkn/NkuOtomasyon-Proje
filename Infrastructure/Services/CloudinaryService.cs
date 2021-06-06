using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Entities;
using Core.Entities.Configuration;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;


namespace Infrastructure.Services
{
   public class CloudinaryService : ICloudinaryService
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private  Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            Account account=new Account(_cloudinaryConfig.Value.CloudName,_cloudinaryConfig.Value.ApiKey,_cloudinaryConfig.Value.ApiSecret);
            _cloudinary=new Cloudinary(account);
        }
        public async Task<Photo> UploadPhoto(string studentId, IFormFile formFile)
        {
            try
            {
                var file = formFile;
                ImageUploadResult uploadResult;
                await using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }

                var photo = new Photo
                {
                    PublicId = uploadResult.PublicId, Url = uploadResult.Url.ToString(), StudentId = studentId
                };

                return photo;
            }
            catch
            {
                return null;
            }
        }
    }
}
