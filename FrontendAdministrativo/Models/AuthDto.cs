namespace FrontendAdministrativo.Models;

public class LoginRequestDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public DateTime Expiracion { get; set; }
}