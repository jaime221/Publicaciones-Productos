using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Publicacion.BL;
using Publicacion.EN;
namespace Publicacion.UI.AppWebMVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto

        static string cadena = "Data Source=.;Initial Catalog=PruebaTecnica;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(string Nombre, int IdCategoria, string Descripcion, HttpPostedFileBase Img, decimal Precio, int Cantidad)
        {
            string Extesion = Path.GetExtension(Img.FileName);
            MemoryStream ms = new MemoryStream();
            Img.InputStream.CopyTo(ms);
            byte[] data = ms.ToArray();

            using (SqlConnection oconexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Productos(IdCategoria,  Nombre, Descripcion, Precio,Cantidad,Img, Estado)values(@IdCategoria,  @Nombre, @Descripcion,@Precio,@Cantidad, @Img, @Estado); SELECT SCOPE_IDENTITY()", oconexion);
                cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Precio", Precio);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Img", data);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();
                int IdProducto = Convert.ToInt32(cmd.ExecuteScalar());                

            }
            TempData["SuccessMessage"] = "Los datos se han guardado correctamente";
            return RedirectToAction("VerProductos", "Producto");
        }



        public ActionResult VerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT p.Id, c.Nombre as NombreCategoria, p.Cantidad, p.Precio, p.Nombre, p.Descripcion, p.Img, p.Estado FROM Productos p JOIN Categorias c ON p.IdCategoria = c.Id WHERE p.Estado = 1", conexion);

                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)reader["Id"];
                  
                    producto.Nombre = reader["Nombre"].ToString();
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.NombreCategoria = reader["NombreCategoria"].ToString();
                    producto.Precio = (decimal)reader["Precio"];
                    producto.Cantidad = (int)reader["Cantidad"];
                    producto.Img = (byte[])reader["Img"];
                    producto.Estado = (byte)reader["Estado"];

                    productos.Add(producto);
                }
            }

            return View(productos);
        }

        public ActionResult EliminarProducto(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE Id=@Id", conexion);
                cmd.Parameters.AddWithValue("@Id", id);
                conexion.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return RedirectToAction("VerProductos");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }


        public JsonResult ObtenerCategorias()
        {
            List<Categoria> lista = new CategoriaBL().Buscar(new Categoria { Estado = 1 });
            return Json(lista);
        }

    }
}