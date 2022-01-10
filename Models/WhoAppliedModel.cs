using System.ComponentModel.DataAnnotations.Schema;


namespace RosreestDocks.Models
{
    public class WhoAppliedModel
    {
        public string AcronymTvorPad { get; set; }
        public string AcronymRodPad{ get; set; }
        public string AddInfo { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string NameImPad { get; set; }
        [NotMapped]
        public string NameTvorPad { get; set; }
        [NotMapped]
        public string NameRodPad { get; set; }
        [NotMapped]
        public string NameDatPad { get; set; }
        public string Date { get; set; }
        public string Number { get; set; }
 
    }
}
