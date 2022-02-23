using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer
{
    public class Add
    {
        public void agregando(LogicaRestaurante item)
        {
            Repositorio.Instancia.Ordenes.Add(item);
        }
        public List<LogicaRestaurante> ObtenerOrdenes()
        {

            return Repositorio.Instancia.Ordenes;
        }
    }
}
