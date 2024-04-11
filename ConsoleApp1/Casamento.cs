public class Casamento
{
    public Data Data { get; private set; }
    public Espaco Espaco { get; private set; }
    public int NumeroDeConvidados { get; private set; }

    public Casamento(Data data, Espaco espaco, int numeroDeConvidados)
    {
        Data = data;
        Espaco = espaco;
        NumeroDeConvidados = numeroDeConvidados;
    }
}