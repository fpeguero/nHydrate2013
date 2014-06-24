namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Personas_Tipo_ConsultaModel : Proc_Personas_Tipo_ConsultaBase
	{
	    //Custom Code Here!!!

       public string Nombre_Completo
       {
           get { return this.Persona_Nombres + " " + this.Persona_Apellidos; }
       }
	}
}
