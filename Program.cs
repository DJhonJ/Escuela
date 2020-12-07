using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            EscuelaEngine engine = new EscuelaEngine();
            engine.Init();

            Printer.WriteTitle("BIENVENIDO");

            //engine.ImprimirCursos();
            //engine.ImprimirAlumnos();
            //engine.ImprimirEvaluaciones();

            //engine.Escuela.Limpiar();

            //var lista = engine.GetEstructuratEscuelaList();
            var dictionary = engine.GetEscuelaDictionary();
            engine.ImprimirDiccionario(dictionary);

            Console.ReadKey();
        }
    }
}