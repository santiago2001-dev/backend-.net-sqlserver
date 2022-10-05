using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using back_mascota.Models;

namespace back_mascota.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class productoController : ApiController
    {
        // GET: api/producto
        public IEnumerable <producto> Get()
        {
            gestoProducto getprod = new gestoProducto();
            return getprod.getproducto();
        }

        // GET: api/producto/5
        //public IEnumerable <producto> Get(int id)
        //{
        //    gestoProducto getprod = new gestoProducto();
        //    return getprod.getproductobyid(id);
        //    ;
        //}




        // POST: api/producto
        public bool Post([FromBody]producto prod)
        {
            gestoProducto prodo = new gestoProducto();
            bool res = prodo.addProduct(prod);
            return res;
        }

        // PUT: api/producto/5
        public bool Put(int id, [FromBody]producto prod)
        {
            gestoProducto prodo = new gestoProducto();
            bool res = prodo.updateProduct(id, prod);
            return res;

        }

        // DELETE: api/producto/5
        public bool Delete(int id)
        {
            gestoProducto prodo = new gestoProducto();
            bool res  = prodo.deleteProduct(id);
            return res;
        }
    }
}
