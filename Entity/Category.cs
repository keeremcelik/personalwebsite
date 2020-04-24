using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string SefUrl { get; set; }
        public string Keywords{ get; set; }
        public string Descriptions { get; set; }
        public DateTime Date{ get; set; }
        public bool Status { get; set; }
    }
}
