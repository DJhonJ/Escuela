using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Alumno
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public Alumno()
        {
            Id = Guid.NewGuid();
        }
    }
}
