using _18_MVC_Example.Mapping;
using Microsoft.EntityFrameworkCore;

namespace _18_MVC_Example.Models.Context
{

    /*
Kullanici, Ogrenci, Okul
 
Kullanici: KullaniciID,Adi,Soyadi, KullaniciAdi,Parola,Rolu
 
Ogrenci: OgrenciID,OgrenciAdi ,OgrenciSoyadi, OgrenciNo, OgrenciDogumTarihi, OgrenciSinifi, OgrenciAdresi, OgrenciVeliTel
 
Okul: OkulID, OkulAdi, OkulAdresi, OkulTelefonu, OkulEposta, OkulKurulusTarihi
 
 
Entities
Context
SeedData
Repositories(Abstract, Concrete)
Controller
View
 
*/
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StudentMapping().Configure(modelBuilder.Entity<Student>());
            base.OnModelCreating(modelBuilder);
        }



    }
}
