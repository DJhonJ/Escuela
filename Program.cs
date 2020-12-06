using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            EscuelaEngine engine = new EscuelaEngine();
            engine.Init();

            Printer.WriteTitle("BIENVENIDO");

            engine.ImprimirCursos();
            engine.ImprimirAlumnos();
            engine.ImprimirEvaluaciones();

            engine.Escuela.Limpiar();

            var lista = engine.GetEstructuratEscuela();
            
            Console.ReadKey();
        }

        //private static void ImprimirCursos(Escuela escuela)
        //{
        //    if (escuela.Cursos.Count == 0) Console.WriteLine("Ninguno");
        //    else
        //    {
        //        escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
        //        {
        //            Console.WriteLine(string.Format("Id: {0}, Nombre: {1}, Jornada: {2}", curso.Id, curso.Nombre, curso.Jornada));
        //        });
        //    }
        //}
    }
}