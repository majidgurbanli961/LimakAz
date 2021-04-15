using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Extension
{
    public static class IFormFileExtensions
    {
        public static bool IsImage(this IFormFile formFile)
        {
            return formFile.ContentType.Contains("Project/images/");
        }
        public static bool LessThan(this IFormFile formFile, int mb)
        {
            return formFile.Length / 1024 / 1024 > 2;
        }


        public static string Save(this IFormFile file, string root, string folder)
        {
            string path = Path.Combine(root, "Project");
            string filename = Path.Combine(folder, Guid.NewGuid().ToString() + file.FileName);

            string resultPath = Path.Combine(path, filename);
            using (FileStream stream = new FileStream(resultPath, FileMode.Create))
            {
                file.CopyTo(stream);

            }
            return filename;
        }
    }
}
