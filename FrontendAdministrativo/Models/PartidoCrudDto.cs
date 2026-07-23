namespace FrontendAdministrativo.Models;

public class SeleccionRefDto
{
    public int IdSeleccion { get; set; }
}

public class SedeRefDto
{
    public int IdSede { get; set; }
}

public class SedeDto
{
    public int IdSede { get; set; }
    public string Ciudad { get; set; } = string.Empty;
    public string Estadio { get; set; } = string.Empty;
}

// Lo que espera POST/PUT (entidad Partido)
public class PartidoEntityDto
{
    public int IdPartido { get; set; }
    public SeleccionRefDto? SeleccionLocal { get; set; }
    public SeleccionRefDto? SeleccionVisitante { get; set; }
    public SedeRefDto? Sede { get; set; }
    public DateTime Fecha { get; set; }
    public string Fase { get; set; } = "Grupo"; // Grupo, Octavos, Cuartos, Semifinal, Final
}