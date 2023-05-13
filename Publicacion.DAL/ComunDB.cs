using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.DAL
{
    public class ComunDB
    {
        const string StrConexion = @"Data Source=.;Initial Catalog=PruebaTecnica;Integrated Security=True";

       
        private static SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(StrConexion);
            connection.Open();
            return connection;
        }

     
        public static SqlCommand ObtenerComando()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = ObtenerConexion();
            return command;
        }

       
        public static int EjecutarComando(SqlCommand pComando)
        {
            int resultado = pComando.ExecuteNonQuery();
            pComando.Connection.Close();
            return resultado;
        }
        
        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando)
        {
            SqlDataReader reader = pComando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public static DateTime ObtenerFechaIni(DateTime pFecha)
        {
            return new DateTime(pFecha.Year, pFecha.Month, pFecha.Day, 0, 0, 0);
        }
        public static DateTime ObtenerFechaFin(DateTime pFecha)
        {
            return new DateTime(pFecha.Year, pFecha.Month, pFecha.Day, 23, 59, 59);
        }


    }
}
