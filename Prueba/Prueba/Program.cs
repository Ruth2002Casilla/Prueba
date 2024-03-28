using Connection.DAL;
using Microsoft.EntityFrameworkCore;
using Prueba.Components;
using Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Connection.DAL.Context>(options =>
    options.UseSqlite(connectionString, builder =>
        builder.MigrationsAssembly(typeof(Context).Assembly.FullName)));


//Services
builder.Services.AddScoped<AsociacionService>();
builder.Services.AddScoped<BloqueService>();
builder.Services.AddScoped<CajaService>();
builder.Services.AddScoped<DetalleCajaService>();
builder.Services.AddScoped<DetalleReganteService>();
builder.Services.AddScoped<ParametrosOperacionalesService>();
builder.Services.AddScoped<ParcelaService>();
builder.Services.AddScoped<ReganteService>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
