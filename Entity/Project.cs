using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string SefUrl { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string infrastructure { get; set; }
        public string Keywords { get; set; }
        public int Hit { get; set; }
        public bool Status { get; set; }
    }
}
