using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    sealed class EscuelaEngine
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

        public Dictionary<LlaveDiccionario, IEnumerable<EscuelaBase>> GetEscuelaDictionary()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<EscuelaBase>>()
            {
                { LlaveDiccionario.Escuela, new [] { Escuela } },
                { LlaveDiccionario.Curso, Escuela.Cursos }
            };

            List<Alumno> alumnos = new List<Alumno>();
            List<Asignatura> asignaturas = new List<Asignatura>();
            List<Evaluacion> evaluaciones = new List<Evaluacion>();

            Escuela.Cursos.ForEach(curso =>
            {
                alumnos.AddRange(curso.Alumnos);
                asignaturas.AddRange(curso.Asignaturas);

                curso.Asignaturas.ForEach(asignatura => evaluaciones.AddRange(asignatura.Evaluciones));
            });

            diccionario.Add(LlaveDiccionario.Alumno, alumnos);
            diccionario.Add(LlaveDiccionario.Asignatura, asignaturas);
            diccionario.Add(LlaveDiccionario.Evaluacion, evaluaciones);

            return diccionario;
        }

        //los datos que se retornen seran de solo lectura (no se modificaran)
        public IReadOnlyCollection<EscuelaBase> GetEstructuratEscuelaList()
        {
            List<EscuelaBase> listEscuelaBase = new List<EscuelaBase>();
            listEscuelaBase.Add(Escuela);
            
            foreach (var curso in Escuela.Cursos)
            {
                listEscuelaBase.Add(curso);

                curso.Alumnos.ForEach(alumno => listEscuelaBase.Add(alumno));

                curso.Asignaturas.ForEach(asignatura =>
                {
                    listEscuelaBase.Add(asignatura);

                    asignatura.Evaluciones.ForEach(evaluacion => listEscuelaBase.Add(evaluacion));
                });
            }

            return listEscuelaBase;
        }

        #region inicializadores de datos

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
            string[] nombres = { "Matemáticas", "Castellano", "Química" };
            List<Asignatura> asignaturas = new List<Asignatura>();

            foreach (string nombre in nombres)
            {
                asignaturas.Add(new Asignatura() { Nombre = nombre, Evaluciones = InitEvaluaciones(nombre) });
            }

            return asignaturas;
        }

        private List<Evaluacion> InitEvaluaciones(string asignatura)
        {
            string[] evaluaciones = { "Quiz 1", "Quiz 2", "Examen intermedio",  "Quiz 3", "Examen final" };
            List<Evaluacion> listEvaluaciones = new List<Evaluacion>();
            Random random = new Random();

            string GenerarNombre(int indice) {

                return string.Format("{1} {0}", asignatura, evaluaciones[indice]);
            }

            for (int i = 0; i < 5; i++)
            {
                listEvaluaciones.Add(new Evaluacion() { Nombre = GenerarNombre(i), Nota = (float)random.NextDouble() });
            }

            return listEvaluaciones;
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

        #endregion

        #region metodos imprimir

        public void ImprimirCursos()
        {
            Printer.WriteTitle("Cursos");

            if (Escuela.Cursos.Count == 0) Console.WriteLine("Ninguno");
            else
            {
                Escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
                {
                    Console.WriteLine(string.Format("Id: {0}, Nombre: {1}, Jornada: {2}", 
                                      curso.Id, curso.Nombre, curso.Jornada));
                });
            }
        }

        public void ImprimirEvaluaciones()
        {
            Printer.WriteTitle("Evaluaciones");

            if (Escuela.Cursos.First().Asignaturas.First().Evaluciones.Count == 0) Console.WriteLine("No hay Evaluaciones");
            else
            {
                Escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
                {
                    curso.Asignaturas.ForEach(asignatura =>
                    {
                        asignatura.Evaluciones.ForEach(evaluacion => {
                            Console.WriteLine(string.Format("Curso: {0}, Jornada: {1}, Asignatura: {2}, Evaluaciones: {3}",
                                      curso.Nombre, curso.Jornada, asignatura.Nombre, evaluacion.Nombre));
                        });
                    });
                });
            }
        }

        public void ImprimirAlumnos()
        {
            Printer.WriteTitle("Alumnos");

            if (Escuela.Cursos.First().Alumnos.Count == 0) Console.WriteLine("No hay alumnos.");
            else
            {
                Escuela.Cursos.AsEnumerable().ToList().ForEach(curso =>
                {
                    curso.Alumnos.AsEnumerable().ToList().ForEach(alumno => {
                        Console.WriteLine(string.Format("Alumno: {0}, Curso: {1}, Jornada: {2}",
                                          alumno.Nombre, curso.Nombre, curso.Jornada));
                    });
                });
            }
        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<EscuelaBase>> diccionario)
        {
            diccionario.ToList().ForEach(obj =>
            {
                Printer.WriteTitle(obj.Key.ToString());

                obj.Value.ToList().ForEach(val => {

                    Console.WriteLine(val);

                });
            });
        }

        #endregion
    }
}
