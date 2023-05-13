using Publicacion.DAL;
using Publicacion.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.BL
{
    public class ProductoBL
    {
        public void CargarPropiedadVirtualCategoria(List<Producto> pLista, Action<List<Categoria>> pAccion = null)
        {
            //Metodos para cargar los datos de la propiedad virtual de Categoria 
            if (pLista.Count > 0)
            {
                //Dictionary de Categoriaes
                //byte = Tipo de dasto de la llave primaria de Categoria
                //Categoria = clase partav guardar los datos de categorias
                Dictionary<int, Categoria> diccionarioCategorias = new Dictionary<int, Categoria>();

                //Buscar los categorias y cargarlos a los usuarios en su7 propiedaad virtual
                foreach (var obj in pLista)
                {
                    //Verificar si existe el Categoria en el diccionario
                    if (diccionarioCategorias.ContainsKey(obj.IdCategoria) == true)
                    {
                        //cargar propiedad virtual desde el diccionario de categorias
                        obj.Categoria = diccionarioCategorias[obj.IdCategoria];
                    }
                    else
                    {
                        //si el rol no existe en el diccionario, se busca en la base de datos y se agrega al diccionario
                        diccionarioCategorias.Add(obj.IdCategoria, CategoriaDAL.BuscarPorId(obj.IdCategoria));
                        //cargar propiedad virtual desde el diccionario de roles
                        obj.Categoria = diccionarioCategorias[obj.IdCategoria];
                    }
                }
                //accion auxiliar para sobrecargar otra propiedad  virtual dentro de la clase 
                if (pAccion != null && diccionarioCategorias.Count > 0)
                {
                    pAccion(diccionarioCategorias.Select(x => x.Value).ToList());
                }
            }

        }
    }
}
