using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacion.EN
{
    public class Usuario
    {
        public int Id { get; set; }
        public byte IdRol { get; set; }
        public string Nombre { get; set; }

        public string Correo { get; set; }
        public string Clave { get; set; }
        public byte Estado { get; set; }

        //Propiedades Virtuales
        public virtual Rol Rol { get; set; }
    }
}
