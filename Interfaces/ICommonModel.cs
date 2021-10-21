using RosreestDocks.Models;
using RosreestDocks.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RosreestDocks.Interfaces
{
    interface ICommonModel
    {
        public AgencyModel TransferAgency { get; set; }
        public AppealModel TransferAppeal { get; set; }

        public AgencyModel RecipientAgency { get; set; }
        public AppealModel RecipientAppeal { get; set; }

        [NotMapped]
        public WhoAppliedModel WhoAppliedAgency { get; set; }
        [NotMapped]
        public WhoAgreeModel WhoAgreeModelAgency { get; set; }

        public ArticlesModel Articles { get; set; }

        public int WhoApplied { get; set; }

        public TypeOfPropertyModel TypeOfProperty { get; set; }
        public ManageRightsModel ManageRightsFrom { get; set; }
        public ManageRightsModel ManageRightsTo { get; set; }
    }

}
