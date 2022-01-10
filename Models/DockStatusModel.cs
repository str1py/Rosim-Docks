using RosreestDocks.Interfaces;

namespace RosreestDocks.Models
{
    public class DockStatusModel : ISelectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
