using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RosreestDocks.Interfaces
{
    public interface ISelectable
    {
        string Name { get; }
        int Id { get; }
    }
}
