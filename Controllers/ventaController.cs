using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using back_mascota.Models;

namespace back_mascota.Controllers
{
    public class ventaController : ApiController
    {
        // GET: api/venta
        public IEnumerable<ventas> Get()
        {
            gestorVentas gest = new gestorVentas();
            return gest.getVentas() ;
        }

        // GET: api/venta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/venta
        public bool Post([FromBody]ventas vent)
        {
            gestorVentas gest = new gestorVentas();
            return gest.insertVenta(vent) ;
        }

        // PUT: api/venta/5
        public bool Put(int id, [FromBody]ventas vent)
        {
            gestorVentas gest = new gestorVentas();
            return gest.updateVenta(id,vent);
        }

        // DELETE: api/venta/5
        public bool Delete(int id)
        {
            gestorVentas gest = new gestorVentas();
            return gest.deleteVenta(id);
        }
    }
}
