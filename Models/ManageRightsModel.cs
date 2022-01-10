using RosreestDocks.Interfaces;

namespace RosreestDocks.Models
{
    public class ManageRightsModel : ISelectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RightsRodPad { get; set; }
    }
}
