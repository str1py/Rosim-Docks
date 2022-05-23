using RosreestDocks.Models;
using System.Collections.Generic;
using System.IO;

namespace RosreestDocks.Helpers
{
    public static class ExtensionsMethods
    {
        public static string ReplaceInvalidChars(this string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
