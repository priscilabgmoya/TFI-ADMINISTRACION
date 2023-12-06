using Datos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Negocio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class SesionService : ISesionService
    {
        private DatosContexto _contexto = new DatosContexto();

        public Empleado AutenticarDatos(Usuario usuario)
        {
            var empleadosBD = _contexto.Empleados
                .Include(emp => emp.Usuario)
                .Include(user => user.Puesto)
                .ToList();
            foreach (var emp in empleadosBD)
            {
                if (emp.Usuario.NombreDeUsuario.Equals(usuario.NombreDeUsuario) &&
                    emp.Usuario.Contrasena.Equals(usuario.Contrasena))
                {
                    return emp;
                }
            }
            return null;
        }
    }
}
