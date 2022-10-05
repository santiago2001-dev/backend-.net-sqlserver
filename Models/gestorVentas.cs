using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class gestorVentas
    {
        public List<ventas> getVentas() {
        
        List<ventas> list = new List<ventas>();
            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn)) 
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "get_all_ventas";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int idCliente = dr.GetInt32(1);
                    int idProducto = dr.GetInt32(2);
                    string fecha = dr.GetDateTime(3).ToString("yyyy-MM-dd");

                    ventas vent = new ventas(id, idCliente, idProducto, fecha);
                    list.Add(vent);


                }

                dr.Close();
                conn.Close();


            }
            return list;


        }


        public bool insertVenta(ventas vent) {

            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn)) {

                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "venta_insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", vent.idCliente);
                cmd.Parameters.AddWithValue("@idProducto", vent.idProducto);
                cmd.Parameters.AddWithValue("@fecha", vent.fecha);
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



        public bool updateVenta(int id,ventas vent)
        {

            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "venta_update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idCliente", vent.idCliente);
                cmd.Parameters.AddWithValue("@idProducto", vent.idProducto);
                cmd.Parameters.AddWithValue("@fecha", vent.fecha);
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



        public bool deleteVenta(int id)
        {

            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["facturacion"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "venta_delete";
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