using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models;
using Microsoft.AspNetCore.DataProtection;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
   .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHttpClient();

var keysFolder = Path.Combine(Directory.GetCurrentDirectory(), "DataProtectionKeys");
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
    .SetApplicationName("NovelNookBookStore");

//only use this block of code for testing, bc the API is rejecting no matter what for- remote cert invalid so catch is running everytime
builder.Services.AddHttpClient("quotable")
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});


//neededfor shopping cart
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await IdentityConfig.CreateAdminUserAsync(scope.ServiceProvider); ;
}

app.MapControllerRoute(
    name: "bookdetails",
    pattern: "books/{id}/{slug?}",
    defaults: new
    {
        controller = "Book",
        action = "Details"
    });


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    


app.MapRazorPages();

app.Run();
