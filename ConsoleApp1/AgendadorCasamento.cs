public class AgendadorDeCasamento
{
    private List<Espaco> espacos;
    private List<Casamento> casamentosAgendados = new List<Casamento>();

    public AgendadorDeCasamento(List<Espaco> espacos)
    {
        this.espacos = espacos;
    }

    private Data EncontrarProximaDataDisponivel()
    {
        DateTime dataInicial = DateTime.Today.AddDays(30);
        while (dataInicial.DayOfWeek != DayOfWeek.Friday && dataInicial.DayOfWeek != DayOfWeek.Saturday)
        {
            dataInicial = dataInicial.AddDays(1);
        }
        return new Data(dataInicial.Day, dataInicial.Month, dataInicial.Year);
    }

    public Casamento AgendarCasamento(int numeroDeConvidados)
    {
        var dataParaAgendamento = EncontrarProximaDataDisponivel();

        var espacosOrdenados = espacos.OrderBy(e => e.Capacidade);

        var espacoDisponivel = espacosOrdenados.FirstOrDefault(e => e.Capacidade >= numeroDeConvidados && e.VerificarDisponibilidade(dataParaAgendamento) && !EspacoReservado(e));

        if (espacoDisponivel != null)
        {
            espacoDisponivel.ReservarEspaco(dataParaAgendamento);
            var casamento = new Casamento(dataParaAgendamento, espacoDisponivel, numeroDeConvidados);
            casamentosAgendados.Add(casamento);
            return casamento;
        }
        else
        {
            throw new Exception("Não há espaços disponíveis para a quantidade de convidados na data mais próxima.");
        }
    }

    private bool EspacoReservado(Espaco espaco)
    {
        return casamentosAgendados.Any(c => c.Espaco == espaco);
    }
}
