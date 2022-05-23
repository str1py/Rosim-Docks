using Microsoft.AspNetCore.Hosting;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Dadata.Model;

namespace RosreestDocks.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class DataController : Controller
    {
        private readonly ILogger<DataController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataBaseContext db;
        private readonly DocksService _docks;
        private readonly FileService _files;
        private readonly UserManager<User> _userManager;
        private readonly EgrulService _egrul;
        private readonly DatabaseService _dbservice;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string DockPath;
        private readonly string DockPathAlt;
        public DataController(ILogger<DataController> logger, DataBaseContext context, IWebHostEnvironment hostingEnvironment, DatabaseService dbservice,
            DocksService docks, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, FileService files, EgrulService egrul)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            db = context;
            _dbservice = dbservice;
            _hostingEnvironment = hostingEnvironment;

            _docks = docks;
            _files = files;
            _egrul = egrul;
            DockPath = Path.Combine(_hostingEnvironment.WebRootPath, "Documents\\");
            DockPathAlt = "\\Documents\\";
        }

        #region Appeals 
        //SHOW ALL APPEALS BY ALL EMPLOYEES
        public IActionResult AllAppeals()
        {
            var appeal = db.Request.Include(inc => inc.Status).Include(inc => inc.CreateUser).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).ToList();
            return View(appeal);
        }

        //SHOW ALL APPEALS BY ALL CURRENT EMPLOYEE
        public async Task<IActionResult> Appeals()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var appeal = db.Request.Include(inc=>inc.CreateUser).Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom)
                .Include(acr => acr.ManageRightsTo).Where(x => x.CreateUser.Id == user.Id).ToList();
            return View(appeal);
        }
        public async Task<IActionResult> AppealsLetters()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var appeal = db.Request.Where(x=>x.DockType.Id == 2).Where(x=>x.Status.Id != 5).Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).Where(x => x.CreateUser.Id == user.Id).ToList();
            return View(appeal);
        }
        public async Task<IActionResult> AppealsCentral()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var appeal = db.Request.Where(x => x.DockType.Id == 3).Where(x => x.Status.Id != 5).Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).Where(x => x.CreateUser.Id == user.Id).ToList();
            return View(appeal);
        }
        public async Task<IActionResult> AppealsRaspor()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var appeal = db.Request.Where(x => x.DockType.Id == 4 || x.DockType.Id == 5).Where(x => x.Status.Id != 5).Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).Where(x => x.CreateUser.Id == user.Id).ToList();
            return View(appeal);
        }
        public async Task<IActionResult> AppealsClosed()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var appeal = db.Request.Where(x => x.Status.Id == 5).Include(inc => inc.Status).Include(acr => acr.DockType)
                .Include(acr => acr.RecipientAgency).Include(acr => acr.RecipientAgency.Acronym).Include(acr => acr.RecipientAgency.Director).Include(acr => acr.RecipientAgency.SecondDirector)
                .Include(acr => acr.TransferAgency).Include(acr => acr.TransferAgency.Acronym).Include(acr => acr.TransferAgency.Director).Include(acr => acr.TransferAgency.SecondDirector)
                .Include(acr => acr.RecipientAgency.Director.Position).Include(acr => acr.RecipientAgency.SecondDirector.Position)
                .Include(acr => acr.TransferAgency.Director.Position).Include(acr => acr.TransferAgency.SecondDirector.Position)
                .Include(acr => acr.FirstFoiv).Include(acr => acr.SecondFoiv)
                .Include(acr => acr.TypeOfProperty).Include(acr => acr.ManageRightsFrom).Include(acr => acr.ManageRightsTo).Where(x => x.CreateUser.Id == user.Id).ToList();
            return View(appeal);
        }

        //GET DATA FOR EXIST APPEAL CONSIDER == REFACTORED
        public IActionResult EditAppealConsider(int id)
        {
            RequestModel consider = _dbservice.GetFullRequest(id);

            if (consider == null)
            {
                _logger.LogError("LogError {0}", "Request return null (EditAppealConsider)");
                return BadRequest();
            }
            else
                return View(consider);
        }

        //IF APPEAL DOEST EXIST TO CURRENT USER CREATE VIEW WITHOUT EDIT == REFACTORED
        public IActionResult ViewAppealConsider(int id)
        {
            RequestModel consider = _dbservice.GetFullRequest(id, true);

            if (consider == null)
            {
                _logger.LogError("LogError {0}", "Request return null (EditAppealConsider)");
                return BadRequest();
            }
            else
                return View(consider);
        }

        //GET DATA FOR NEW APPEAL CONSIDER  ==  REFACTORED
        public IActionResult AppealConsider()
        {
            return View(_dbservice.CreateFullRequestModel());
        }

        //FOR NEW APPEALS AND SAVE
        public async Task<IActionResult> AppealConsiderSave(RequestModel rasporVyaModel)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);


            var a = rasporVyaModel;

            if (a.CreationDate == DateTime.MinValue)
                a.CreationDate = DateTime.Now;


            a.UpdateDate = DateTime.Now;

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
            a.CreateUser = db.AppUser.Where(x => x.Id == user.Id).SingleOrDefault();
            a.ReqType = db.RequestType.Where(x=>x.Id == rasporVyaModel.ReqType.Id).SingleOrDefault();


            if (rasporVyaModel.Id == 0)
                db.Request.Add(a);
            else
                db.Request.Update(a);



            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        
        //NOT TESTED YET
        public async Task<IActionResult> RemoveAppeals(int id)
        {
            var consider = db.Request.Where(x=>x.Id == id)
                .Include(x=>x.RecipientAppeal).Include(x => x.TransferAppeal).Include(x => x.FirstFoivAppeal)
                .Include(x => x.SecondFoivAppeal).Include(x => x.RosimAppeal).SingleOrDefault();

            db.Remove(db.Appeals.Where(x => x.Id == consider.RecipientAppeal.Id).SingleOrDefault());
            db.Remove(db.Appeals.Where(x => x.Id == consider.TransferAppeal.Id).SingleOrDefault());
            db.Remove(db.Appeals.Where(x => x.Id == consider.FirstFoivAppeal.Id).SingleOrDefault());
            db.Remove(db.Appeals.Where(x => x.Id == consider.SecondFoivAppeal.Id).SingleOrDefault());
            db.Remove(db.Appeals.Where(x => x.Id == consider.RosimAppeal.Id).SingleOrDefault());
            db.Remove(consider);

            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult CreateAppealConsider(RequestModel request)
        {
            var consider = _docks.CreateAppealDocks(request);
            return _files.DownloadFile(consider[0], consider[1]);
        }
        public IActionResult CreateAppealRunner(RequestModel request)
        {
            var consider = _docks.CreateAppealRunner(request);
            return _files.DownloadFile(consider[0], consider[1]);
        }
        public IActionResult CreateZaprosCentral(RequestModel request)
        {
            var consider = _docks.CreateZaprosCA(request);
            return _files.DownloadFile(consider[0], consider[1]);
        }
        public IActionResult CreateDeny(RequestModel request)
        {
            var consider = _docks.CreateDeny(request);
            return _files.DownloadFile(consider[0], consider[1]);
        }
        #endregion

        #region Acronyms
        public IActionResult Acronyms()
        {
            return View(db.Acronyms.ToList());           
        }

        public async Task<IActionResult> EditAcronyms(AgencyAcronymModel acronym)
        {
            acronym.EditTime = DateTime.Now;
            acronym.LastEditor = await _userManager.GetUserAsync(User);
            db.Update(acronym);
            await db.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<ActionResult> ShowUpdateAcronymsModal(string id)
        {
            var item = await db.Acronyms.Include(x=> x.LastEditor).Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();

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
            foiv.EditTime = DateTime.Now;
            foiv.LastEditor = await _userManager.GetUserAsync(User);
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
            res.EditTime = DateTime.Now;
            res.LastEditor = await _userManager.GetUserAsync(User);
            res = foiv;
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<ActionResult> ShowUpdateFoivModal(string id)
        {
            var item = await db.Foiv.Include(x => x.LastEditor).Where(x => x.Id == Int32.Parse(id)).FirstOrDefaultAsync();
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
            agency.LastEditor = await _userManager.GetUserAsync(User);
            agency.EditTime = DateTime.Now;
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
            agency.EditTime = DateTime.Now;
            agency.LastEditor = await _userManager.GetUserAsync(User);
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
                .Include(x => x.LastEditor)
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
            agency.AcronymList = db.Acronyms.ToSelectListItem(null).OrderBy(x => x.Text);
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

 

        #endregion

        #region DocCategory
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
                await _files.UploadFile(file, DockPath);
                doc.Url = DockPathAlt + file.FileName;
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
                await _files.UploadFile(file, DockPath);
                doc.Url = DockPathAlt + file.FileName;
            }
            db.Documents.Update(doc);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var doc = await db.Documents.Where(x => x.Id == id).SingleOrDefaultAsync();
            return  _files.DownloadFile(_hostingEnvironment.WebRootPath + doc.Url);
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


        public void DeleteDocumentsAsync(DocumentModel prod)
        { 
            //DELETE FOLDER AND FILES
            string curernt = Directory.GetCurrentDirectory();
            if (Directory.Exists(curernt + DockPath))
            {
            
                DirectoryInfo dirInfo = new DirectoryInfo(curernt + DockPath);
                foreach (FileInfo f in dirInfo.GetFiles())
                {
                    if (f.Name == Path.GetFileName(prod.Url))
                        f.Delete();
                }
            }
        }

        #region Notes
        public async Task<IActionResult> CreateNote(NoteModel note)
        {
            note.Importance = db.Importance.Where(x => x.Id == note.Importance.Id).SingleOrDefault();
            note.Creator = await _userManager.GetUserAsync(User);
            db.Notes.Add(note);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveNote(int noteid)
        {

            var b =await db.Notes.Where(x => x.Id == noteid).SingleAsync();
            db.Notes.Remove(b);
            await db.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion


        public async Task<Suggestion<Party>> ShowAgencyInfo(string inn)
        {
            return await _egrul.GetAgencyInfo(inn);

        }
    }
}
