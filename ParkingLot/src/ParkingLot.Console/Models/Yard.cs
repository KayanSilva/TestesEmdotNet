using ParkingLot.Console.Models;

namespace ParkingLot.Models
{
    public class Yard
    {
        public Yard()
        {
            Billing = 0;
            _vehicles = new List<Vehicle>();
        }

        private Operator _operatorYard;
        private double _billed;
        private List<Vehicle> _vehicles;
        public Operator OperatorYard { get => _operatorYard; set => _operatorYard = value; }
        public double Billing { get => _billed; set => _billed = value; }
        public List<Vehicle> Vehicles { get => _vehicles; set => _vehicles = value; }

        public double TotalBilling()
        {
            return Billing;
        }

        public string MostrarFaturamento()
        {
            return $"Total billed this moment :::::::::::::::::::::::::::: {TotalBilling():c}";
        }

        public void CheckIn(Vehicle veiculo)
        {
            veiculo.CheckIn = DateTime.Now;
            GenerateTicket(veiculo);
            Vehicles.Add(veiculo);
        }

        public string CheckOut(string plate)
        {
            Vehicle wanted = null;
            string information = string.Empty;

            foreach (Vehicle v in Vehicles)
            {
                if (v.Plate == plate)
                {
                    v.CheckOut = DateTime.Now;
                    TimeSpan tempoPermanencia = v.CheckOut - v.CheckIn;
                    double valorASerCobrado = 0;
                    if (v.Type == VehicleType.Car)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }

                    if (v.Type == VehicleType.Motorcycle)
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;

                    information = string.Format("Check-in: {0: HH: mm: ss}\n " +
                                             "Check-out: {1: HH:mm:ss}\n " +
                                             "Permanence: {2: HH:mm:ss} \n " +
                                             "Amount payable: {3:c}", v.CheckIn, v.CheckOut, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    wanted = v;
                    Billing += valorASerCobrado;
                    break;
                }
            }

            if (wanted != null)
                Vehicles.Remove(wanted);
            else
                return "No vehicle found with the given license plate.";

            return information;
        }

        public Vehicle? SearchVehicleInTheYard(string ticketId)
        {
            var vehicleFound = (from vehicle in Vehicles 
                                where vehicle.TicketId == ticketId 
                                select vehicle)
                                .SingleOrDefault();

            return vehicleFound;
        }

        public Vehicle? UpdateVehicle(Vehicle vehicleUpdate)
        {
            var vehicleTemp = (from vehicle in Vehicles where vehicle.Plate == vehicleUpdate.Plate select vehicle).SingleOrDefault();

            vehicleTemp?.UpdateVehicleInfos(vehicleUpdate);

            return vehicleTemp; 
        }

        private string GenerateTicket(Vehicle vehicle)
        {
            vehicle.TicketId = new Guid().ToString()[..5];

            vehicle.Ticket = "### Ticket Park Alura ### \n" +
                            $">>> Id: {vehicle.TicketId} \n" +
                            $"Check-in: {DateTime.Now} \n" +
                            $"Vehicle plate: {vehicle.Plate}" +
                            $"Operator: {OperatorYard.Name}";

            return vehicle.Ticket;
        }
    }
}