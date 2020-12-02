using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public void Init()
        {
            Escuela = new Escuela("Ing-enio", "Colombia")
            {
                TipoEscuela = TipoEscuela.Primaria,
                Year = 2000,
            };

            Escuela.Cursos = InitCursos();
            
        }

        private List<Curso> InitCursos()
        {
            return new List<Curso>()
            {
                new Curso() { Nombre = "101", Jornada = TipoJornada.Mañana, Alumnos = InitAlumnos(),
                              Asignaturas = InitAsignaturas() },

                new Curso() { Nombre = "102", Jornada = TipoJornada.Noche, Alumnos = InitAlumnos(),
                              Asignaturas = InitAsignaturas() },
                //new Curso() { Nombre = "103", Jornada = TipoJornada.Mañana, Alumnos = InitAlumnos() },
            };
        }

        private List<Asignatura> InitAsignaturas()
        {
            return new List<Asignatura>()
            {
                new Asignatura() { Nombre = "Matemáticas", Evaluciones = InitEvaluaciones("Matemáticas") },
                new Asignatura() { Nombre = "Castellano", Evaluciones = InitEvaluaciones("Castellano") },
                new Asignatura() { Nombre = "Química", Evaluciones = InitEvaluaciones("Química") }
            };
        }

        private List<Evaluacion> InitEvaluaciones(string asignatura)
        {
            string[] evaluaciones = { "Quiz 1", "Quiz 2", "Examen intermedio",  "Quiz 3", "Examen final" };

            string GenerarNombre() {

                var nombre = from evaluacion in evaluaciones
                             select string.Format("{0} {1}", evaluacion, asignatura);

                return nombre.First().ToString();
            }

            return new List<Evaluacion>()
            {

                new Evaluacion() { Nombre = GenerarNombre() },
                new Evaluacion() { Nombre = GenerarNombre() },
                new Evaluacion() { Nombre = GenerarNombre() },
                new Evaluacion() { Nombre = GenerarNombre() },
                new Evaluacion() { Nombre = GenerarNombre() }
            };
        }

        private List<Alumno> InitAlumnos()
        {
            string[] nombres = { "Martin", "Remmy" };
            string[] apellidos = { "Ceverus", "Da Vinci" };

            IEnumerable<Alumno> estudiantes = from nombre in nombres
                                              from apellido in apellidos
                                select new Alumno() { Nombre = string.Format("{0} {1}", nombre.ToUpper(), apellido.ToUpper()) };

            return estudiantes.ToList();
        }

        public void ImprimirCursos(Escuela escuela)
        {
            Printer.WriteTitle("Cursos");

            if (escuela.Cursos.Count == 0) Console.WriteLine("Ninguno");
            else
            {
                escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
                {
                    Console.WriteLine(string.Format("Id: {0}, Nombre: {1}, Jornada: {2}", 
                                      curso.Id, curso.Nombre, curso.Jornada));
                });
            }
        }

        public void ImprimirEvaluaciones(Escuela escuela)
        {
            Printer.WriteTitle("Evaluaciones");

            if (escuela.Cursos.First().Asignaturas.First().Evaluciones.Count == 0) Console.WriteLine("No hay Evaluaciones");
            else
            {
                escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
                {
                    Console.WriteLine(string.Format("Id: {0}, Nombre: {1}, Jornada: {2}",
                                      curso.Id, curso.Nombre, curso.Jornada));
                });
            }
        }

        public void ImprimirAlumnos(Escuela escuela)
        {
            Printer.WriteTitle("Alumnos");

            escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
            {
                curso.Alumnos.AsEnumerable().ToList().ForEach(alumno => {
                    Console.WriteLine(string.Format("Alumno: {0}, Curso: {1}, Jornada: {2}", 
                                      alumno.Nombre, curso.Nombre, curso.Jornada));
                });
            });
        }
    }
}
