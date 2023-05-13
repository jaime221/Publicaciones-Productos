using Publicacion.EN;
using Publicacion.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.BL
{
    public class RolBL
    {
        public int Guardar(Rol pRol)
        {
            pRol.Estado = 1;
            return RolDAL.Guardar(pRol);
        }

        public int Modificar(Rol pRol)
        {
            pRol.Estado = 1;
            return RolDAL.Modificar(pRol);
        }

        public int Eliminar(Rol pRol)
        {
            return RolDAL.Eliminar(pRol);
        }

        public Rol BuscarPorId(int pId)
        {
            return RolDAL.BuscarPorId(pId);
        }

        public List<Rol> Buscar(Rol pRol)
        {
            pRol.Estado = 1;
            return RolDAL.Buscar(pRol);
        }
    }
}
