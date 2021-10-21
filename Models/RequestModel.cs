using Microsoft.AspNetCore.Mvc.Rendering;
using RosreestDocks.Interfaces;
using RosreestDocks.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RosreestDocks.Models
{
    public class RequestModel :ICommonModel
    {
        public int Id { get; set; }
        public string DocName { get; set; }
        public DateTime DocDate { get; set; }
        public int WorkNumber { get; set; }
        public string SoprovodNumber { get; set; }
        public string SendNumber { get; set; }
        public DockStatusModel Status { get; set; }
        public DockTypeModel DockType { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DockStatusList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DockTypeList { get; set; }

        public string PropertyDiscription { get; set; }



        public AgencyModel TransferAgency { get; set; }
        public AppealModel TransferAppeal { get; set; }


        public AgencyModel RecipientAgency { get; set; }
        public AppealModel RecipientAppeal { get; set; }


        public FoivModel FirstFoiv { get; set; }
        public AppealModel FirstFoivAppeal { get; set; }


        public FoivModel SecondFoiv { get; set; }
        public AppealModel SecondFoivAppeal { get; set; }


        public ArticlesModel Articles { get; set; }


        public bool IsRosim { get; set; }
        public AppealModel RosimAppeal { get; set; }


        public bool BuildingsString { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpireDate { get; set; }


        public TypeOfPropertyModel TypeOfProperty { get; set; }
        public ManageRightsModel ManageRightsFrom { get; set; }
        public ManageRightsModel ManageRightsTo { get; set; }


        public int WhoApplied { get; set; }

        public int WhatAnnex { get; set; }

        public string AddInfo { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> FirstFoivList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SecondFoivList { get; set; }

        [NotMapped]
        public WhoAppliedModel WhoAppliedAgency { get; set; }
        [NotMapped]
        public WhoAgreeModel WhoAgreeModelAgency { get; set; }


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
        [NotMapped]
        public List<FoivModel> FoivNormalList { get; set; }
    }

}
