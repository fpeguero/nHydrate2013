using System;
using CodeFluent.Runtime;

namespace OSIS.PEPPAM.Mvc.Models
{
	public partial class Proc_Persona_Turnos_InformesModel : Proc_Persona_Turnos_InformesBase
	{
       public virtual string Turno_Descripcion_Combinacion
       {
           get
           {
               string[] rutaDescripcion = new string[] { this.Ruta_Descripcion, " ", null, null, null, null, null, null, null, null };
               DateTime value = this.Turno_Fecha.Value;
               rutaDescripcion[2] = value.ToString("D");
               rutaDescripcion[3] = " ";
               rutaDescripcion[4] = this.Turno_Descripcion;
               rutaDescripcion[5] = " (";
               rutaDescripcion[6] = this.Turno_Hora_Desde;
               rutaDescripcion[7] = " - ";
               rutaDescripcion[8] = this.Turno_Hora_Hasta;
               rutaDescripcion[9] = ")";
               return string.Concat(rutaDescripcion);
           }
       }

       public virtual string Turno_Keys
       {
           get
           {
               object[] horarioTurnoSecuencia = new object[] { this.Horario_Turno_Secuencia, this.Dia_Secuencia };
               return CodeFluentPersistence.BuildEntityKey(horarioTurnoSecuencia);
           }
           set
           {
               Type[] typeArray = new Type[] { typeof(int), typeof(int) };
               object[] objArray = new object[] { -1, -1 };
               object[] objArray1 = CodeFluentPersistence.ParseEntityKey(value, typeArray, objArray);
               this.Horario_Turno_Secuencia = new int?((int)objArray1[0]);
               this.Dia_Secuencia = new int?((int)objArray1[1]);
           }
       }
	}
}
