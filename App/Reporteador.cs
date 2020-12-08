using CoreEscuela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.App
{
    class Reporteador
    {
        private Dictionary<LlaveDiccionario, IEnumerable<EscuelaBase>> diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<EscuelaBase>> diccionarioReporte)
        {
            diccionario = diccionarioReporte ?? throw new ArgumentException(nameof(diccionarioReporte));
        }

        public IEnumerable<Asignatura> GetListAsignaturas()
        {
            if (diccionario.TryGetValue(LlaveDiccionario.Asignatura, out IEnumerable<EscuelaBase> dic))
            {
                return dic.Cast<Asignatura>();
            }

            return null;
        }
    }
}
