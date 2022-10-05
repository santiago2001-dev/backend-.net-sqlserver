using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class producto
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public Int64 precio { get; set; }
        public int unidadesExistentes { get; set; }
        public int unidadesVendidas { get; set; }

        public producto() { }

        public producto(long id, string nombre, string marca, long precio, int unidadesExistentes, int unidadesVendidas)
        {
            this.id = id;
            this.nombre = nombre;
            this.marca = marca;
            this.precio = precio;
            this.unidadesExistentes = unidadesExistentes;
            this.unidadesVendidas = unidadesVendidas;
        }

        public producto( string nombre, string marca, long precio, int unidadesExistentes, int unidadesVendidas)
        {
            
            this.nombre = nombre;
            this.marca = marca;
            this.precio = precio;
            this.unidadesExistentes = unidadesExistentes;
            this.unidadesVendidas = unidadesVendidas;
        }


    }
}