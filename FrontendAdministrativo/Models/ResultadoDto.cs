namespace FrontendAdministrativo.Models;

public class ResultadoDto
{
    public PartidoRef Partido { get; set; } = new();
    public int GolesLocal { get; set; }
    public int GolesVisitante { get; set; }
}

public class PartidoRef
{
    public int IdPartido { get; set; }
}