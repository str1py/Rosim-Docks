using RosreestDocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosreestDocks.Models
{
    public class TypeOfPropertyModel : ISelectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PropertyRodPad { get; set; }

    }
}
