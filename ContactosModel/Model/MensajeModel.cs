﻿ using System;

namespace ContactosModel.Model
{
    public class MensajeModel
    {
        public int id { get; set; }
        public int idOrigen { get; set; }
        public int idDestino { get; set; }
        public string asunto { get; set; }
        public string contenido { get; set; }
        public bool leido { get; set; }
        public String Estado
        {
            get { return leido ? "Leido" : "Sin Leer"; }
        }
        public System.DateTime fecha { get; set; }
    }
}