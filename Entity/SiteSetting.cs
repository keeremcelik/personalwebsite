using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class SiteSetting
    {
        [Key]
        public int SSId { get; set; }
        public string SiteName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string GoogleID { get; set; }
        public string GoogleCode { get; set; }
        public string GoogleMap { get; set; }
        public bool Status { get; set; }
    }
}
