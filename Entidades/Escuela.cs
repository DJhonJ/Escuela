using CoreEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    sealed class Escuela: EscuelaBase, ILugar
    {
        public string Country { get; set; }
        public int Year { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        public string Direccion { get; set; }

        public Escuela(string name, string country)
        {
            Nombre = name;
            Country = country;
        }

        public Escuela(string name) => (Nombre) = (name);

        public override string ToString()
        {
            return string.Format("Nombre: {0}, Pais: {1}\nTipo de Escuela: {2}, Año de creación: {3}", 
                Nombre, Country, TipoEscuela, Year);
        }

        public void Limpiar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela");
            foreach (Curso curso in Cursos)
            {
                curso.Limpiar();
            }

            Printer.WriteTitle($"Escuela {Nombre} limpia.");
        }
    }
}