using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.EN
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Img { get; set; }
        public byte Estado { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string NombreCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
