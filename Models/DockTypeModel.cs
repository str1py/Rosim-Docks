using RosreestDocks.Interfaces;


namespace RosreestDocks.Models
{
    public class DockTypeModel : ISelectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
