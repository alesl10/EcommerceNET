using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProyectoPrueba.UI;
using Blazored.LocalStorage;
using Blazored.Toast;
using ProyectoPrueba.UI.Servicios.Contrato;
using ProyectoPrueba.UI.Servicios.Implementacion;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5127/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

// Servicios
builder.Services.AddScoped<ICarritoServicio, CarritoServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();

await builder.Build().RunAsync();
