namespace ParkingLot.Models
{
    public class Vehicle
    {
        #region Fields

        private string _placa;
        private string _proprietario;
        private VehicleType _tipo;

        #endregion Fields

        #region Properties

        public string Plate
        {
            get
            {
                return _placa;
            }
            set
            {
                // Checa se o valor possui pelo menos 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException(" A placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    //checa se os 3 primeiros caracteres são numeros
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }
                //checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }
                //checa se os 3 primeiros caracteres são numeros
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }
                _placa = value;
            }
        }

        /// <summary>
        /// { get; set; } cria uma propriedade automática, ou seja,
        /// durante a compilação, é gerado um atributo para armazenar
        /// o valor da propriedade e os metodos get e set, respectivamente,
        /// lêem e escrevem diretamente no atributo gerado, sem
        /// qualquer validação. É um recurso útil, pois as propriedades
        /// permitem fazer melhor uso do recurso de Reflection do .Net
        /// Framework, entre outros benefícios.
        /// </summary>
        public string Color { get; set; }
        public double Largura { get; set; }
        public double CurrentSpeed { get; set; }
        public string Model { get; set; }
        public string Owner { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public VehicleType Type { get => _tipo; set => _tipo = value; }

        #endregion Properties

        #region Constructors

        public Vehicle()
        {
        }

        public Vehicle(string proprietario)
        {
            Owner = proprietario;
        }

        #endregion Constructors

        #region Methods

        public void SpeedUp(int tempoSeg)
        {
            CurrentSpeed += (tempoSeg * 10);
        }

        public void Break(int tempoSeg)
        {
            CurrentSpeed -= (tempoSeg * 15);
        }

        public void UpdateVehicleInfos(Vehicle vehicleUpdate)
        {
            Owner = vehicleUpdate.Owner;
            Model = vehicleUpdate.Model;
            Color = vehicleUpdate.Color;
            Largura = vehicleUpdate.Largura;
        }

        public override string ToString()
        {
            return $"Report Vehicle: \n" +
                   $"Vehicle Type: {Type} \n" +
                   $"Owner: {Owner} \n" +
                   $"Model: {Model}\n" +
                   $"Color: {Color} \n" +
                   $"Plate: {Plate} \n";
        }

        #endregion Methods
    }
}