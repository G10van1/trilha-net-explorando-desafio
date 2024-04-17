using System;
using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

hospedes = JsonConvert.DeserializeObject<List<Pessoa>>(File.ReadAllText("../../../Data/hospedes.json"));

// Cria a suíte
Suite suite = JsonConvert.DeserializeObject<Suite>(File.ReadAllText("../../../Data/suite.json"));

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = JsonConvert.DeserializeObject<Reserva>(File.ReadAllText("../../../Data/reserva.json"));
reserva.CadastrarSuite(suite);

try
{
    reserva.CadastrarHospedes(hospedes);

    // Exibe informações sobre a reserva
    Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
    Console.WriteLine($"Valor Diária: {reserva.Suite.ValorDiaria:C}");
    Console.WriteLine($"Diárias: {reserva.DiasReservados}");
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Total da reserva: {reserva.CalcularValorReserva():C}");
}
catch (Exception e)
{
    Console.WriteLine (e.Message);
}

