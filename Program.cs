using Microsoft.EntityFrameworkCore;
using ProyectoGym.Data;
using ProyectoGym.Business;
using ProyectoGym.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (tu setup original de Razor Components)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- AGREGADO: DI para repository / services / auth ---
builder.Services.AddScoped<EntrenadorRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<EntrenadorService>();
builder.Services.AddScoped<ClienteService>();

var app = builder.Build();

// --- AGREGADO: crear la DB si no existe (útil en desarrollo) ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
