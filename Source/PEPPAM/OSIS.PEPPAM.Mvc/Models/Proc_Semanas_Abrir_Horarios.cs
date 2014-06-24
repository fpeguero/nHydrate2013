using System;

namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Semanas_Abrir_HorariosModel : Proc_Semanas_Abrir_HorariosBase
	{
	    //Custom Code Here!!!

        public string EntityDisplayName2
        {
            get
            {
                object[] semanaCodigo = new object[] { "(", this.Semana_Codigo, ") ", null, null, null };
                DateTime value = this.Semana_Desde.Value;
                semanaCodigo[3] = value.ToString("D");
                semanaCodigo[4] = " - ";
                value = this.Semana_Hasta.Value;
                semanaCodigo[5] = value.ToString("D");
                return string.Concat(semanaCodigo);
            }
        }
	}
}
