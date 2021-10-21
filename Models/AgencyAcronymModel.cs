using RosreestDocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosreestDocks.Models
{
    public class AgencyAcronymModel : ISelectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AcronymImPad { get; set; }
        public string AcronymRodPad { get; set; }
        public string AcronymTvorPad { get; set; }
        public string AcronymDatPad { get; set; }
    }
}
