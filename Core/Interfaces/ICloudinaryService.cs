using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces
{
   public interface ICloudinaryService
   {
       Task<Photo> UploadPhoto(string id, IFormFile formFile);
   }
}
