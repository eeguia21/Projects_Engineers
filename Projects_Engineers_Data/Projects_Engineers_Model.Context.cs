﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects_Engineers_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Projects_Engineers : DbContext
    {
        public Projects_Engineers()
            : base("name=Projects_Engineers")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PE_CApplicationRole> PE_CApplicationRole { get; set; }
        public virtual DbSet<PE_CCity> PE_CCity { get; set; }
        public virtual DbSet<PE_CCountry> PE_CCountry { get; set; }
        public virtual DbSet<PE_CDepartment> PE_CDepartment { get; set; }
        public virtual DbSet<PE_CJobTitle> PE_CJobTitle { get; set; }
        public virtual DbSet<PE_CState> PE_CState { get; set; }
        public virtual DbSet<PE_User> PE_User { get; set; }
        public virtual DbSet<PE_UserLocation> PE_UserLocation { get; set; }
    }
}
