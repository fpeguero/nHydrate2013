namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Rutas_Relacionados_DescripcionModel : Proc_Rutas_Relacionados_DescripcionBase
	{
	    //Custom Code Here!!!



	    public string Encargado_Nombre_Completo
	    {
	        get { return this.Encargado_Persona_Nombres + " " + this.Encargado_Persona_Apellidos; }
	    }


       public string Auxiliar_Nombre_Completo
       {
           get { return this.Auxiliar_Persona_Nombres + " " + this.Auxiliar_Persona_Apellidos; }
       }
	}
}
