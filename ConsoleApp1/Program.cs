class Program
{
    static void Main(string[] args)
    {
        List<Espaco> espacos = new List<Espaco>
        {
            new Espaco("A", 100),
            new Espaco("B", 100),
            new Espaco("C", 100),
            new Espaco("D", 100),
            new Espaco("E", 200),
            new Espaco("F", 200),
            new Espaco("G", 50),
            new Espaco("H", 500)
        };

        AgendadorDeCasamento agendador = new AgendadorDeCasamento(espacos);
        List<Casamento> casamentosAgendados = new List<Casamento>();

        bool continuar = true;

        while (continuar)
        {
            try
            {
                Console.WriteLine("Por favor, insira a quantidade de convidados esperados para o casamento: ");
                int numeroDeConvidados = int.Parse(Console.ReadLine());

                Casamento casamento = agendador.AgendarCasamento(numeroDeConvidados);
                casamentosAgendados.Add(casamento);

                Console.WriteLine($"Casamento agendado no espaço {casamento.Espaco.Id} para {casamento.Data.Dia}/{casamento.Data.Mes}/{casamento.Data.Ano}");

                Console.WriteLine("Deseja agendar outro casamento? (S/N)");
                string resposta = Console.ReadLine();
                continuar = resposta.ToUpper() == "S";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível agendar o casamento: " + ex.Message);
            }
        }

        Console.WriteLine("Casamentos agendados:");
        foreach (var casamento in casamentosAgendados)
        {
            Console.WriteLine($"Espaço: {casamento.Espaco.Id}, Data: {casamento.Data.Dia}/{casamento.Data.Mes}/{casamento.Data.Ano}, Convidados: {casamento.NumeroDeConvidados}");
        }

        Console.WriteLine("Obrigado por utilizar o sistema de agendamento de casamentos.");
        Console.ReadKey();
    }
}