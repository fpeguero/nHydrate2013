using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

public sealed class ImagesList
{
	private static ImagesList iQioovoUv;
	private ResourceManager resourceManager;
	private static ImageList UoOvOQQUO;
	public static ImageList OvilILoOv
	{
		get
		{
			if (ImagesList.UoOvOQQUO == null)
			{
                ImagesList.UoOvOQQUO = ImagesList.UuUuOQiOol(typeof(ImagesList).Assembly.GetManifestResourceStream("nHydrate.Dsl.Resources.CodeFluentImageLibrary.bmp"));
			}
			return ImagesList.UoOvOQQUO;
		}
	}
	private ImagesList()
	{
        this.resourceManager = new ResourceManager(Assembly.GetExecutingAssembly().GetName().Name + ".Resources.Strings", base.GetType().Module.Assembly);
	}
	private static ImagesList IllLIlOIv()
	{
		if (ImagesList.iQioovoUv == null)
		{
			Type typeFromHandle;
			Monitor.Enter(typeFromHandle = typeof(ImagesList));
			try
			{
				if (ImagesList.iQioovoUv == null)
				{
					ImagesList.iQioovoUv = new ImagesList();
				}
			}
			finally
			{
				Monitor.Exit(typeFromHandle);
			}
		}
		return ImagesList.iQioovoUv;
	}
	public static string IlioLvivl(string UiollQlou, params object[] lOQuOLLuv)
	{
		return ImagesList.QUlUlIIovl(null, UiollQlou, lOQuOLLuv);
	}
	public static string ioilQiLvv(string vlILLuUi, object lIQOuolOQl)
	{
		return ImagesList.QUlUlIIovl(null, vlILLuUi, new object[]
		{
			lIQOuolOQl
		});
	}
	public static string lIIvLLUUu(string uuuioUvuLl, object lIOUOOQIvl, object vliQLvIIO)
	{
		return ImagesList.QUlUlIIovl(null, uuuioUvuLl, new object[]
		{
			lIOUOOQIvl,
			vliQLvIIO
		});
	}
	public static string UIlLLlUvll(string IlIoLoLIil, object oILIvooIvl, object lOIQLvLQol, object LiuIlUvQU)
	{
		return ImagesList.QUlUlIIovl(null, IlIoLoLIil, new object[]
		{
			oILIvooIvl,
			lOIQLvLQol,
			LiuIlUvQU
		});
	}
	public static string iQLUouuIol(string LvLovLLiOl, object UlouulUuul, object llOQOuiIOl, object uOoIoUIQu, object vLlIvQiQUl)
	{
		return ImagesList.QUlUlIIovl(null, LvLovLLiOl, new object[]
		{
			UlouulUuul,
			llOQOuiIOl,
			uOoIoUIQu,
			vLlIvQiQUl
		});
	}
	public static string vOQoOiiul(CultureInfo lLIQOoQLl, string uoLvulIiOl, object QQIUivQiI)
	{
		return ImagesList.QUlUlIIovl(lLIQOoQLl, uoLvulIiOl, new object[]
		{
			QQIUivQiI
		});
	}
	public static string OloOlQIUo(CultureInfo OlOolilvi, string QiQLvoQULl, object loIUoIoOU, object IUQuuLuvOl)
	{
		return ImagesList.QUlUlIIovl(OlOolilvi, QiQLvoQULl, new object[]
		{
			loIUoIoOU,
			IUQuuLuvOl
		});
	}
	public static string iouUuIUuil(CultureInfo QvIvlLILv, string LUuQovQUOl, object LOvuIlQiQ, object uLlULovoQl, object lOIuiovUI)
	{
		return ImagesList.QUlUlIIovl(QvIvlLILv, LUuQovQUOl, new object[]
		{
			LOvuIlQiQ,
			uLlULovoQl,
			lOIuiovUI
		});
	}
	public static string uuQUuvLLul(CultureInfo OIOIlvUIlI, string vvuUOOUiLI, object liUouLIl, object UOiQOiIvQ, object QUoloULoQl, object IiovIOQoQl)
	{
		return ImagesList.QUlUlIIovl(OIOIlvUIlI, vvuUOOUiLI, new object[]
		{
			liUouLIl,
			UOiQOiIvQ,
			QUoloULoQl,
			IiovIOQoQl
		});
	}
	public static string QUlUlIIovl(CultureInfo OoOIuvvv, string oliLOvvUl, params object[] ooiQiQQOLl)
	{
		ImagesList imagesList = ImagesList.IllLIlOIv();
		if (imagesList == null)
		{
			return null;
		}
		string @string = imagesList.resourceManager.GetString(oliLOvvUl, OoOIuvvv);
		if (@string == null || @string.Length == 0)
		{
			return oliLOvvUl;
		}
		if (ooiQiQQOLl != null && ooiQiQQOLl.Length > 0)
		{
			return string.Format(OoOIuvvv, @string, ooiQiQQOLl);
		}
		return @string;
	}
	public static string ovliOiuLll(string vvUiLIQuLl)
	{
		return ImagesList.vlULvUvQUl(null, vvUiLIQuLl);
	}
	public static string vlULvUvQUl(CultureInfo ivIloiULil, string uoQQLvQO)
	{
		ImagesList imagesList = ImagesList.IllLIlOIv();
		if (imagesList == null)
		{
			return null;
		}
		string @string = imagesList.resourceManager.GetString(uoQQLvQO, ivIloiULil);
		if (@string == null || @string.Length == 0)
		{
			return uoQQLvQO;
		}
		return @string;
	}
	private static ImageList UuUuOQiOol(Stream stream)
	{
		ImageList imageList = new ImageList();
		if (stream == null)
		{
			return imageList;
		}
		imageList.ColorDepth = (ColorDepth)24;
		imageList.ImageSize = new Size(16, 16);
		Bitmap value = new Bitmap(stream);
		imageList.Images.AddStrip(value);
		imageList.TransparentColor = Color.Magenta;
		return imageList;
	}


    public static string XmlFilePath
    {
        get
        {
            const string path = "C:\\nHydrateModel\\Config.xml";

            return path;
        }
    }
}
