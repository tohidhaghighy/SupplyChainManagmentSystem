using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Schm.Api.Infrastructure.Common
{
    public static class UploadImage
    {
        public static async Task<string> Upload(IFormFile file)
        {
            string ImageSrc = "";
            if (file != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(file.FileName);
                string fileName = Guid.NewGuid() + fileInfo.Extension;
                ImageSrc = "/image/" + fileName;
                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return ImageSrc;
        }
    }
}
