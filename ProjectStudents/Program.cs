using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Concrete;
using ProjectStudents.Services.Interfaces;
using ProjectStudents.Services.Repository.Concrete;
using ProjectStudents.Services.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDisciplineRepository, DisciplineRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUserBaseRepository, UserBaseRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ILearnRepository, LearnRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IDisciplineService, DisciplineService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILearnService,  LearnService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Context>(); builder.Services.AddDbContext<Context>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectStudents")));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
    //options.SignIn.RequireConfirmedEmail = true;
});

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
