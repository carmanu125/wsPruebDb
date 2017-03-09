using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WsMyDb.Areas.Api.Models
{
    public class DataBase
    {

        public bool InsertarCliente(Cliente cli)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());

            con.Open();

            string sql = "INSERT INTO Cliente (Nombre, Cedula) VALUES (@nombre, @cedula)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = cli.nombre;
            cmd.Parameters.Add("@cedula", System.Data.SqlDbType.NVarChar).Value = cli.cedula;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());

            con.Open();

            string sql = "SELECT id, Nombre, Cedula FROM Cliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                  cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Cliente cli = new Cliente();

                cli = new Cliente();
                cli.id = reader.GetInt32(0);
                cli.nombre = reader.GetString(1);
                cli.cedula = reader.GetString(2);

                lista.Add(cli);
            }

            reader.Close();

            return lista;
        }

      
    }
}