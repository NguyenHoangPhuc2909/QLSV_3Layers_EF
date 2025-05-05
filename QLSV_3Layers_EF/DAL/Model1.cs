using System;
using System.Data.Entity;
using System.Linq;
using QLSV_3Layers_EF.DTO;
namespace QLSV_3Layers_EF.DAL
{
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLSV_3Layers_EF.DAL.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public DbSet<Nguoidung> Nguoidungs { get; set; }
        public DbSet<LSH> LSHs { get; set; }
        public DbSet<SV> SVs { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public Model1()
            : base("name=Model1")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Xác định rõ mối quan hệ Nguoidung-SV
            modelBuilder.Entity<Nguoidung>()
                .HasOptional(u => u.SinhVien)
                .WithRequired(s => s.Nguoidung);


            base.OnModelCreating(modelBuilder);
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }


}