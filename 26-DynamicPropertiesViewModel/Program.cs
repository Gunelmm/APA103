var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    "Corporative",
    "corporative-satislar", 
    new {controller="Home", action="corporativesales"}
    );

app.Run();
