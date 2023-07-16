using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace Application.Constants
{
    public class FileToUploadDto
    {
        public int CollectionId { get; set; }
        public IFormFile File { get; set; }
    }
}