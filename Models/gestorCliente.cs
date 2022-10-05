using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class gestorCliente
    {
        public List<cliente> getCliente()
        {
            List<cliente> clienteList = new List<cliente>();
            string strcon = ConfigurationManager.ConnectionStrings["facturacion"].ToString();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "cliente_get_all";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    int documento = dr.GetInt32(2);
                    string tipoDocumento = dr.GetString(3).Trim();
                    int edad = dr.GetInt32(4);

                    cliente cliente = new cliente(id, edad, documento, tipoDocumento, nombre);
                    clienteList.Add(cliente);

                }
                dr.Close();
                conn.Close();
            }
            return clienteList;

        }


        public bool addClient(cliente cli)
        {

            bool res = false;

            string strcon = ConfigurationManager.ConnectionStrings["facturacion"].ToString();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "cliente_insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", cli.nombre);
                cmd.Parameters.AddWithValue("@edad", cli.edad);
                cmd.Parameters.AddWithValue("@documento", cli.documento);
                cmd.Parameters.AddWithValue("@tipoDocumento", cli.tipoDocumento);
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



        public bool updateClient(int id ,cliente cli)
        {

            bool res = false;

            string strcon = ConfigurationManager.ConnectionStrings["facturacion"].ToString();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "cliente_update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", cli.nombre);
                cmd.Parameters.AddWithValue("@edad", cli.edad);
                cmd.Parameters.AddWithValue("@documento", cli.documento);
                cmd.Parameters.AddWithValue("@tipoDocumento", cli.tipoDocumento);
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


        public bool deleteClient(int id)
        {

            bool res = false;

            string strcon = ConfigurationManager.ConnectionStrings["facturacion"].ToString();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "cliente_delite";
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