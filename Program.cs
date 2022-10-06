using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using ToDo_Aplication.Data;
using ToDo_Aplication.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>
 (options => options.UseSqlServer("Data Source=LAPTOP-LT459BR5\\SQLEXPRESS2;Initial Catalog=DB_Todo;Integrated Security=True"));
 builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=Index}/{id?}");

app.Run();
