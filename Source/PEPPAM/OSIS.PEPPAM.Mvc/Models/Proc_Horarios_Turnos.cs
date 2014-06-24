using System;
using CodeFluent.Runtime;

namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Horarios_TurnosModel : Proc_Horarios_TurnosBase
	{
	    //Custom Code Here!!!
        public virtual string EntityKey
        {
            get
            {
                object[] horarioTurnoSecuencia = new object[] { this.Horario_Turno_Secuencia, this.Dia_Secuencia };
                return CodeFluentPersistence.BuildEntityKey(horarioTurnoSecuencia);
            }
            set
            {
                Type[] typeArray = new Type[] { typeof(int), typeof(int), typeof(int) };
                object[] objArray = new object[] { -1, -1, -1 };
                object[] objArray1 = CodeFluentPersistence.ParseEntityKey(value, typeArray, objArray);
                this.Horario_Turno_Secuencia = new int?((int)objArray1[1]);
                this.Dia_Secuencia = new int?((int)objArray1[2]);
            }
        }
	}
}
