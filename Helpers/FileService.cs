using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace RosreestDocks.Helpers
{
    public class FileService
    {
        public async Task<bool> UploadFile(IFormFile ufile, string path)
        {
            if (ufile != null)
            {
                var fileName = Path.GetFileName(ufile.FileName);
                string[] files = Directory.GetFiles(path);

                if (!files.Contains(path + fileName))
                {
                    if (ufile != null && ufile.Length > 0)
                    {
                        var filePath = path + fileName;
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
        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public FileContentResult DownloadFile(string link, string name = null)
        {
            Tuple<byte[], string, string> data;

            if (name == null)
                data = GetDownloadFileData(link);
            else
                data = GetDownloadFileData(link, name);

            return new FileContentResult(data.Item1, data.Item2)
            {
                FileDownloadName = data.Item3
            };

        }

        private Tuple<byte[], string, string> GetDownloadFileData(string link, string name = null)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(link);

                var fileName = "";

                if (name == null)
                    fileName = Path.GetFileName(link);
                else
                    fileName = name;

                return Tuple.Create(fileBytes, GetMimeType(fileName), fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}
