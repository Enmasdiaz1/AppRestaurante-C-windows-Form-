using System;

namespace BussinessLayer
{
    public  class LogicaRestaurante
    {
        public string Nombre { get; set; }
        public string Entrada { get; set; }
        public string PlatoFuerte { get; set; }
        public string  Liquido { get; set; }
        public string Postre { get; set; }



        public string ObtenerMensaje()
        {
            return $"Nombre:{Nombre}\n" +
                $"Plato de Entrada: {Entrada}\n" +
                $"Plato Fuerte: {PlatoFuerte}\n" +
                $"Liquido a Ingerir: {Liquido}\n" +
                $"Postre o Dulce: {Postre}\n"+
                $"------------------------------------------------------------------\n\n";
        }
    }
}
