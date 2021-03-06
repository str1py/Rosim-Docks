using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosreestDocks.Models
{
    public class DirectorModel
    {
        [Key]
        public int Id { get; set; }
        public Position Position { get; set; }
        public string Name { get; set; }
        public string AddInfo { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> PositionList { get; set; }
        [NotMapped]
        public int PositionSelected { get; set; }
    }
}
