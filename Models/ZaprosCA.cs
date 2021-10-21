using Microsoft.AspNetCore.Mvc.Rendering;
using RosreestDocks.Interfaces;
using RosreestDocks.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace RosreestDocks.Models
{
    public class ZaprosCA: ICommonModel
    {

        public AgencyModel TransferAgency { get; set; }
        public bool TransferAgencyCustomName { get; set; }

        public AgencyModel RecipientAgency { get; set; }
        public bool RecipientAgencyCustomName { get; set; }

        public string PropertyDiscription { get; set; }

        public string AdditionalInfo { get; set; }

        public TypeOfPropertyModel TypeOfProperty { get; set; }
        public ManageRightsModel ManageRightsFrom { get; set; }
        public ManageRightsModel ManageRightsTo { get; set; }

        public int HowMuch { get; set; }
        public int WhoApplied { get; set; }


        [NotMapped]
        public AppealModel TransferAppeal { get; set; }

        [NotMapped]
        public AppealModel RecipientAppeal { get; set; }

        [NotMapped]
        public ArticlesModel Articles { get; set; }

        [NotMapped]
        public WhoAppliedModel WhoAppliedAgency { get; set; }
        [NotMapped]
        public WhoAgreeModel WhoAgreeModelAgency { get; set; }



        [NotMapped]
        public IEnumerable<SelectListItem> HowMuchObjects { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SideList { get; set; }
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
