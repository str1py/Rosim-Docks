using RosreestDocks.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace RosreestDocks.Models
{
    public class FoivModel : ISelectable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FoivRodPad { get; set; }
        public string FoivTvorPad { get; set; }
        public string FoivDatPad { get; set; }

        public User LastEditor { get; set; }
        public DateTime EditTime { get; set; }
        [NotMapped]
        public string Date { get; set; }
        [NotMapped]
        public string Number { get; set; }
    }
}
