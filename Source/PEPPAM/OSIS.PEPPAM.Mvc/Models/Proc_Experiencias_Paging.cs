namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Experiencias_PagingModel : Proc_Experiencias_PagingBase
	{
	    //Custom Code Here!!!
        public string Hermanoa
        {
            get
            {
                string str = string.Format("{0} {1} ({2}) ", this.Persona_Nombres, this.Persona_Apellidos, this.Congregacion_Nombre);
                return str;
            }
        }
	}
}
