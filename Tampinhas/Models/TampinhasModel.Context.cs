﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace Tampinhas.Models
{
    public partial class TampinhasEntities : DbContext
    {
        public TampinhasEntities()
            : this(false) { }
    
        public TampinhasEntities(bool proxyCreationEnabled)	    
            : base("name=TampinhasEntities")
        {
            this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    
        public TampinhasEntities(string connectionString)
          : this(connectionString, false) { }
    
        public TampinhasEntities(string connectionString, bool proxyCreationEnabled)
            : base(connectionString)
        {
            this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }	
    
        public ObjectContext ObjectContext
        {
          get { return ((IObjectContextAdapter)this).ObjectContext; }
        }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    	
        public DbSet<User> UserSet { get; set; }
        public DbSet<Project> ProjectSet { get; set; }
        public DbSet<Organization> OrganizationSet { get; set; }
        public DbSet<Place> PlaceSet { get; set; }
        public DbSet<StatusType> StatusTypeSet { get; set; }
        public DbSet<ProjectComment> ProjectCommentSet { get; set; }
        public DbSet<ProjectStatusChange> ProjectStatusChangeSet { get; set; }
    }
}
