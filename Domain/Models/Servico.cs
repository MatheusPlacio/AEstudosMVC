namespace Domain.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public StatusServico Status { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public ICollection<ServicoPredio> ServicoPredios { get; set; }
    }

    public enum StatusServico
    {
        Pendente,
        Recusado,
        Aceito
    }
}
