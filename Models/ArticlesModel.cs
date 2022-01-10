using RosreestDocks.Interfaces;


namespace RosreestDocks.Models
{
    public class SelectModel : ISelectable
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
