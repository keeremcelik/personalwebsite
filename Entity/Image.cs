using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class Image
    {
        public int ImageId{ get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
        public bool IsCoverImage{ get; set; }
        public int Type{ get; set; }
        public bool Status { get; set; }
    }
}
