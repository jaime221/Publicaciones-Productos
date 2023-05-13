using Publicacion.DAL;
using Publicacion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.BL
{
    public class UsuarioBL
    {
       
        public int Guardar(Usuario pUsuario)
        {
            pUsuario.Estado = 1;
            return UsuarioDAL.Guardar(pUsuario);
        }
       
        
        public int Modificar(Usuario pUsuario)
        {
            pUsuario.Estado = 1;
            return UsuarioDAL.Modificar(pUsuario);
        }
        
        public int Eliminar(Usuario pUsuario)
        {
            return UsuarioDAL.Eliminar(pUsuario);
        }
       
        public Usuario BuscarPorId(int pId)
        {
            return UsuarioDAL.BuscarPorId(pId);

        }
       
        public List<Usuario> Buscar(Usuario pUsuario)
        {
            pUsuario.Estado = 1;
            return UsuarioDAL.Buscar(pUsuario);
        }
      
       

        public void CargarPropiedadVirtualRol(List<Usuario> pLista, Action<List<Rol>> pAccion = null)
        {
           
            if (pLista.Count > 0)
            {
                
                Dictionary<byte, Rol> diccionarioRols = new Dictionary<byte, Rol>();

                
                foreach (var obj in pLista)
                {
                   
                    if (diccionarioRols.ContainsKey(obj.IdRol) == true)
                    {

                        obj.Rol = diccionarioRols[obj.IdRol];
                    }
                    else
                    {
                      
                        diccionarioRols.Add(obj.IdRol, RolDAL.BuscarPorId(obj.IdRol));
                    
                        obj.Rol = diccionarioRols[obj.IdRol];
                    }
                }
               
                if (pAccion != null && diccionarioRols.Count > 0)
                {
                    pAccion(diccionarioRols.Select(x => x.Value).ToList());
                }
            }

        }

    }
}
