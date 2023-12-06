using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contratos
{
    public interface ISesionService
    {
        Empleado AutenticarDatos(Usuario usuario);
    }
}
