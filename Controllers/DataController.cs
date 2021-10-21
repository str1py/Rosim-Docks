﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RosreestDocks.Contexts;
using RosreestDocks.Helpers;
using RosreestDocks.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dadata;

namespace RosreestDocks.Controllers
{
    public class DataController : Controller
    {
        private readonly ILogger<DataController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataBaseContext db;
        private readonly DocksService _docks;
        MainVars MainVars;
        public DataController(ILogger<DataController> logger, DataBaseContext context, IWebHostEnvironment hostingEnvironment, InfoUpdater iu, DocksService docks)
        {
            _logger = logger;
            db = context;
            _hostingEnvironment = hostingEnvironment;
            MainVars = new(db);
            _docks = docks;
            //_iu = iu;
            //iu.GetData();
        }

        #region Appeals 
        public IActionResult Appeals()
        {
            var appeal = db.Request.Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).ToList();
            return View(appeal);
        }
        public IActionResult EditAppealConsider(int id)
        {
            RequestModel consider = db.Request.Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.FirstFoivAppeal).Include(acr => acr.SecondFoivAppeal).Include(acr => acr.RecipientAppeal).Include(acr => acr.TransferAppeal).Include(acr => acr.RosimAppeal)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).ToList().Where(x=>x.Id == id).SingleOrDefault();


            var list = db.Acronyms.ToSelectListItem(null);
            consider.TransferAgencyAcromymList = list;
            consider.RecipientAgencyAcromymList = list;
            consider.DockStatusList = db.DocStatus.ToSelectListItem(null);
            consider.ArticlesList = db.Articles.ToSelectListItem(null);
            consider.ManageRightsList = db.ManageRights.ToSelectListItem(null);
            consider.TypeOfPropertyList = db.TypeOfPropertyModels.ToSelectListItem(null);
            consider.AnnexList = MainVars.anexlist.ToSelectListItem(null);
            consider.SideList = MainVars.sideList.ToSelectListItem(null);
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

            return View(consider);
        }
        public IActionResult CreateAppealConsider(RequestModel request)
        {
            var consider = _docks.CreateAppealDocks(request);
            return DownloadFile(consider[0], consider[1]);
        }
        public IActionResult CreateAppealRunner(RequestModel request)
        {
            var consider = _docks.CreateAppealRunner(request);
            return DownloadFile(consider[0], consider[1]);
        }
        public IActionResult AppealConsiderSave(RequestModel rasporVyaModel)
        {
            var a = rasporVyaModel;

            a.CreationDate = DateTime.Now;
            a.Articles = db.Articles.Where(x => x.Id == rasporVyaModel.Articles.Id).SingleOrDefault();
            a.FirstFoiv = db.Foiv.Where(x => x.Id == rasporVyaModel.FirstFoiv.Id).SingleOrDefault();
            a.SecondFoiv = db.Foiv.Where(x => x.Id == rasporVyaModel.SecondFoiv.Id).SingleOrDefault();
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == rasporVyaModel.ManageRightsFrom.Id).SingleOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == rasporVyaModel.ManageRightsTo.Id).SingleOrDefault();
            a.RecipientAgency = db.Agency.Where(x => x.Id == rasporVyaModel.RecipientAgency.Id).SingleOrDefault();
            a.TransferAgency = db.Agency.Where(x => x.Id == rasporVyaModel.TransferAgency.Id).SingleOrDefault();
            a.Status = db.DocStatus.Where(x => x.Id == rasporVyaModel.Status.Id).SingleOrDefault();
            a.DockType = db.DocType.Where(x => x.Id == rasporVyaModel.DockType.Id).SingleOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == rasporVyaModel.TypeOfProperty.Id).SingleOrDefault();
            //a.TransferAgency.Acronym = db.Acronyms.Where(x => x.Id == rasporVyaModel.TransferAgency.AcronymSelected).SingleOrDefault();
            //a.RecipientAgency.Acronym = db.Acronyms.Where(x => x.Id == rasporVyaModel.RecipientAgency.AcronymSelected).SingleOrDefault();
            if (rasporVyaModel.Id == 0)
                db.Request.Update(a);
            else
                db.Request.Update(a);

            db.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult CreateZaprosCentral(RequestModel request)
        {
            var consider = _docks.CreateZaprosCA(request);
            return DownloadFile(consider[0], consider[1]);
        }


        public IActionResult CreateDeny(RequestModel request)
        {
            var consider = _docks.CreateDeny(request);
            return DownloadFile(consider[0], consider[1]);
        }
        #endregion


        #region Acronyms
        public IActionResult Acronyms()
        {
            return View(db.Acronyms.ToList());           
        }

        public async Task<IActionResult> EditAcronyms(AgencyAcronymModel acronym)
        {
            db.Update(acronym);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<ActionResult> ShowUpdateAcronymsModal(string id)
        {
            var item = await db.Acronyms.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();

            if (item != null)
            {
                return PartialView("Modal/UpdateAcronymsModal", item);
            }
            else return null;
        }

        public ActionResult ShowCreateAcronymsModal()
        {
            AgencyAcronymModel acronym = new();
            return PartialView("Modal/CreateAcronymsModal", acronym);
        }

        public async Task<IActionResult> CreateAcronyms(AgencyAcronymModel acronym)
        {
            await db.Acronyms.AddAsync(acronym);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAcronyms(string id)
        {
            var res = await db.Acronyms.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            db.Acronyms.Remove(res);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());

        }
        #endregion

        #region FOIVS
        public IActionResult Foivs()
        {

            return View(db.Foiv.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoiv(FoivModel foiv)
        {
            await db.Foiv.AddAsync(foiv);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFoiv(string id)
        {
            var res = await db.Foiv.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            db.Foiv.Remove(res);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());

        }

        [HttpPost]
        public async Task<IActionResult> EditFoiv(FoivModel foiv)
        {
            var res = await  db.Foiv.Where(x => x.Id == foiv.Id).FirstOrDefaultAsync();
            res = foiv;
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<ActionResult> ShowUpdateFoivModal(string id)
        {
            var item = await db.Foiv.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            if (item != null)
                return PartialView("Modal/UpdateFoivModal", item);
            else return null;
        }

        public ActionResult ShowCreateFoivModal()
        {
            return PartialView("Modal/CreateFoivModal");
        }


        #endregion

        #region Agencies
        public IActionResult Organizations()
        {
            return View(db.Agency.Include(acr => acr.Acronym).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrganization(AgencyModel agency)
        {
            agency.Acronym = db.Acronyms.Where(x => x.Id == agency.AcronymSelected).SingleOrDefault();

            agency.Director = GetDirector(agency);
            agency.SecondDirector = GetSecondDirector(agency);
           
            db.Agency.Add(agency);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveOrganization(string id)
        {
            var res = await db.Agency.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            db.Agency.Remove(res);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());

        }

        [HttpPost]
        public async Task<IActionResult> EditOrganization(AgencyModel agency)
        {
            agency.Acronym = db.Acronyms.Where(x => x.Id == agency.AcronymSelected).SingleOrDefault();

            agency.Director.Position= await db.Positions.Where(x=>x.Id == agency.Director.Position.Id).SingleOrDefaultAsync();
            agency.SecondDirector.Position = await db.Positions.Where(x => x.Id == agency.SecondDirector.Position.Id).SingleOrDefaultAsync();

            db.Update(agency);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<ActionResult> ShowUpdateOrganizationModal(string id)
        {
            var pos = db.Positions.ToSelectListItem();
            var item = await db.Agency.Where(x => x.Id == Int32.Parse(id))
                .Include(acr => acr.Acronym)
                .Include(acr => acr.Director)
                .Include(acr => acr.SecondDirector)
                .Include(acr => acr.Director.Position)
                .Include(acr => acr.SecondDirector.Position)
                .AsNoTracking().SingleOrDefaultAsync();

            if (item.Director == null)
            {
                item.Director = new();
                item.Director.PositionList = pos;
            }
            else
            {
                item.Director.PositionList = db.Positions.ToSelectListItem(item.Director.Position.Id);
                item.Director.PositionSelected = item.Director.Position.Id;
            }

            if (item.SecondDirector == null)
            {
                item.SecondDirector = new();
                item.SecondDirector.PositionList = pos;
            }
            else
            {
                item.SecondDirector.PositionList = db.Positions.ToSelectListItem(item.Director.Position.Id);
                item.SecondDirector.PositionSelected = item.Director.Position.Id;
            }


            if (item != null)
            {
                item.AcronymSelected = item.Acronym.Id;
                item.AcronymList = db.Acronyms.ToSelectListItem(item.Acronym.Id);
                
                return PartialView("Modal/UpdateOrganizationModal", item);
            }
            else return null;
        }

        public ActionResult ShowCreateOrganizationModal()
        {
            AgencyModel agency = new();
            agency.Director = new DirectorModel();
            agency.SecondDirector = new DirectorModel();
            agency.Director.PositionList = db.Positions.ToSelectListItem(null);
            agency.SecondDirector.PositionList = db.Positions.ToSelectListItem(null);
            agency.AcronymSelected = 0;
            agency.AcronymList = db.Acronyms.ToSelectListItem();
            return PartialView("Modal/CreateOrganizationModal",agency);
        }

        private DirectorModel GetDirector(AgencyModel agency)
        {           
                agency.Director.Position = db.Positions.Where(x => x.Id == agency.Director.PositionSelected).SingleOrDefault();
                return agency.Director;
        }
        private DirectorModel GetSecondDirector(AgencyModel agency)
        {
            agency.SecondDirector.Position = db.Positions.Where(x => x.Id == agency.SecondDirector.PositionSelected).SingleOrDefault();
            return agency.SecondDirector;
        }

 
        public async Task<ActionResult> UpdateAgencies()
        {
            var list = db.Agency.ToList();

            var token = "12808f894ea95b42fadb5d3589a38dc5664ca572";
            var secret = "f714df62ebbbb6cc4a24c184db525ee130e6b24c";
            var api = new SuggestClientAsync(token);

            foreach (var agency in list)
            {
                if (!String.IsNullOrEmpty(agency.AgencyINN))
                {
                    var response = await api.FindParty(agency.AgencyINN);
                    var b = response;
                }
                else
                {
                    var response = await api.SuggestParty(agency.Name);
                    var b = response;
                }
            }

            //var response = await api.FindParty("7707083893"); //by inn
            //var response = await api.SuggestParty("сбер");  //by name

            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion

        #region DocCategoty
        public IActionResult DocCategories()
        {
            return View(db.DocCategories.ToList());
        }
        public async Task<IActionResult> EditDocCategory(DocCategoryModel doccat)
        {
            db.Update(doccat);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> CreateDocCategory(DocCategoryModel doccat)
        {
            await db.DocCategories.AddAsync(doccat);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveDocCategory(string id)
        {
            var res = await db.DocCategories.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            db.DocCategories.Remove(res);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<ActionResult> ShowUpdateDocCategoryModal(string id)
        {
            var item = await db.DocCategories.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            return PartialView("Modal/UpdateDocCategoryModal", item);
        }

        public ActionResult ShowCreateDocCategoryModal()
        {
            DocCategoryModel doccat = new();
            return PartialView("Modal/CreateDocCategoryModal", doccat);
        }
        #endregion

        #region Documents 
        public IActionResult Documents()
        {
            return View(db.Documents.Include(cat=>cat.Category).ToList());
        }
        public async Task<IActionResult> CreateDocument(DocumentModel doc, IFormFile file)
        {
            doc.LastUpdate = DateTime.Now;
            doc.CategoryList = db.DocCategories.ToSelectListItem();
            doc.Category = await db.DocCategories.Where(x => x.Id == doc.CategorySelected).SingleOrDefaultAsync();
            if (file != null)
            {
                await UploadFile(file, MainVars.DocsPath);
                doc.Url = MainVars.DocsPath + file.FileName;
            }
            await db.Documents.AddAsync(doc);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> EditDocument(DocumentModel doc, IFormFile file)
        {
            doc.LastUpdate = DateTime.Now;
            doc.CategoryList = db.DocCategories.ToSelectListItem();
            if (file != null)
            {
                DeleteDocumentsAsync(doc);
                await UploadFile(file, MainVars.DocsPath);
                doc.Url = MainVars.DocsPath + file.FileName;
            }
            db.Documents.Update(doc);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> RemoveDocument(string id)
        {
            var res = await db.Documents.Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
            db.Documents.Remove(res);
            DeleteDocumentsAsync(res);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());

        }

        public async Task<ActionResult> ShowUpdateDocumentModal(string id)
        {
            
            var item = await db.Documents.Where(x => x.Id == Int32.Parse(id)).Include(cat =>cat.Category).FirstOrDefaultAsync();
            item.CategorySelected = item.Category.Id;
            item.CategoryList = db.DocCategories.ToSelectListItem();
            return PartialView("Modal/UpdateDocumentModal", item);
        }

        public ActionResult ShowCreateDocumentModal()
        {
            DocumentModel doc = new();
            doc.CategoryList = db.DocCategories.ToSelectListItem();
            return PartialView("Modal/CreateDocumentModal", doc);
        }
        #endregion

        public async Task<bool> UploadFile(IFormFile ufile, string path)
        {
            if (ufile != null)
            {
                string current = Directory.GetCurrentDirectory();
                var fileName = Path.GetFileName(ufile.FileName);
                string[] files = Directory.GetFiles(current + path);

                if (!files.Contains(current + path + fileName))
                {
                    if (ufile != null && ufile.Length > 0)
                    {
                        var filePath = current + path + fileName;
                        using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                        {
                            await ufile.CopyToAsync(fileSrteam);
                        }
                        return true;
                    }
                }
                else
                    return false;
            }

            return false;
        }
        public IActionResult DownloadFile(string link, string name)
        {
            //string current = Directory.GetCurrentDirectory();
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = name;
            return File(content, contentType, fileName);
        }
        public void DeleteDocumentsAsync(DocumentModel prod)
        { 
            //DELETE FOLDER AND FILES
            string curernt = Directory.GetCurrentDirectory();
            if (Directory.Exists(curernt + MainVars.DocsPath))
            {
            
                DirectoryInfo dirInfo = new DirectoryInfo(curernt + MainVars.DocsPath);
                foreach (FileInfo f in dirInfo.GetFiles())
                {
                    if (f.Name == Path.GetFileName(prod.Url))
                        f.Delete();
                }
            }
        }
    }
}
