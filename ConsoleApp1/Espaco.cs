public class Espaco
{
    public string Id { get; private set; }
    public int Capacidade { get; private set; }
    private Dictionary<Data, bool> datasReservadas = new Dictionary<Data, bool>();

    public Espaco(string id, int capacidade)
    {
        Id = id;
        Capacidade = capacidade;
    }

    public bool VerificarDisponibilidade(Data data)
    {
        return !datasReservadas.ContainsKey(data);
    }

    public void ReservarEspaco(Data data)
    {
        if (VerificarDisponibilidade(data))
        {
            datasReservadas.Add(data, true);
        }
        else
        {
            throw new InvalidOperationException("Espaço já está reservado para esta data.");
        }
    }
}
