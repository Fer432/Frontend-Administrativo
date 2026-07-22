namespace FrontendAdministrativo.Models;

public class RankingItemDto
{
    public int UsuarioId { get; set; }
    public decimal Saldo { get; set; }
    public int Aciertos { get; set; }
    public int TotalPredicciones { get; set; }
}