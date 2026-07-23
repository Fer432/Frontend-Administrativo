namespace FrontendAdministrativo.Models;

// Billeteras
public class CrearBilleteraRequestDto
{
    public int UsuarioId { get; set; }
}
public class BilleteraResponseDto
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public decimal Saldo { get; set; }
    public DateTime FechaCreacion { get; set; }
}

// Predicciones
public class CrearPrediccionRequestDto
{
    public int UsuarioId { get; set; }
    public int PartidoId { get; set; }
    public DateTime FechaInicioPartido { get; set; }
    public string Pronostico { get; set; } = string.Empty; // LOCAL, EMPATE, VISITANTE
    public decimal Monto { get; set; }
}
public class PrediccionResponseDto
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int PartidoId { get; set; }
    public DateTime FechaInicioPartido { get; set; }
    public string Pronostico { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public decimal Cuota { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
}

// Transacciones
public class TransaccionResponseDto
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public decimal SaldoResultante { get; set; }
    public string? Referencia { get; set; }
    public DateTime Fecha { get; set; }
}

// Bono diario
public class EstadoBonoResponseDto
{
    public int UsuarioId { get; set; }
    public decimal Saldo { get; set; }
    public bool EnBancarrota { get; set; }
    public bool YaRecibioBonoHoy { get; set; }
    public DateOnly Fecha { get; set; }
}
public class BeneficiarioBonoDto
{
    public int UsuarioId { get; set; }
    public decimal SaldoNuevo { get; set; }
}

public class EjecutarBonoDiarioResponseDto
{
    public DateOnly Fecha { get; set; }
    public int CantidadBeneficiados { get; set; }
    public List<BeneficiarioBonoDto> Beneficiarios { get; set; } = new();
}