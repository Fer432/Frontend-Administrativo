using System.Net.Http.Json;
using FrontendAdministrativo.Models;

namespace FrontendAdministrativo.Services;

public class EstadisticasApiService
{
    private readonly HttpClient _http;

    public EstadisticasApiService(IHttpClientFactory factory)
        => _http = factory.CreateClient("EstadisticasApi");

    public async Task<List<PartidoDto>> ListarPartidos()
        => await _http.GetFromJsonAsync<List<PartidoDto>>("partidos") ?? new();

    public async Task<List<PartidoDto>> ListarPorSeleccion(int idSeleccion)
        => await _http.GetFromJsonAsync<List<PartidoDto>>(
               $"partidos/seleccion/{idSeleccion}/detallado") ?? new();
    public async Task<LoginResponseDto?> Login(string email, string password)
    {
        var body = new LoginRequestDto { Email = email, Password = password };
        var resp = await _http.PostAsJsonAsync("auth/login", body);
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<LoginResponseDto>();
    }
}