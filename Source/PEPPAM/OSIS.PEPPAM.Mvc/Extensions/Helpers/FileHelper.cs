using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Ionic.Zip;

namespace OSIS.PEPPAM.Mvc.Extensions.Helpers
{
    public class FileHelper
    {
        public static bool IsImage(byte[] content)
        {
            if (content == null)
                return false;

            string filename = Helpers.ZipUtil.GetFileName(content).ToLowerInvariant();
            return filename.EndsWith(".gif") ||
                    filename.EndsWith(".jpg") ||
                    filename.EndsWith(".jpeg") ||
                    filename.EndsWith(".png");
        }

        public static string GetMimeType(string filename)
        {
            string mimeType = "application/octet-stream";

            string extension = System.IO.Path.GetExtension(filename).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    mimeType = "image/jpeg";
                    break;
                case ".gif":
                    mimeType = "image/gif";
                    break;
                case ".png":
                    mimeType = "image/png";
                    break;
                default:
                    break;
            }

            return mimeType;
        }
    }
}