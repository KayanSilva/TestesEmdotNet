namespace ParkingLot.Models
{
    public class Yard
    {
        public Yard()
        {
            Faturado = 0;
            veiculos = new List<Vehicle>();
        }

        private List<Vehicle> veiculos;
        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }
        public List<Vehicle> vehicles { get => veiculos; set => veiculos = value; }

        public double TotalBilling()
        {
            return this.Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalBilling());
            return totalfaturado;
        }

        public void CheckIn(Vehicle veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            this.vehicles.Add(veiculo);
        }

        public string CheckOut(String placa)
        {
            Vehicle procurado = null;
            string informacao = string.Empty;

            foreach (Vehicle v in this.vehicles)
            {
                if (v.Plate == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;
                    if (v.Type == VehicleType.Automovel)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }
                    if (v.Type == VehicleType.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }
                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n " +
                                             "Permanência: {2: HH:mm:ss} \n " +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    this.Faturado = this.Faturado + valorASerCobrado;
                    break;
                }
            }
            if (procurado != null)
            {
                this.vehicles.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }
    }
}