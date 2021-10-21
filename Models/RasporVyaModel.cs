using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace RosreestDocks.Models
{
    public class RasporVyaModel
    {
        public int Id { get; set; }
        public string DocName { get; set; }
        public DateTime DocDate { get; set; }
        public int WorkNumber { get; set; }
        public string SendNumber { get; set; }
        public DockStatusModel Status { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DockStatusList { get; set; }
        public string PropertyDiscription { get; set; }


        [NotMapped]
        public bool TransferAgencyCustomName { get; set; }
        public AgencyAcronymModel TransferAgencyAcromym { get; set; }
        public AgencyModel TransferAgency { get; set; }

        public string TransferAppealNumber { get; set; }

        public string TransferAppealDate { get; set; }


        [NotMapped]
        public bool RecipientAgencyCustomName { get; set; }
        public AgencyAcronymModel RecipientAgencyAcromym { get; set; }
        public AgencyModel RecipientAgency { get; set; }


        public FoivModel FirstFoiv { get; set; }


        public FoivModel SecondFoiv { get; set; }


        public string Articles { get; set; }

        public bool IsRosim { get; set; }
        public string RosimDate { get; set; }
        public string RosimNumber { get; set; }


        public bool BuildingsString { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpireDate { get; set; }


        public TypeOfPropertyModel TypeOfProperty { get; set; } 
        public ManageRightsModel ManageRightsFrom { get; set; } 
        public ManageRightsModel ManageRightsTo { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> FirstFoivList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SecondFoivList { get; set; }

        [NotMapped]
        public WhoAppliedModel WhoAppliedAgency { get; set; }
        [NotMapped]
        public WhoAgreeModel WhoAgreeModelAgency { get; set; }

        [NotMapped]
        public int WhoApplied { get; set; }
        [NotMapped]
        public int WhatAnnex { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> SideList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> AnnexList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ArticlesList { get; set; } 
        [NotMapped]
        public IEnumerable<SelectListItem> TransferAgencyAcromymList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RecipientAgencyAcromymList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> TransferAgencyList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RecipientAgencyList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ManageRightsList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> TypeOfPropertyList { get; set; }


        [NotMapped]
        public List<AgencyModel> RecipientAgencyNormalList { get; set; }
        [NotMapped]
        public List<AgencyModel> TransferAgencyNormalList { get; set; }
    }
}
