using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Ionic.Zip;

namespace OSIS.PEPPAM.Mvc.Extensions.Helpers
{
    public class ZipUtil
    {
        public static byte[] Unzip(byte[] zipped, out string filename)
        {
            filename = Resources.Shared.UnknownDocument;

            using (var zippedStream = new MemoryStream(zipped))
            {
                using (ZipFile zip = ZipFile.Read(zippedStream))
                {
                    using (var ms = new MemoryStream())
                    {
                        if (zip != null &&
                            zip.EntryFileNames.Count > 0)
                        {
                            filename = zip.EntryFileNames.FirstOrDefault();
                            zip.Entries.FirstOrDefault().Extract(ms);

                            return ms.ToArray();
                        }
                        else
                            throw new FileLoadException(Resources.Shared.ImpossibleLoadFile);
                    }
                }
            }
        }

        public static byte[] Zip(HttpPostedFileBase uploadedFile)
        {
            byte[] result = null;

            if (uploadedFile != null &&
                uploadedFile.FileName.Length != 0)
            {
                using (ZipFile zip = new ZipFile())
                {
                    using (MemoryStream streamDocumento = new MemoryStream())
                    {
                        zip.AddEntry(uploadedFile.FileName, uploadedFile.InputStream);
                        zip.Save(streamDocumento);

                        return streamDocumento.ToArray();
                    }
                }
            }

            return result;
        }

        public static string GetFileName(byte[] zipped)
        {
            string filename = Resources.Shared.UnknownDocument;
            using (var zippedStream = new MemoryStream(zipped))
            {
                using (ZipFile zip = ZipFile.Read(zippedStream))
                {
                    if (zip != null &&
                        zip.EntryFileNames.Count > 0)
                    {
                        filename = zip.EntryFileNames.FirstOrDefault();
                    }
                    else
                        throw new FileLoadException(Resources.Shared.ImpossibleLoadFile);
                }
            }
            return filename;
        }
    }
}