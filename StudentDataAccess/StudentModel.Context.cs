﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_a06c09_studentdbEntities : DbContext
    {
        public db_a06c09_studentdbEntities()
            : base("name=db_a06c09_studentdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ExamDetail> ExamDetails { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Result> Results { get; set; }
    }
}