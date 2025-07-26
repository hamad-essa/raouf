using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasheel.BLL.Intrefaces;
using Tasheel.BLL.Mapper;
using Tasheel.BLL.Repository;
using Tasheel.DAL.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Tasheel.DAL.Extend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("TasheelConnection");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));
//AddAutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));



//Scoped
builder.Services.AddScoped<Iacademicyear, AcademicYearRepo>();
builder.Services.AddScoped<Inationality, NationalityRepo>();
builder.Services.AddScoped<IStudent, StudentRepo>();
builder.Services.AddScoped<ICard, CardRepo>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<MyContext>()
.AddDefaultTokenProviders(); // Crucial for Identity features

// Configure the Application Cookie directly using `ConfigureApplicationCookie`
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.AccessDeniedPath = new PathString("/Account/Login");
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

// **COMMENT OUT OR REMOVE THIS LINE FOR TESTING**
// builder.Services.AddAuthentication().AddIdentityCookies(o =>
// {
//     o.TwoFactorRememberMeCookie.Configure(a => a.Cookie.Expiration = new TimeSpan(10, 00, 00, 00));
// });


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
var services = scope.ServiceProvider;
await SeedRolesAsync(services);
}

// Define the method below
static async Task SeedRolesAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Parent" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

}
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Account}/{action=Login}/{id?}");

app.Run();