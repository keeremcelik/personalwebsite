using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CatId { get; set; }
        public string Title { get; set; }
        public string SefUrl { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public string CoverImage { get; set; }
        public DateTime Date { get; set; }
        public int Hit { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

    }
}
