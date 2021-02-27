using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public interface IFileService
    {
        string Add(IFormFile file);
        void Delete(string path);
        string Update(string sourcePath, IFormFile file);
        string newPath(IFormFile file);
    }
}
