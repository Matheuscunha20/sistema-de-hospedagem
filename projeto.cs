using System;
using System.Collections.Generic;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

public class Suite
{
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite SuiteReservada { get; set; }
    public int DiasReservados { get; set; }

    public Reserva(int diasReservados)
    {
        Hospedes = new List<Pessoa>();
        DiasReservados = diasReservados;
    }

    public void CadastrarSuite(Suite suite)
    {
        SuiteReservada = suite;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count <= SuiteReservada.Capacidade)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
        }
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valorTotal = DiasReservados * SuiteReservada.ValorDiaria;
        if (DiasReservados > 10)
        {
            valorTotal *= 0.90m; // Aplica o desconto de 10%
        }
        return valorTotal;
    }
}

class Program
{
    static void Main()
    {
        // Criação dos hóspedes
        Pessoa hospede1 = new Pessoa("João", 30);
        Pessoa hospede2 = new Pessoa("Maria", 28);
        List<Pessoa> listaHospedes = new List<Pessoa> { hospede1, hospede2 };

        // Criação da suíte
        Suite suite = new Suite("Premium", 2, 200m);

        // Criação da reserva para 12 dias
        Reserva reserva = new Reserva(12);

        // Cadastrar suíte na reserva
        reserva.CadastrarSuite(suite);

        // Cadastrar hóspedes na reserva
        reserva.CadastrarHospedes(listaHospedes);

        // Exibir a quantidade de hóspedes
        Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");

        // Calcular e exibir o valor total da diária com o desconto, se aplicável
        Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria():C}");
    }
}
