using Persistence;
using Server.Authentication;
using Server.Middleware;
using Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Shared.Birds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBirdServices();

// Fluentvalidation
builder.Services.AddValidatorsFromAssemblyContaining<BirdDto.Spot.Validator>();
builder.Services.AddFluentValidationAutoValidation();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("SqlServer")
    );
});

// (Fake) Authentication
builder.Services.AddAuthentication("Fake Authentication")
                .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>("Fake Authentication", null);


builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext!.User);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers().RequireAuthorization();
app.MapFallbackToFile("index.html");


using (var scope = app.Services.CreateScope())
{ // Require a DbContext from the service provider and seed the database.
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    FakeSeeder seeder = new(dbContext);
    seeder.Seed();
}

app.Run();
