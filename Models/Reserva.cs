using System.Runtime.CompilerServices;

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
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                Console.WriteLine("O número de hóspede informados é superior aos cadastrados na reserva.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            try
            {
                Suite = suite;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar Suite. " + ex.Message);
            }
        }

        public int ObterQuantidadeHospedes()
        {
            try
            {
                return Hospedes.Count;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possivel validar o número de hospedes.");
                return 0;
            }
            
        }

        public decimal CalcularValorDiaria()
        {
            try
            {
                decimal valor = 0;

                valor =  DiasReservados * Suite.ValorDiaria;

                if (DiasReservados >= 10)
                {
                    decimal desconto = valor * Convert.ToDecimal(0.1);
                    valor -= desconto;
                }

                return valor;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Problema ao calcular o valor. \nContate o administrador.\n " + ex.Message + "\n");
                return 0;
            }
        }
    }
}