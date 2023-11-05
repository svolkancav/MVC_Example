using _18_MVC_Example.Models;
using _18_MVC_Example.Models.Context;
using _18_MVC_Example.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromSeconds(30)); 


builder.Services.AddDbContext<StudentDbContext>(opt => opt.UseSqlServer("Server=DESKTOP-HF14TQL;Database=StudentRepoDb;Trusted_Connection=True"));

builder.Services.AddTransient<IStudentRepositories, EFStudentRepositories>();

builder.Services.AddTransient<ISchoolRepositories, EFSchoolRepositories>();

builder.Services.AddTransient<IUserRepositories, EFUserRepositories>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

SeedData.Seed(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
