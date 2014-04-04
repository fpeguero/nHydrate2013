
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
namespace nHydrate.Dsl.Editor
{
	public sealed class ImageLibrary
	{
		private static Dictionary<int, Image> uoLUvUIQl = new Dictionary<int, Image>();
		private static Icon IQvUQuivvl;
        //public static Icon CodeFluentIcon
        //{
        //    get
        //    {
        //        if (ImageLibrary.IQvUQuivvl == null)
        //        {
        //          //var strings =  Handler.Register<bool>("Superman!!");

        //            ImageLibrary.IQvUQuivvl = new Icon(typeof(ImagesList).Assembly.GetManifestResourceStream(Handler.GetValue<string>(3087, Assembly.GetExecutingAssembly())));
        //        }
        //        return ImageLibrary.IQvUQuivvl;
        //    }
        //}
		public static ImageList Images
		{
			get
			{
				return ImagesList.OvilILoOv;
			}
		}
		private ImageLibrary()
		{
		}
	
		public static Image GetImage32(ImageLibraryIndex index)
		{
			Image thumbnailImage;
			if (ImageLibrary.uoLUvUIQl.TryGetValue((int)index, out thumbnailImage))
			{
				return thumbnailImage;
			}
			Image image = ImageLibrary.GetImage(index);
			thumbnailImage = image.GetThumbnailImage(32, 32, null, IntPtr.Zero);
			ImageLibrary.uoLUvUIQl.Add((int)index, thumbnailImage);
			return thumbnailImage;
		}
		public static Image GetImage(ImageLibraryIndex index)
		{
			return ImageLibrary.Images.Images[(int)index];

            
		}


        public static void WriteImageToDisk()
        {


            foreach (ImageLibraryIndex imageLibraryIndex in (ImageLibraryIndex[])Enum.GetValues(typeof(ImageLibraryIndex)))
            {
                Image image = GetImage(imageLibraryIndex);

                image.Save("c:\\images\\" + Enum.GetName(typeof(ImageLibraryIndex), imageLibraryIndex) + ".png");
            }
         
        }


	}
}
