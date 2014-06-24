using System.Collections.Generic;

namespace OSIS.PEPPAM.BOM
{
	partial class Experiencias_MasterCollection
	{
        public static OSIS.PEPPAM.BOM.Experiencias_MasterCollection PageLoadAllPagingPersona(int pageIndex, int pageSize, string searchString, CodeFluent.Runtime.PageOptions pageOptions, int usuarioNumero)
        {

            var procNam = "Proc_Persona_Experiencias_Paging";
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Persona_Secuencia", usuarioNumero.ToString());


            return PageLoadAllCustomPaging(pageIndex, pageSize, searchString, procNam,dictionary,pageOptions );
        }
	}
}
