using Publicacion.EN;
using Publicacion.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.BL
{
    public class CategoriaBL
    {
        public int Guardar(Categoria pCategoria)
        {
            pCategoria.Estado = 1;
            return CategoriaDAL.Guardar(pCategoria);
        }

        public int Modificar(Categoria pCategoria)
        {
            pCategoria.Estado = 1;
            return CategoriaDAL.Modificar(pCategoria);
        }

        public int Eliminar(Categoria pCategoria)
        {
            return CategoriaDAL.Eliminar(pCategoria);
        }

        public Categoria BuscarPorId(int pId)
        {
            return CategoriaDAL.BuscarPorId(pId);
        }

        public List<Categoria> Buscar(Categoria pCategoria)
        {
            pCategoria.Estado = 1;
            return CategoriaDAL.Buscar(pCategoria);
        }
    }
}
