using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int NumeroIdentificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Empresa { get; set; }
        public string? Pais { get; set; }
        public int Telefono { get; set; }
        public string? Mail { get; set; }

        // public List<Proyecto>? Proyectos { get; set; }
    }
}
