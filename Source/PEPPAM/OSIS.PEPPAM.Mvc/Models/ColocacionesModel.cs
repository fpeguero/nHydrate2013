using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFluent.Runtime;

namespace OSIS.PEPPAM.Mvc.Models
{
	public class ColocacionesModel
	{
        [OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Turno_Informe_Trans", "Horario_Turno_Secuencia")]
        public int Horario_Turno_Secuencia { get; set; }

        [OSIS.PEPPAM.Mvc.Infrastructure.Mvc.DisplayName("Horario_Turno_Informe_Trans", "Dia_Secuencia")]
        public int Dia_Secuencia { get; set; } 

	    public List<Publicaciones_CataModel> Publicaciones { get; set; }

        public List<Proc_Persona_Turnos_InformesModel> Turnos { get; set; }

        public virtual string EntityKey
        {
            get
            {
                object[] keys = new object[] {
                        this.Horario_Turno_Secuencia,
                        this.Dia_Secuencia
                 };
                string v = CodeFluentPersistence.BuildEntityKey(keys);
                return v;
            }
            set
            {
                System.Type[] types = new System.Type[] {
                        typeof(int),
                        typeof(int),
                        };
                object[] defaultValues = new object[] {
                        -1,
                        -1,
                        };
                object[] v1 = CodeFluentPersistence.ParseEntityKey(value, types, defaultValues);
                this.Horario_Turno_Secuencia = ((int)(v1[0]));
                this.Dia_Secuencia = ((int)(v1[1]));
               
            }
        }
	}
}