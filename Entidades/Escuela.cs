using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Country { get; set; }
        public int Year { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string name, string country)
        {
            this.name = name;
            this.Country = country;
        }

        public Escuela(string name) => (this.name) = (name);

        public override string ToString()
        {
            return string.Format("Nombre: {0}, Pais: {1}\nTipo de Escuela: {2}, Año de creación: {3}", 
                name, Country, TipoEscuela, Year);
        }
    }
}