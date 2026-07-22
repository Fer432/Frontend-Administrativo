using FrontendAdministrativo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("EstadisticasApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["EstadisticasApi:BaseUrl"]!);
});
builder.Services.AddScoped<FrontendAdministrativo.Services.EstadisticasApiService>();
builder.Services.AddHttpClient("UtnGolCoinApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UtnGolCoinApi:BaseUrl"]!);
});
builder.Services.AddScoped<FrontendAdministrativo.Services.UtnGolCoinApiService>();

builder.Services.AddSingleton<FrontendAdministrativo.Services.SesionAdmin>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
