using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? NombreDeUsuario { get; set; }
        public string? Contrasena { get; set; }
    }
}
