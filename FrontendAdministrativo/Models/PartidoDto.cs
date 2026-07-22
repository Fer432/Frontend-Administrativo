namespace FrontendAdministrativo.Models;

public class PartidoDto
{
    public int IdPartido { get; set; }
    public string SeleccionLocal { get; set; } = string.Empty;
    public string SeleccionVisitante { get; set; } = string.Empty;
    public string Sede { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Fase { get; set; } = string.Empty;
}