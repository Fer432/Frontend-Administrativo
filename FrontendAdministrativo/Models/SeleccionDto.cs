namespace FrontendAdministrativo.Models;

// Lo que DEVUELVE el GET
public class SeleccionDto
{
    public int IdSeleccion { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Confederacion { get; set; } = string.Empty;
    public string? Grupo { get; set; }
}

// Lo que ESPERA el POST/PUT (entidad)
public class GrupoRefDto
{
    public int IdGrupo { get; set; }
}

public class SeleccionEntityDto
{
    public int IdSeleccion { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Confederacion { get; set; } = string.Empty;
    public GrupoRefDto? Grupo { get; set; }
}