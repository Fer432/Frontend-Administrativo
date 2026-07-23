using System.Net.Http.Headers;
using System.Net.Http.Json;
using FrontendAdministrativo.Models;

namespace FrontendAdministrativo.Services;

public class EstadisticasApiService
{
    private readonly HttpClient _http;
    private readonly SesionAdmin _sesion;

    public EstadisticasApiService(IHttpClientFactory factory, SesionAdmin sesion)
    {
        _http = factory.CreateClient("EstadisticasApi");
        _sesion = sesion;
    }

    private void Autenticar()
    {
        _http.DefaultRequestHeaders.Authorization =
            string.IsNullOrEmpty(_sesion.Token)
                ? null
                : new AuthenticationHeaderValue("Bearer", _sesion.Token);
    }

    // --- Partidos ---
    public async Task<List<PartidoDto>> ListarPartidos()
        => await _http.GetFromJsonAsync<List<PartidoDto>>("partidos") ?? new();

    public async Task<List<PartidoDto>> ListarPorSeleccion(int idSeleccion)
        => await _http.GetFromJsonAsync<List<PartidoDto>>($"partidos/seleccion/{idSeleccion}/detallado") ?? new();

    // --- Login ---
    public async Task<LoginResponseDto?> Login(string email, string password)
    {
        var body = new LoginRequestDto { Email = email, Password = password };
        var resp = await _http.PostAsJsonAsync("auth/login", body);
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<LoginResponseDto>();
    }

    // --- Selecciones ---
    public async Task<List<SeleccionDto>> ListarSelecciones()
        => await _http.GetFromJsonAsync<List<SeleccionDto>>("selecciones") ?? new();

    public async Task<(bool ok, string? error)> CrearSeleccion(SeleccionEntityDto s)
    {
        Autenticar();
        var resp = await _http.PostAsJsonAsync("selecciones", s);
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }

    public async Task<(bool ok, string? error)> ActualizarSeleccion(SeleccionEntityDto s)
    {
        Autenticar();
        var resp = await _http.PutAsJsonAsync("selecciones", s);
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }

    public async Task<(bool ok, string? error)> EliminarSeleccion(int id)
    {
        Autenticar();
        var resp = await _http.DeleteAsync($"selecciones/{id}");
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }
    public async Task<List<UsuarioDto>> ListarUsuarios()
    {
        Autenticar();
        return await _http.GetFromJsonAsync<List<UsuarioDto>>("usuarios") ?? new();
    }

    public async Task<(bool ok, string? error)> CambiarRol(int idUsuario, string rol)
    {
        Autenticar();
        var resp = await _http.PutAsJsonAsync($"usuarios/{idUsuario}/rol",
            new CambiarRolRequestDto { Rol = rol });
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }
    public async Task<List<SedeDto>> ListarSedes()
    => await _http.GetFromJsonAsync<List<SedeDto>>("sedes") ?? new();

    public async Task<(bool ok, string? error)> CrearPartido(PartidoEntityDto p)
    {
        Autenticar();
        var resp = await _http.PostAsJsonAsync("partidos", p);
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }

    public async Task<(bool ok, string? error)> ActualizarPartido(PartidoEntityDto p)
    {
        Autenticar();
        var resp = await _http.PutAsJsonAsync("partidos", p);
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }

    public async Task<(bool ok, string? error)> EliminarPartido(int id)
    {
        Autenticar();
        var resp = await _http.DeleteAsync($"partidos/{id}");
        return resp.IsSuccessStatusCode ? (true, null) : (false, await resp.Content.ReadAsStringAsync());
    }
}