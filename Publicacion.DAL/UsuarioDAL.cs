using Publicacion.EN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.DAL
{
    public class UsuarioDAL
    {

        public static int Guardar(Usuario pUsuario)
        {
            string consulta = @"INSERT INTO Usuarios( IdRol, Nombre,Correo, Clave, Estado) 
                                VALUES( @IdRol, @Nombre,  @Correo, @Clave, @Estado)";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            comando.Parameters.AddWithValue("@Correo", pUsuario.Correo);
            comando.Parameters.AddWithValue("@Clave", pUsuario.Clave);
            comando.Parameters.AddWithValue("@Estado", pUsuario.Estado);

            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Usuario pUsuario)
        {
            string consulta = @"UPDATE Usuarios 
                                SET  Nombre = @Nombre                           
                                WHERE Id = @Id";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

   
            comando.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            
            comando.Parameters.AddWithValue("@Id", pUsuario.Id);

            return ComunDB.EjecutarComando(comando);
        }

        public static int Eliminar(Usuario pUsuario)
        {
            // Eliminacion logica
            string consulta = @"UPDATE Usuarios
                                SET Estado = 0
                                WHERE Id = @Id";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pUsuario.Id);

            return ComunDB.EjecutarComando(comando);
        }

        public static Usuario BuscarPorId(int pId)
        {
            string consulta = @"SELECT Id, IdRol, Nombre, Correo , Estado
                                FROM Usuarios 
                                WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Usuario objUsuario = new Usuario();
            while (reader.Read())
            {
                objUsuario.Id = reader.GetByte(0);
                objUsuario.IdRol = reader.GetByte(1);
                objUsuario.Nombre = reader.GetString(2);
                objUsuario.Correo = reader.GetString(3);
                objUsuario.Estado = reader.GetByte(4);
            }

            return objUsuario;
        }

        public static List<Usuario> Buscar(Usuario pUsuario)
        {
            byte contador = 0;
            //Definir consulta SQL base
            string consulta = @"SELECT TOP 50 Id, IdRol, Nombre, Correo,Estado
                                FROM Usuarios";
            string whereSQL = "";

            SqlCommand comando = ComunDB.ObtenerComando();

            // Definir filtros WHERE de la consulta
            if (pUsuario.IdRol > 0)
            {
                if (contador > 0)
                {
                    whereSQL += " AND ";
                }
                contador++;
                whereSQL += " IdRol = @IdRol ";
                comando.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
            }
            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
            {
                if (contador > 0)
                {
                    whereSQL += " AND ";
                }
                contador++;
                whereSQL += " Nombre Like @Nombre ";
                comando.Parameters.AddWithValue("@Nombre", "%" + pUsuario.Nombre + "%");
            }
            if (!string.IsNullOrWhiteSpace(pUsuario.Correo))
            {
                if (contador > 0)
                {
                    whereSQL += " AND ";
                }
                contador++;
                whereSQL += " Correo Like @Correo ";
                comando.Parameters.AddWithValue("@Correo", "%" + pUsuario.Correo + "%");
            }
            if (!string.IsNullOrWhiteSpace(pUsuario.Clave))
            {
                if (contador > 0)
                {
                    whereSQL += " AND ";
                }
                contador++;
                whereSQL += " Clave Like @Clave ";
                comando.Parameters.AddWithValue("@Clave", "%" + pUsuario.Clave + "%");
            }
            if (pUsuario.Estado > 0)
            {
                if (contador > 0)
                {
                    whereSQL += " AND ";
                }
                contador++;
                whereSQL += " Estado = @Estado ";
                comando.Parameters.AddWithValue("@Estado", pUsuario.Estado);
            }

            // Comprobar que existen filtros
            if (whereSQL.Trim().Length > 0)
            {
                whereSQL = " WHERE " + whereSQL;
            }

            // Definir consulta SQL completa
            comando.CommandText = consulta + whereSQL;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Id = reader.GetByte(0);
                objUsuario.IdRol = reader.GetByte(1);
                objUsuario.Nombre = reader.GetString(2);
                objUsuario.Correo = reader.GetString(3);
                objUsuario.Estado = reader.GetByte(4);
                lista.Add(objUsuario);
            }

          
            return lista;
        }


    }
}
