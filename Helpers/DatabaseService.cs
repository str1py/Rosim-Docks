using Microsoft.EntityFrameworkCore;
using RosreestDocks.Contexts;
using RosreestDocks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RosreestDocks.Helpers
{
    public class DatabaseService
    {
        public List<AnnexModel> anexlist = new();
        public List<SelectModel> sideList = new();

        private readonly DataBaseContext db;
        public DatabaseService(DataBaseContext context)
        {
            db = context;
            anexlist.Add(new AnnexModel { Id = 0, Name = "Движимое (Авто)" });
            anexlist.Add(new AnnexModel { Id = 1, Name = "Движимое (Не Авто)" });
            anexlist.Add(new AnnexModel { Id = 2, Name = "Недвижимое" });

            sideList.Add(new SelectModel { Id = 0, Name = "Передающая сторона" });
            sideList.Add(new SelectModel { Id = 1, Name = "Принимющая сторона" });
        }
        public RequestModel CreateFullRequestModel()
        {
            var consider = new RequestModel();
            var list = db.Acronyms.ToSelectListItem(null);
            consider.TransferAgencyAcromymList = list;
            consider.RecipientAgencyAcromymList = list;
            consider.ArticlesList = db.Articles.ToSelectListItem(null);
            consider.ManageRightsList = db.ManageRights.ToSelectListItem(null);
            consider.TypeOfPropertyList = db.TypeOfPropertyModels.ToSelectListItem(null);
            consider.AnnexList = anexlist.ToSelectListItem(null);
            consider.SideList = sideList.ToSelectListItem(null);
            var foivs = db.Foiv.ToSelectListItem(null);
            consider.FirstFoivList = foivs;
            consider.SecondFoivList = foivs;
            var agencies = db.Agency.
                  Include(ag => ag.Director).Include(ag => ag.Director.Position).
                  Include(ag => ag.SecondDirector).Include(ag => ag.SecondDirector.Position);
            consider.TransferAgencyList = agencies.ToSelectListItem(null);
            consider.RecipientAgencyList = agencies.ToSelectListItem(null);
            consider.RecipientAgencyNormalList = agencies.ToList();
            consider.TransferAgencyNormalList = agencies.ToList();
            consider.FoivNormalList = db.Foiv.ToList();
            consider.DockStatusList = db.DocStatus.ToSelectListItem(null);
            consider.DockTypeList = db.DocType.ToSelectListItem(null);
            consider.ReqTypeList = db.RequestType.ToSelectListItem(null);
            return consider;
        }
        public RequestModel GetFullRequest(int id, bool creator = false)
        {
            RequestModel consider = new RequestModel();
            //if true = get creator info 
            if (creator)
            {
                consider = db.Request.Include(inc => inc.CreateUser).Include(inc => inc.Status).Include(acr => acr.DockType)
                    .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym)
                    .Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                    .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym)
                    .Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                    .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                    .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                    .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                    .Include(acr => acr.FirstFoivAppeal).Include(acr => acr.SecondFoivAppeal)
                    .Include(acr => acr.RecipientAppeal).Include(acr => acr.TransferAppeal)
                    .Include(acr => acr.RosimAppeal)
                    .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).ToList().Where(x => x.Id == id).SingleOrDefault();
            }
            else
            {
                consider = db.Request.Include(inc => inc.Status).Include(acr => acr.DockType)
                    .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym)
                    .Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                    .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym)
                    .Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                    .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                    .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                    .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                    .Include(acr => acr.FirstFoivAppeal).Include(acr => acr.SecondFoivAppeal)
                    .Include(acr => acr.RecipientAppeal).Include(acr => acr.TransferAppeal)
                    .Include(acr => acr.RosimAppeal)
                    .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).ToList().Where(x => x.Id == id).SingleOrDefault();
            }

            if (consider != null)
            {
                var list = db.Acronyms.ToSelectListItem(null).OrderBy(x => x.Text);
                consider.TransferAgencyAcromymList = list;
                consider.RecipientAgencyAcromymList = list;
                consider.DockStatusList = db.DocStatus.ToSelectListItem(null);
                consider.ArticlesList = db.Articles.ToSelectListItem(null);
                consider.ManageRightsList = db.ManageRights.ToSelectListItem(null);
                consider.TypeOfPropertyList = db.TypeOfPropertyModels.ToSelectListItem(null);
                consider.AnnexList = anexlist.ToSelectListItem(null);
                consider.SideList = sideList.ToSelectListItem(null);
                var foivs = db.Foiv.ToSelectListItem(null);
                consider.FirstFoivList = foivs;
                consider.SecondFoivList = foivs;
                var agencies = db.Agency.
                      Include(ag => ag.Director).Include(ag => ag.Director.Position).
                      Include(ag => ag.SecondDirector).Include(ag => ag.SecondDirector.Position);
                consider.TransferAgencyList = agencies.ToSelectListItem(null);
                consider.RecipientAgencyList = agencies.ToSelectListItem(null);
                consider.RecipientAgencyNormalList = agencies.ToList();
                consider.TransferAgencyNormalList = agencies.ToList();
                consider.FoivNormalList = db.Foiv.ToList();
                consider.DockTypeList = db.DocType.ToSelectListItem(null);

                consider.RecipientAgency.AcronymSelected = consider.RecipientAgency.Acronym.Id;
                consider.TransferAgency.AcronymSelected = consider.TransferAgency.Acronym.Id;

                consider.ReqTypeList = db.RequestType.ToSelectListItem(null);
                return consider;
            }
            else
            {
                return null;
            }

        }



    }
}
