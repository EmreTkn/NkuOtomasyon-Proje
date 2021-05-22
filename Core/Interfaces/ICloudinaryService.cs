using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces
{
   public interface ICloudinaryService
   {
       Photo UploadPhoto(string id, IFormFile formFile);
   }
}
