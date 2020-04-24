using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class SocialSetting
    {
        [Key]
        public int SocialId { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool Status{ get; set; }
    }
}
