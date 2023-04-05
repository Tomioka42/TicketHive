using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TicketHive.Ui.Data;
using TicketHive.Server.Data;
using TicketHive.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TicketHiveDbConnection") ?? throw new InvalidOperationException("Connection string 'TicketHiveDbConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TicketHive.Ui")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var connectionString2 = builder.Configuration.GetConnectionString("TicketHiveIdentityDbConnection") ?? throw new InvalidOperationException("Connection string 'TicketHiveIdentityDbConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString2));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
    // Hämtar instanserna från DI-containern
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
    var signInManager = serviceProvider.GetRequiredService<SignInManager<UserModel>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //Gör detta för att säkerhetsställa att databasen är skapad, annars skapas den
    context.Database.Migrate();

    UserModel? adminUser = signInManager.UserManager.FindByNameAsync("admin").GetAwaiter().GetResult();

    // Om vi inte hittar en användare med användarnamet "admin"...
    if (adminUser == null)
    {
        adminUser = new()
        {
            Username = "admin"
        };


        signInManager.UserManager.CreateAsync(adminUser, "Password1234!");
    }

    IdentityRole? adminRole = roleManager.FindByNameAsync("Admin").GetAwaiter().GetResult();

    if (adminRole == null)
    {
        adminRole = new()
        {
            Name = "Admin"
        };

        roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
    }

    signInManager.UserManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();

}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
