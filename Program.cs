using Microsoft.EntityFrameworkCore;
using ProyectoGym.Data;
using ProyectoGym.Business;
using ProyectoGym.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<EntrenadorRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<EntrenadorService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<RutinaRepository>();
builder.Services.AddScoped<RutinaService>();
builder.Services.AddScoped<EjercicioRepository>();
builder.Services.AddScoped<EjercicioService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
