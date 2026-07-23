namespace FrontendAdministrativo.Models;

public class UsuarioDto
{
    public int IdUsuario { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
}

public class CambiarRolRequestDto
{
    public string Rol { get; set; } = string.Empty;
}