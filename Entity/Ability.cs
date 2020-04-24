using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entity
{
    public class Ability
    {
        public int AbilityId{ get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public bool Status { get; set; }
    }
}
