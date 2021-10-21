using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosreestDocks.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public DocCategoryModel Category { get; set; }
        [NotMapped]
        [Display(Name = "Категория")]
        public int CategorySelected { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Url { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Выбирете документ")]
        [Display(Name = "Документ")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
