using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    abstract class EscuelaBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public EscuelaBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
