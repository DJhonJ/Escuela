using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreEscuela.App;
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

            engine.ImprimirCursos(engine.Escuela);
            engine.ImprimirAlumnos(engine.Escuela);

            //Stopwatch tiempo = Stopwatch.StartNew();

            //Escuela escuela = new Escuela("Ing-enio", "Colombia");
            ////escuela.Name = "Ing-enio";
            //escuela.TipoEscuela = TipoEscuela.Primaria;
            //escuela.Year = 2000;

            //Console.WriteLine("-----------------");
            //Console.WriteLine("Escuela");
            //Console.WriteLine("-----------------");

            //Console.WriteLine(escuela);

            ////inicializamos un collection de cursos (objeto)
            //List<Curso> cursos = new List<Curso>()
            //{
            //    new Curso() { Nombre = "101", Jornada = TipoJornada.Mañana },
            //    new Curso() { Nombre = "102", Jornada = TipoJornada.Noche },
            //    new Curso() { Nombre = "103", Jornada = TipoJornada.Mañana },
            //};

            //escuela.Cursos = cursos;

            //Console.WriteLine("-----------------");
            //Console.WriteLine("Cursos");
            //Console.WriteLine("-----------------");

            //ImprimirCursos(escuela);

            //Console.WriteLine("-----------------");
            //Console.WriteLine("Nuevos Cursos");
            //Console.WriteLine("-----------------");

            //List<Curso> nuevosCursos = new List<Curso>()
            //{
            //    new Curso() { Nombre = "201 (new)", Jornada = TipoJornada.Mañana }
            //};

            //escuela.Cursos.AddRange(nuevosCursos);

            //ImprimirCursos(escuela);

            ////aqui utilizamos un delegado con expresion lambda (las expresiones lambda son una clase de delegados)
            ////Predicate <Curso> _Predicate = (curso) =>
            ////{
            ////    return curso.Nombre == "101";
            ////};

            ////escuela.Cursos.RemoveAll(_Predicate);

            ////delegate
            ////escuela.Cursos.RemoveAll(delegate(Curso curso) {
            ////    return true;
            ////});

            ////lambda
            //escuela.Cursos.RemoveAll(curso => {
            //    return curso.Nombre == "102";
            //});

            //Console.WriteLine("-----------------");
            //Console.WriteLine("Cursos más sobresalientes");
            //Console.WriteLine("-----------------");

            //ImprimirCursos(escuela);

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