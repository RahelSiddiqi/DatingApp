using System;

namespace DatingApp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public DateTime UploadedAt { get; set; }
        public bool IsMain { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}