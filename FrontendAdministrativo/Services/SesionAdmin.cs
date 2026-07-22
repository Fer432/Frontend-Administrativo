namespace FrontendAdministrativo.Services;

public class SesionAdmin
{
    public string? Token { get; private set; }
    public string? Rol { get; private set; }

    public bool EstaAutenticado => !string.IsNullOrEmpty(Token);

    public void Guardar(string token, string rol)
    {
        Token = token;
        Rol = rol;
    }

    public void Cerrar()
    {
        Token = null;
        Rol = null;
    }
}