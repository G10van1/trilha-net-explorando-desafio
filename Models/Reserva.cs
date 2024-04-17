namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // IMPLEMENTADO!
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // IMPLEMENTADO!
                throw new Exception("Capacidade da suite menor que o número de hóspedes recebido."); 
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // IMPLEMENTADO!
            return Hospedes.Count;
        }

        public decimal CalcularValorReserva()
        {
            // TODO: Retorna o valor da reserva
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // IMPLEMENTADO!
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // IMPLEMENTADO!
            const int NR_DIAS_COM_DESCONTO = 10;
            if (DiasReservados >= NR_DIAS_COM_DESCONTO)
            {
                const decimal DESCONTO = (decimal)10/(decimal)100;
                valor -= valor * DESCONTO ;
            }

            return valor;
        }
    }
}