using _18_MVC_Example.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _18_MVC_Example.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                StudentDbContext context = serviceScope.ServiceProvider.GetService<StudentDbContext>();
                context.Database.Migrate();

                if (!context.Students.Any()) //Products tablosu boşsa burası çalışacak.
                {
                    context.Students.AddRange(
                        new Student() 
                        { 
                            StudentFirstName = "Ali", 
                            StudentLastName = "Veli", 
                            StudentAddress = "Ankara", 
                            StudentClass="3C",
                            StudentBirthday = new DateTime(2014,10,10),
                            StudentPhone="123456",
                            StudentNo=123 ,
                            School = new School() 
                            { 
                                SchoolName="Atatürk ilköğretim okulu",
                                SchoolAddress="Çankaya",
                                SchoolEmail="info@aio.com",
                                SchoolFoundingDate =new DateTime(1993,10,29),
                                SchoolPhone = "123456"
                        } },
                        new Student()
                        {
                            StudentFirstName = "Mehmet",
                            StudentLastName = "Yılmaz",
                            StudentAddress = "İstanbul",
                            StudentClass = "4C",
                            StudentBirthday = new DateTime(2014, 10, 10),
                            StudentPhone = "123456",
                            StudentNo = 123,
                            School = new School()
                            {
                                SchoolName = "Sabiha Gökçen ilköğretim okulu",
                                SchoolAddress = "Üsküdar",
                                SchoolEmail = "info@sio.com",
                                SchoolFoundingDate = new DateTime(1993, 10, 29),
                                SchoolPhone = "123456"
                            }
                        },
                        new Student()
                        {
                            StudentFirstName = "Berkay",
                            StudentLastName = "Gündüz",
                            StudentAddress = "İzmir",
                            StudentClass = "5A",
                            StudentBirthday = new DateTime(2014, 10, 10),
                            StudentPhone = "789456",
                            StudentNo = 123,
                            School = new School()
                            {
                                SchoolName = "Dokuz Eylül ilköğretim okulu",
                                SchoolAddress = "Bornova",
                                SchoolEmail = "info@dio.com",
                                SchoolFoundingDate = new DateTime(1993, 10, 29),
                                SchoolPhone = "454648"
                            }
                        }

                        );

                    context.Users.Add(new User() { FirstName = "Volkan", LastName = "Cavusoglu", Password = "123", Username = "volkan", UserRole = "admin" });

                }
                context.SaveChanges();





            }
        }
    }
}
