using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Curso
    {
        public Guid Id { get; }
        public string Nombre { get; set; }
        public TipoJornada Jornada { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public Curso()
        {
            Id = Guid.NewGuid();
        }
    }
}
