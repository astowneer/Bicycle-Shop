using BicycleApplication.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.ConfigureRepositoryContext();
builder.Services.ConfigureBicycleServiceManager();
//builder.Services.ConfigureMountainServiceManager();
//builder.Services.ConfigureRepositoryBase();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bicycle}/{action=Index}/{id?}");

app.Run();

