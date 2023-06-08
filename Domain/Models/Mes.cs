namespace Domain.Models
{
    public class Mes
    {
        public int MesId { get; set; }
        public string Nome { get; set;}
        public virtual ICollection<Aluguel> Alugueis { get; set;}
        public virtual ICollection<HistoricoRecurso> HistoricoRecursos { get; set;}

    }
}
