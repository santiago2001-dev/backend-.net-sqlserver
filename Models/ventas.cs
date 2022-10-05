using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class ventas
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        public string fecha { get; set; }

        public ventas() { }

        public ventas(int id, int idCliente, int idProducto, string fecha)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.idProducto = idProducto;
            this.fecha = fecha;
        }

        public ventas( int idCliente, int idProducto, string fecha)
        {
           
            this.idCliente = idCliente;
            this.idProducto = idProducto;
            this.fecha = fecha;
        }
    }
   
}