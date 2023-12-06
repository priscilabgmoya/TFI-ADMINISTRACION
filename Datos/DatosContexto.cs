using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosContexto : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Sueldo> Sueldos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public DatosContexto()
        {
        }
        public DatosContexto(DbContextOptions<DatosContexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=.\SQLExpress;Database=AdministracionDeRecursos;Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.HasKey(p => p.ClienteId);
                cliente.Property(p => p.Nombre).IsRequired();
                cliente.Property(p => p.Apellido).IsRequired();
            });
            modelBuilder.Entity<Empleado>(empleado =>
            {
                empleado.HasKey(p => p.Legajo);
                empleado.Property(p => p.Nombre).IsRequired();
                empleado.Property(p => p.Apellido).IsRequired();
                empleado.Property(p => p.FechaDeNacimiento).IsRequired();
                empleado.Property(p => p.CUIT).IsRequired();
            });
            modelBuilder.Entity<Equipo>(equipo =>
            {
                equipo.HasKey(p => p.EquipoId);
            });
            modelBuilder.Entity<Permiso>(permiso =>
            {
                permiso.HasKey(p => p.OperacionId);
            });
            modelBuilder.Entity<Proyecto>(proyecto =>
            {
                proyecto.HasKey(p => p.ProyectoId);
            });
            modelBuilder.Entity<Puesto>(puesto =>
            {
                puesto.HasKey(p => p.PuestoId);
            });

            modelBuilder.Entity<Sueldo>(sueldo =>
            {
                sueldo.HasKey(p => p.SueldoId);
            });
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.HasKey(p => p.TareaId);
            });
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.HasKey(p => p.UsuarioId);
                usuario.Property(p => p.NombreDeUsuario).IsRequired();
                usuario.Property(p => p.Contrasena).IsRequired();
            });
        }

  
    }
}
