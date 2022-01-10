using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosreestDocks.Models
{
    public class User : IdentityUser
    {
        [BindProperty]
        [NotMapped]
        [Display(Name = "Role")]
        public IEnumerable<SelectListItem> Role { get; set; }

        [BindProperty]
        [NotMapped]
        [Display(Name = "Role")]
        [Required(ErrorMessage = "Не выбрана роль")]
        public string RoleName { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime MemberSince { get; set; }

    }
}
