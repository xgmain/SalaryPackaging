using SalaryPackaging.Middleware;
using SalaryPackaging.Services;
using SalaryPackaging.Services.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Register Strategies with DI
builder.Services.AddScoped<ISalaryPackagingStrategy, CorporateSalaryPackagingStrategy>();
builder.Services.AddScoped<ISalaryPackagingStrategy, HospitalSalaryPackagingStrategy>();
builder.Services.AddScoped<ISalaryPackagingStrategy, PBISalaryPackagingStrategy>();

// Register services with DI
builder.Services.AddScoped<ISalaryPackagingService, SalaryPackagingService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<RedirectHomePageMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
