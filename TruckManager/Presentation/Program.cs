using Microsoft.EntityFrameworkCore;
using TruckManager.Application.Interfaces;
using TruckManager.Application.Mapping;
using TruckManager.Application.Services;
using TruckManager.Domain.Interfaces.Repository;
using TruckManager.Domain.Interfaces.Services;
using TruckManager.Domain.Services;
using TruckManager.Infrastructure.Context;
using TruckManager.Infrastructure.Repository;
using TruckManager.Presentation.Seed;

var builder = WebApplication.CreateBuilder(args);

string connetionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connetionString == null)
{
    throw new Exception("connetionString não configurada.");
}

var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddDbContext<TruckManagerContext>(o => o.UseSqlServer(connetionString));

//Aplicação
services.AddScoped(typeof(IAppBase<,>), typeof(ServiceAppBase<,>));
services.AddScoped<TruckApp>();
services.AddScoped<ModeloApp>();

//Domínio
services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
services.AddScoped<ITruckService, TruckService>();
services.AddScoped<IModeloService, ModeloService>();

//Repositorio
services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
services.AddScoped<ITruckRepository, TruckRepository>();
services.AddScoped<IModeloRepository, ModeloRepository>();

services.AddSwaggerGen();
services.AddAutoMapper(x => x.AddProfile(new TruckMapping()));
services.AddAutoMapper(x => x.AddProfile(new ModeloMapping()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

try
{
    app.MigrateDbContext<TruckManagerContext>((context, services) => { context.SeedAsync(true).Wait(); });
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

app.Run();
