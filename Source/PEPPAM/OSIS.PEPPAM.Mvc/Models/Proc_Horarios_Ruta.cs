using System;
using System.Globalization;

namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Horarios_RutaModel : Proc_Horarios_RutaBase
	{
	    //Custom Code Here!!!

        public virtual string EntityDisplayName2
        {
            get
            {
                DateTime horarioFechaDesde = this.Horario_Fecha_Desde;
                string str = horarioFechaDesde.ToString("MMMM-dd", new CultureInfo("es-DO"));
                horarioFechaDesde = this.Horario_Fecha_Hasta;
                string str1 = string.Concat(str, "   -   ", horarioFechaDesde.ToString("MMMM-dd", new CultureInfo("es-DO")));
                return str1;
            }
        }

	}
}
