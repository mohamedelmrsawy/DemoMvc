using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.Services.AttachementService
{
    public class AttachementService : IAttachementService
    {
        List<string> allowedExtension = [".png ", ".jpg" , ".jpeg"];
        const int maxSize = 2_097_152;
        public string Upload(IFormFile file, string FolderName)
        {
            
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtension.Contains(extension)) return null;
         
            if (file.Length == 0 | file.Length > maxSize) return null;

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory() ,"wwwroot\\Files" , FolderName);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(FolderPath, fileName);

            using FileStream fs = new FileStream(filePath , FileMode.Create);

            file.CopyTo(fs);

            return filePath;

        }


        public bool Delete(string filePath)
        {
            if (File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }

    }
}
