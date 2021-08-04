using Microsoft.AspNetCore.Http;

namespace _01_Framework.Application
{
    public interface IFileManager
    {
        string Uploader(IFormFile file, string path);
        void Remove(string path);
    }
}