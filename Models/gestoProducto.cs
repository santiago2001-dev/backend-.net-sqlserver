
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class gestoProducto
    {
        public List<producto> getproducto() {

            List<producto> list = new List<producto>();

            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "producto_get_all";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string marca = dr.GetString(2).Trim();
                    int precio = (int)dr.GetSqlMoney(3);
                    int unidadesExistendes = dr.GetInt32(4);
                    int unidadesVendidas = dr.GetInt32(5);


                    producto prod = new producto(id, nombre, marca, precio, unidadesExistendes, unidadesVendidas);

                    list.Add(prod);
                }
                dr.Close();
                conn.Close();
            }
            return list;

        }

        //public List<producto> getproductobyid(int idprod)
        //{

        //    List<producto> list = new List<producto>();

        //    string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();
        //    using (SqlConnection conn = new SqlConnection(strConn))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "producto_get_byid";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", idprod);
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            int id = dr.GetInt32(0);
        //            string nombre = dr.GetString(1).Trim();
        //            string marca = dr.GetString(2).Trim();
        //            int precio = dr.GetInt32(3);
        //            int unidadesExistendes = dr.GetInt32(4);
        //            int unidadesVendidas = dr.GetInt32(5);


        //            producto prod = new producto(id, nombre, marca, precio, unidadesExistendes, unidadesVendidas);

        //            list.Add(prod);
        //        }
        //        dr.Close();
        //        conn.Close();
        //    }
        //    return list;

        //}


        public bool addProduct(producto prod){
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();
            
            using (SqlConnection conn = new SqlConnection(strConn)) { 
            SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "producto_insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre" ,prod.nombre);
                cmd.Parameters.AddWithValue("@marca", prod.marca);
                cmd.Parameters.AddWithValue("@precio", prod.precio);
                cmd.Parameters.AddWithValue("@unidadesExistentes", prod.unidadesExistentes);
                cmd.Parameters.AddWithValue("@unidadesVendidas", prod.unidadesVendidas);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {


                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally { 
                
                cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            
            }
}





        public bool updateProduct(int id,producto prod)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "producto_update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", prod.nombre);
                cmd.Parameters.AddWithValue("@marca", prod.marca);
                cmd.Parameters.AddWithValue("@precio", prod.precio);
                cmd.Parameters.AddWithValue("@unidadesExistentes", prod.unidadesExistentes);
                cmd.Parameters.AddWithValue("@unidadesVendidas", prod.unidadesVendidas);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {


                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {

                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;

            }
        }




        public bool deleteProduct(int id)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "producto_delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
          

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {


                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {

                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;

            }
        }

    }
}