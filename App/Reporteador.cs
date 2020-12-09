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
                List<Asignatura> asignaturas = new List<Asignatura>();

                dic.Cast<Asignatura>().ToList().ForEach(asignatura =>
                {
                    if (asignaturas.Count > 0)
                    {
                        var response = asignaturas.ToList().FindAll((asig) => asignatura.Nombre == asig.Nombre).ToList();
                        if (response.Count == 0) asignaturas.Add(asignatura);
                    }
                    else
                    {
                        asignaturas.Add(asignatura);
                    }
                });

                return asignaturas;
            }

            return null;
        }

        public IEnumerable<string> GetListEvaluaciones()
        {
            var asignaturas = GetListAsignaturas();

            return (from Asignatura a in asignaturas
                    from Evaluacion ev in a.Evaluciones
                    select ev.Nombre);
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetEvaluacionPorAsignatura()
        {
            var diccionario = new Dictionary<string, IEnumerable<Evaluacion>>();
            var asignaturas = GetListAsignaturas();

            asignaturas.ToList().ForEach(asignaruta => {
                diccionario.Add(asignaruta.Nombre, asignaruta.Evaluciones);
            });

            return diccionario;
        }
    }
}
