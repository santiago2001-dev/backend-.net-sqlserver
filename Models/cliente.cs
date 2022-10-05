using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class cliente
    {
        public int id { get; set; }
        public string nombre{ get; set; }
        public int edad { get; set; }
        public int documento { get; set; }
        public string tipoDocumento { get; set; }


        public cliente() { }

        public cliente(int id, int edad, int documento, string tipoDocumento, string nombre)
        {
            this.id = id;
            this.edad = edad;
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.nombre = nombre;
        }

        public cliente( int edad, int documento, string tipoDocumento, string nombre)
        {
           
            this.edad = edad;
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.nombre = nombre;
        }
    }
}