namespace Diplom_Chikushev.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Id_client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.Company_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Manager)
                .HasForeignKey(e => e.id_manager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.Id_material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.Person_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Manager)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.Id_person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Services>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Services)
                .HasForeignKey(e => e.Id_service)
                .WillCascadeOnDelete(false);
        }
    }
}
