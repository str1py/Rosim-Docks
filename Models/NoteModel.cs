using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosreestDocks.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public ImportanceState Importance { get; set; }
        public User Creator { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ImportanceList { get; set; }
    }
}
