using CodeFluent.Runtime;

namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Personas_TurnosModel : Proc_Personas_TurnosBase
	{
	    //Custom Code Here!!!

        public virtual string EntityKey
        {
            get
            {
                object[] keys = new object[] {
                        this.Persona_Secuencia,
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
                        typeof(int)
                        };
                object[] defaultValues = new object[] {
                        -1,
                        -1,
                        -1
                        };
                object[] v1 = CodeFluentPersistence.ParseEntityKey(value, types, defaultValues);
                this.Persona_Secuencia = ((int)(v1[0]));
                this.Horario_Turno_Secuencia = ((int)(v1[1]));
                this.Dia_Secuencia = ((int)(v1[2]));
            }
        }
	}
}
