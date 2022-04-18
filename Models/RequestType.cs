using RosreestDocks.Interfaces;

namespace RosreestDocks.Models
{
    public class RequestType : ISelectable
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
