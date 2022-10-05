using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using back_mascota.Models;

namespace back_mascota.Controllers
{
    public class clienteController : ApiController
    {
        // GET: api/cliente
        public IEnumerable<cliente> Get()
        {
            gestorCliente cli = new gestorCliente();
            return cli.getCliente();
        }

        // GET: api/cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/cliente
        public bool Post([FromBody]cliente cli)
        {
            gestorCliente clien = new gestorCliente();
            return clien.addClient(cli);
        }

        // PUT: api/cliente/5
        public bool Put(int id, [FromBody]cliente cli)
        {
            gestorCliente clien = new gestorCliente();
            return clien.updateClient(id,cli);
        }

        // DELETE: api/cliente/5
        public bool Delete(int id)
        {
            gestorCliente clien = new gestorCliente();
            return clien.deleteClient(id);
        }
    }
}
