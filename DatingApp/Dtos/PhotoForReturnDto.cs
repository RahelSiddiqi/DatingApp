using System;

namespace DatingApp.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public DateTime UploadedAt { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}