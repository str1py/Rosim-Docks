using Microsoft.EntityFrameworkCore;
using RosreestDocks.Contexts;
using RosreestDocks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RosreestDocks.Helpers
{
    public class MainVars
    {

        public List<AnnexModel> anexlist = new();
        public List<SelectModel> sideList = new();

        private readonly DataBaseContext db;

        public MainVars(DataBaseContext context)
        {
            db = context;
            anexlist.Add(new AnnexModel { Id = 0, Name = "Движимое (Авто)" });
            anexlist.Add(new AnnexModel { Id = 1, Name = "Движимое (Не Авто)" });
            anexlist.Add(new AnnexModel { Id = 2, Name = "Недвижимое" });

            sideList.Add(new SelectModel { Id = 0, Name ="Передающая сторона"});
            sideList.Add(new SelectModel { Id = 1, Name = "Принимющая сторона" });
        }


        public RequestModel CreateFullRquestModel()
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
            return consider;
        }

        public Tuple<MemoryStream, string, string> GetDownloadFileData(string link, string name = null)
        {
            try
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(link);
                MemoryStream content = new MemoryStream(data);

                var fileName = "";
                var contentType = "";

                if (name == null)
                    fileName = Path.GetFileName(link);
                else
                    fileName = name;
                
                contentType = System.Net.Mime.MediaTypeNames.Application.Octet;

                return Tuple.Create(content, contentType, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }


    }
}
