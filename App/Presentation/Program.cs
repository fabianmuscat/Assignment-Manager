using Application.Interfaces;
using Application.Services;
using Data;
using Data.Interfaces;
using Data.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AssignmentsManager");
builder.Services.AddDbContext<PresentationIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddMvc();
builder.Services.AddSingleton(builder.Configuration);

builder.Services.AddDbContext<AssignmentsContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Student>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AssignmentsContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IModuleService, ModuleService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Assignments}/{action=Redirect}/{id?}");
app.MapRazorPages();

app.Run();