using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Dtos
{
    public class PhotoForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Caption { get; set; }
        public DateTime UploadedAt { get; set; }
        public string PublicId { get; set; }

        public PhotoForCreationDto()
        {
            UploadedAt = DateTime.Now;
        }
    }
}