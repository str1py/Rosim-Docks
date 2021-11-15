using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RosreestDocks.Contexts;
using RosreestDocks.Helpers;
using RosreestDocks.Models;
using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Aspose.Words;
using System.IO.Compression;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RosreestDocks.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataBaseContext db;
        private readonly DocksService _docks;
        private MainVars MainVars;
        private DictionaryCreator dicCreator;
        public HomeController(ILogger<HomeController> logger, DataBaseContext context, IWebHostEnvironment hostingEnvironment, DocksService docks)
        {
            _logger = logger;
            db = context;
            _docks = docks;
            MainVars = new(db);
            _hostingEnvironment = hostingEnvironment;
            dicCreator = new(db);

        }

        public IActionResult Index()
        {
            return View();
        }



        #region RASPORVYA
        public IActionResult RasporVya()
        {
            var raspor = MainVars.CreateFullModel();

            return View(raspor);
        }
   

        public IActionResult CreateDocuments(RasporVyaModel raspor)
        {
            var dic = dicCreator.CreateRasporVyaDictionary(raspor);

            string pathToRaspor = _hostingEnvironment.WebRootPath + "\\Patterns\\RasporVya.docx";
            string pathToAnex = "";
            string pathToSoprovod = _hostingEnvironment.WebRootPath + "\\Patterns\\Soprovod.docx";

            if (raspor.WhatAnnex == 0)
                pathToAnex = _hostingEnvironment.WebRootPath + "\\Patterns\\AnnexAvto.docx";
            else if (raspor.WhatAnnex == 1)
                pathToAnex = _hostingEnvironment.WebRootPath + "\\Patterns\\AnnexNeAvto.docx";
            else pathToAnex = _hostingEnvironment.WebRootPath + "\\Patterns\\AnnexNeDvizhka.docx";

            Document raspordoc = new(pathToRaspor.Trim());
            Document annexdoc = new(pathToAnex.Trim());
            Document soprovoddoc = new(pathToSoprovod.Trim());

            foreach (var a in dic)
            {
                raspordoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
                annexdoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
                soprovoddoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
            }

            var path = _hostingEnvironment.WebRootPath + "\\Docks\\" + raspor.DocName.Trim() + "\\";



            if (Directory.Exists(path))
                Directory.Delete(path,true);

            Directory.CreateDirectory(path + raspor.DocName);

            raspordoc.Save(path + "1 Распоряжение Вя"+".docx");
            annexdoc.Save(path + "2 Приложение.docx");
            soprovoddoc.Save(path + "3 Сопровод.docx");

            try { ZipFile.CreateFromDirectory(path, path + raspor.DocName + ".zip"); }catch{ }

         
            return DownloadFile(path + raspor.DocName + ".zip", raspor.DocName + ".zip");

        }
      

        [HttpPost]
        public JsonResult JsonAgencyList([FromBody] int id)
        {
            var jsonlist = db.Agency.Where(x => x.Acronym.Id == id).ToSelectListItem();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var js = JsonSerializer.Serialize(jsonlist, options);
            return new JsonResult(new { List = js });
        }
        #endregion


        public IActionResult ZaprosCentral()
        {
            ZaprosCA zapros = new();
            var list = db.Acronyms.ToSelectListItem(null);
            zapros.TransferAgencyAcromymList = list;
            zapros.RecipientAgencyAcromymList = list;
            zapros.ManageRightsList = db.ManageRights.ToSelectListItem(null);
            zapros.TypeOfPropertyList = db.TypeOfPropertyModels.ToSelectListItem(null);
            zapros.SideList = MainVars.sideListZapros.ToSelectListItem(null);
            var agencies = db.Agency;
            zapros.TransferAgencyList = agencies.
                                        Include(ag =>ag.Director).
                                        Include(ag => ag.SecondDirector).
                                        ToSelectListItem(null);
            zapros.RecipientAgencyList = agencies.
                                        Include(ag => ag.Director).
                                        Include(ag => ag.SecondDirector).
                                        ToSelectListItem(null);
            zapros.RecipientAgencyNormalList = agencies.ToList();
            zapros.TransferAgencyNormalList = agencies.ToList();
            zapros.HowMuchObjects = MainVars.objCount.ToSelectListItem(null);

            return View(zapros);
        }
        public IActionResult CreateZaprosCA(ZaprosCA zapros)
        {
            var list = _docks.CreateZaprosCA(zapros);
            return DownloadFile(list[0], list[1]);
        }



        public IActionResult DownloadFile(string link, string name)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = name;
            return File(content, contentType, fileName);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
