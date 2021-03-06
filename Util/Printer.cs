﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Util
{
    static class Printer
    {
        public static void DrawLine(int tamano = 10)
        {
            Console.WriteLine("".PadLeft(tamano, '='));
        }

        public static void WriteTitle(string titulo)
        {
            DrawLine(titulo.Length + 4);
            Console.WriteLine(string.Format("| {0} |", titulo));
            DrawLine(titulo.Length + 4);
        }
    }
}
