using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public sealed class Repositorio
    {
        private Repositorio() { }

        public static Repositorio Instancia { get; } = new Repositorio();

        public int CantidadDePersonas = 0;

        public List<LogicaRestaurante> Ordenes = new List<LogicaRestaurante>();
    }
}
