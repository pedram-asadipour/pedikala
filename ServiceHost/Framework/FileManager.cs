using System;
using System.IO;
using _01_Framework.Application;
using _01_Framework.Tools;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ServiceHost.Framework
{
    public class FileManager : IFileManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Uploader(IFormFile file, string path)
        {
            if (file == null) return null;

            var directory = $"{_webHostEnvironment.WebRootPath}\\Uploads\\{path}";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fileName = $"{NumberGenerate.Random()}-{DateTools.FullDate(DateTime.Now)}{Path.GetExtension(file.FileName)}";

            var directoryFile = $"{directory}\\{fileName}";

            using var output = File.Create(directoryFile);
            file.CopyTo(output);

            return $"{path}/{fileName}";
        }

        public void Remove(string path)
        {
            path = $"{_webHostEnvironment.WebRootPath}\\Uploads\\{path}";

            if (string.IsNullOrWhiteSpace(path))
                return;

            if(!File.Exists(path))
                return;
            
            File.Delete(path);
        }
    }
}