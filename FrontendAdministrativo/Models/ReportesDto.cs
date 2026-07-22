namespace FrontendAdministrativo.Models;

public class MonedasCirculacionDto
{
    public decimal TotalMonedasEnCirculacion { get; set; }
    public int CantidadBilleteras { get; set; }
    public decimal TotalPagadoEnPremios { get; set; }
}

public class PartidoApostadoDto
{
    public int PartidoId { get; set; }
    public int CantidadPredicciones { get; set; }
}