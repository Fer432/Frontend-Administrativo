using System.Net.Http.Json;
using FrontendAdministrativo.Models;

namespace FrontendAdministrativo.Services;

public class UtnGolCoinApiService
{
    private readonly HttpClient _http;

    public UtnGolCoinApiService(IHttpClientFactory factory)
        => _http = factory.CreateClient("UtnGolCoinApi");

    public async Task<List<RankingItemDto>> ObtenerRanking(int? top = null)
    {
        var url = top.HasValue ? $"ranking?top={top}" : "ranking";
        return await _http.GetFromJsonAsync<List<RankingItemDto>>(url) ?? new();
    }

    public async Task<MonedasCirculacionDto?> ObtenerMonedasCirculacion()
        => await _http.GetFromJsonAsync<MonedasCirculacionDto>("reportes/monedas-circulacion");

    public async Task<List<PartidoApostadoDto>> ObtenerPartidosMasApostados(int? top = null)
    {
        var url = top.HasValue ? $"reportes/partidos-mas-apostados?top={top}" : "reportes/partidos-mas-apostados";
        return await _http.GetFromJsonAsync<List<PartidoApostadoDto>>(url) ?? new();
    }
    // --- Billeteras ---
    public async Task<BilleteraResponseDto?> CrearBilletera(int usuarioId)
    {
        var resp = await _http.PostAsJsonAsync("billeteras",
            new CrearBilleteraRequestDto { UsuarioId = usuarioId });
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<BilleteraResponseDto>();
    }

    public async Task<BilleteraResponseDto?> ObtenerBilletera(int usuarioId)
        => await _http.GetFromJsonAsync<BilleteraResponseDto>($"billeteras/{usuarioId}");

    // --- Predicciones ---
    public async Task<(bool ok, string? error)> CrearPrediccion(CrearPrediccionRequestDto req)
    {
        var resp = await _http.PostAsJsonAsync("predicciones", req);
        if (resp.IsSuccessStatusCode) return (true, null);
        var texto = await resp.Content.ReadAsStringAsync();
        return (false, texto);
    }
    public async Task<EjecutarBonoDiarioResponseDto?> EjecutarBonoDiario()
    {
        var resp = await _http.PostAsJsonAsync("bonos/ejecutar-bono-diario", new { });
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<EjecutarBonoDiarioResponseDto>();
    }
    public async Task<List<PrediccionResponseDto>> ObtenerPredicciones(int usuarioId)
        => await _http.GetFromJsonAsync<List<PrediccionResponseDto>>($"predicciones/usuario/{usuarioId}") ?? new();

    // --- Transacciones ---
    public async Task<List<TransaccionResponseDto>> ObtenerTransacciones(int usuarioId)
        => await _http.GetFromJsonAsync<List<TransaccionResponseDto>>($"transacciones/usuario/{usuarioId}") ?? new();

    // --- Bono diario ---
    public async Task<EstadoBonoResponseDto?> ObtenerEstadoBono(int usuarioId)
        => await _http.GetFromJsonAsync<EstadoBonoResponseDto>($"bonos/estado/{usuarioId}");
}