using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Asignatura
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public List<Evaluacion> Evaluciones { get; set; }

        public Asignatura()
        {
            Id = Guid.NewGuid();
        }
    }
}
