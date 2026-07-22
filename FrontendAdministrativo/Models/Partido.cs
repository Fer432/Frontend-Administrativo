namespace FrontendAdministrativo.Models;

public class Partido
{
    public int Id { get; set; }
    public string Local { get; set; } = string.Empty;
    public string Visitante { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Sede { get; set; } = string.Empty;
    public int GolesLocal { get; set; }
    public int GolesVisitante { get; set; }
    public string Estado { get; set; } = string.Empty;
}
