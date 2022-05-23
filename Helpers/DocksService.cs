using Aspose.Words;
using Microsoft.AspNetCore.Hosting;
using RosreestDocks.Contexts;
using RosreestDocks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using RosreestDocks.Helpers;

namespace RosreestDocks.Helpers
{
    public class DocksService
    {
        private DictionaryCreator dicCreator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly DataBaseContext db;

        public DocksService(DataBaseContext context, IWebHostEnvironment hostingEnvironment)
        {
            db = context;
            _hostingEnvironment = hostingEnvironment;
            dicCreator = new(db);
        }

        public List<string> CreateZaprosCA(ZaprosCA zapros)
        {
            var dic = dicCreator.CrateZaprosDictionary(zapros);

            string pathToZapros = _hostingEnvironment.WebRootPath + "\\Patterns\\ZaprosCentral.docx";

            Document raspordoc = new(pathToZapros.Trim());


            foreach (var a in dic)
            {
                raspordoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
            }

            string zaporsname = "Запрос в ЦА " + new Random().Next(0, 100);
            var path = _hostingEnvironment.WebRootPath + "\\Docks\\" + zaporsname + "\\";


            if (Directory.Exists(path))
                Directory.Delete(path, true);

            Directory.CreateDirectory(path + zaporsname);

            raspordoc.Save(path + zaporsname + ".docx");

            try { ZipFile.CreateFromDirectory(path, path + zaporsname + ".zip"); } catch { }

            var list = new List<string>();
            list.Add(path + zaporsname + ".zip");
            list.Add(zaporsname + ".zip");

            return list;

        }

        public List<string> CreateZaprosCA(RequestModel request)
        {
            var dic = dicCreator.CreateZapros(request);
            string pathToZapros = _hostingEnvironment.WebRootPath + "\\Patterns\\ZaprosCentral.docx";

            Document raspordoc = new(pathToZapros.Trim());


            foreach (var a in dic)           
                raspordoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
            

            string zaporsname = $"{request.DocName} - Запрос в ЦА ";
            var path = _hostingEnvironment.WebRootPath + "\\Docks\\" + zaporsname + "\\";


            if (Directory.Exists(path))
                Directory.Delete(path, true);

            Directory.CreateDirectory(path + zaporsname);

            raspordoc.Save(path + zaporsname + ".docx");

            try { ZipFile.CreateFromDirectory(path, path + zaporsname + ".zip"); } catch { }

            var list = new List<string>();
            list.Add(path + zaporsname + ".zip");
            list.Add(zaporsname + ".zip");

            return list;
        }

        public List<string> CreateAppealDocks(RequestModel request)
        {
            var dic = dicCreator.CreateRasporVyaByRequest(request);

            string pathToRaspor = _hostingEnvironment.WebRootPath + "\\Patterns\\RasporVya.docx";
            string pathToAnex = "";
            string pathToSoprovod = _hostingEnvironment.WebRootPath + "\\Patterns\\Soprovod.docx";

            if (request.WhatAnnex == 0)
                pathToAnex = _hostingEnvironment.WebRootPath + "\\Patterns\\AnnexAvto.docx";
            else if (request.WhatAnnex == 1)
                pathToAnex = _hostingEnvironment.WebRootPath + "\\Patterns\\AnnexNeAvto.docx";
            else pathToAnex = _hostingEnvironment.WebRootPath + "\\Patterns\\AnnexNeDvizhka.docx";


            if(request.WhatAnnex == 0 || request.WhatAnnex == 1)
                pathToRaspor = _hostingEnvironment.WebRootPath + "\\Patterns\\RasporVya.docx";
            else
                pathToRaspor = _hostingEnvironment.WebRootPath + "\\Patterns\\RasporVyaNeDvizhka.docx";

            Document raspordoc = new(pathToRaspor.Trim());
            Document annexdoc = new(pathToAnex.Trim());
            Document soprovoddoc = new(pathToSoprovod.Trim());

            foreach (var a in dic)
            {
                raspordoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
                annexdoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
                soprovoddoc.Range.Replace(a.Key, a.Value?.Trim() ?? "");
            }

            var path = _hostingEnvironment.WebRootPath + "\\Docks\\" + request.DocName.Trim() + "\\";



            if (Directory.Exists(path))
                Directory.Delete(path, true);

            Directory.CreateDirectory(path + request.DocName);

            raspordoc.Save(path + $"{request.DocName} - Распоряжение Вя" + ".docx");
            annexdoc.Save(path + $"{request.DocName} - Приложение.docx");
            soprovoddoc.Save(path + $"{request.DocName} - Сопровод.docx");

            try { ZipFile.CreateFromDirectory(path, path + request.DocName + ".zip"); } catch { }

            var list = new List<string>();
            list.Add(path + request.DocName + ".zip");
            list.Add(request.DocName + ".zip");

            return list;
        }

        public List<string> CreateAppealRunner(RequestModel request)
        {
            string pathToRunner = "";
            var path = _hostingEnvironment.WebRootPath + "\\Docks\\" + request.DocName.Trim() + "\\";

            if (request.WhatAnnex == 0)
                pathToRunner = _hostingEnvironment.WebRootPath + "\\Patterns\\RunnerAvto.docx";
            else if (request.WhatAnnex == 1)
                pathToRunner = _hostingEnvironment.WebRootPath + "\\Patterns\\RunnerDvizhka.docx"; 
            else pathToRunner = _hostingEnvironment.WebRootPath + "\\Patterns\\RunnerNedvizhka.docx";

            var dic = dicCreator.CreateRunner(request);
            Document runner = new(pathToRunner.Trim());

            foreach (var a in dic)          
                runner.Range.Replace(a.Key, a.Value?.Trim() ?? "");


            if (Directory.Exists(path))
                Directory.Delete(path, true);

            Directory.CreateDirectory(path + request.DocName);
            runner.Save(path + $"{request.DocName} бегунок" + ".docx");

            try { ZipFile.CreateFromDirectory(path, path + request.DocName + ".zip"); } catch { }

            var list = new List<string>();
            list.Add(path + request.DocName + ".zip");
            list.Add(request.DocName + ".zip");

            return list;
        }

        public List<string> CreateDeny(RequestModel request)
        {
            string pathToDeny = "";

            var path = _hostingEnvironment.WebRootPath + "\\Docks\\" + request.DocName.Trim() + "\\";

            pathToDeny = _hostingEnvironment.WebRootPath + "\\Patterns\\DeniedTemplate.docx";

            var dic = dicCreator.CreateDeny(request);
            Document runner = new(pathToDeny.Trim());

            foreach (var a in dic)
                runner.Range.Replace(a.Key, a.Value?.Trim() ?? "");


            if (Directory.Exists(path))
                Directory.Delete(path, true);

            Directory.CreateDirectory(path + request.DocName);

            var first = request.TransferAgency.ShortName ?? request.TransferAgency.Name;


            runner.Save(path + $"{request.DocName} - письмо {first.ReplaceInvalidChars()}" + ".docx");

            try { ZipFile.CreateFromDirectory(path, path + request.DocName + ".zip"); } catch { }

            var list = new List<string>();
            list.Add(path + request.DocName + ".zip");
            list.Add(request.DocName + ".zip");

            return list;
        }


    }
}
