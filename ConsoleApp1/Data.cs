using System;

public class Data
{
    public int Dia { get; private set; }
    public int Mes { get; private set; }
    public int Ano { get; private set; }

    public Data(int dia, int mes, int ano)
    {
        Dia = dia;
        Mes = mes;
        Ano = ano;
    }
}
