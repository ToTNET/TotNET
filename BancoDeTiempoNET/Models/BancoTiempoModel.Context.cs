﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancoDeTiempoNET.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BancoDeTiempoEntities : DbContext
    {
        public BancoDeTiempoEntities()
            : base("name=BancoDeTiempoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Notificacion> Notificacion { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}