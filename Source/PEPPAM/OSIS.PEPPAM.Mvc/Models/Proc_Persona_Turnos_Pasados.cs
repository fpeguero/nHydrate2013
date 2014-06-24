using System;
using CodeFluent.Runtime;

namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Persona_Turnos_PasadosModel : Proc_Persona_Turnos_PasadosBase
	{
	    //Custom Code Here!!!

        public virtual string EntityDisplayName
        {
            get
            {
                object[] rutaDescripcion = new object[] { this.Ruta_Descripcion, this.Turno_Descripcion, this.Turno_Hora_Desde, this.Turno_Hora_Hasta, string.Format("{0:D}", this.Turno_Fecha) };
                return string.Format("Puesto :{0} - Turno: {1} Desde {2} Hasta {3}  - Fecha {4} ", rutaDescripcion);
            }
        }

        public virtual string EntityKey
        {
            get
            {
                object[] personaSecuencia = new object[] { this.Persona_Secuencia, this.Horario_Turno_Secuencia, this.Dia_Secuencia };
                return CodeFluentPersistence.BuildEntityKey(personaSecuencia);
            }
            set
            {
                Type[] typeArray = new Type[] { typeof(int), typeof(int), typeof(int) };
                object[] objArray = new object[] { -1, -1, -1 };
                object[] objArray1 = CodeFluentPersistence.ParseEntityKey(value, typeArray, objArray);
                this.Persona_Secuencia = new int?((int)objArray1[0]);
                this.Horario_Turno_Secuencia = new int?((int)objArray1[1]);
                this.Dia_Secuencia = new int?((int)objArray1[2]);
            }
        }
	}
}
