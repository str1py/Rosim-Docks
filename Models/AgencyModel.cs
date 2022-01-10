using Microsoft.AspNetCore.Mvc.Rendering;
using RosreestDocks.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RosreestDocks.Models
{
    public class AgencyModel :ISelectable
    {
        public int Id { get; set; }
        [Display(Name = "Акроним")]
        public AgencyAcronymModel Acronym { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Короткое название")]
        public string ShortName { get; set; }
        [Display(Name = "Дополнительно")]
        public string AddInfo { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Город и индекс")]
        public string CityAndZip { get; set; }
        [Display(Name = "ИНН")]
        public string AgencyINN { get; set; }


        public bool Regulation { get; set; }
        public string RegulationName { get; set; }

        public DirectorModel Director { get; set; }

        public DirectorModel SecondDirector { get; set; }

        public string AgencyStatus { get; set; }

        public User LastEditor { get; set; }
        public DateTime EditTime { get; set; }

        [NotMapped]
        public string AppealNumber { get; set; }
        [NotMapped]
        public string AppealDate { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> AcronymList { get; set; }
        [NotMapped]
        [Display(Name = "Акроним")]
        public int AcronymSelected { get; set; }

        [Display(Name = "Название в Им.пад")]
        public string NameImPad { get; set; }
        [Display(Name = "Название в Твор.пад")]
        public string NameTvorPad { get; set; }
        [Display(Name = "Название в Род.пад")]
        public string NameRodPad { get; set; }
        [Display(Name = "Название в Дат.пад")]
        public string NameDatPad { get; set; }

    }
}
