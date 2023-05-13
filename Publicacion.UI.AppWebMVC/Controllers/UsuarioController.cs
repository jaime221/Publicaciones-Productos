using Publicacion.BL;
using Publicacion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Publicacion.UI.AppWebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public bool ValidarDatos(Usuario pUsuario)
        {
  
            bool resultado = true;
            if (pUsuario.IdRol == 0)
            {
                resultado = false;
            }
            if (string.IsNullOrWhiteSpace(pUsuario.Nombre))
            {
                resultado = false;
            }
            if (string.IsNullOrWhiteSpace(pUsuario.Correo))
            {
                resultado = false;
            }
            if (pUsuario.Id == 0 && string.IsNullOrWhiteSpace(pUsuario.Clave))
            {
               
                resultado = false;
            }
            return resultado;
        }
        // Aciones CRUD
        public JsonResult Guardar(Usuario pUsuario)
        {
            int resultado = 0;
            try
            {
                if (ValidarDatos(pUsuario) == true)
                {
                    resultado = new UsuarioBL().Guardar(pUsuario);
                }
            }
            catch (Exception ex)
            {

                resultado = 0;
            }
            return Json(resultado);
        }
        public JsonResult Modificar(Usuario pUsuario)
        {
            int resultado = 0;
            try
            {
                if (pUsuario.Id > 0 && ValidarDatos(pUsuario) == true)
                {
                    resultado = new UsuarioBL().Modificar(pUsuario);
                }
            }
            catch (Exception ex)
            {

                resultado = 0;
            }
            return Json(resultado);
        }
        public JsonResult Eliminar(Usuario pUsuario)
        {
            int resultado = 0;
            try
            {
                if (pUsuario.Id > 0)
                {
                    resultado = new UsuarioBL().Eliminar(pUsuario);
                }

            }
            catch (Exception ex)
            {

                resultado = 0;
            }
            return Json(resultado);
        }
        public JsonResult BuscarPorId(int pId)
        {
            Usuario objUsuario = new UsuarioBL().BuscarPorId(pId);
            return Json(objUsuario);
        }
        public JsonResult Buscar(Usuario pUsuario)
        {
            UsuarioBL productoBL = new UsuarioBL();
            List<Usuario> lista = productoBL.Buscar(pUsuario);
            productoBL.CargarPropiedadVirtualRol(lista);
            return Json(lista);
        }
        public JsonResult ObtenerRoles()
        {
            List<Rol> lista = new RolBL().Buscar(new Rol { Estado = 1 });
            return Json(lista);
        }
    }
}