using CoreEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Curso: EscuelaBase, ILugar
    {
        public TipoJornada Jornada { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public string Direccion { get; set; }

        public void Limpiar()
        {
            Printer.DrawLine();
            Console.WriteLine(string.Format("Limpiando Curso {0} ...", Nombre));
            Console.WriteLine("Curso limpio");
        }

        public override string ToString()
        {
            return string.Format("Curso: {0}", Nombre);
        }
    }
}
