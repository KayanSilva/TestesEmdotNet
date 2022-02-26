namespace ParkingLot.Console.Models
{
    public class Operator
    {
        private string _registration;
        private string _name;

        public string Registration { get => _registration; set => _registration = value; }
        public string Name { get => _name; set => _name = value; }

        public Operator()
        {
            Registration = new Guid().ToString()[..8];
        }

        public override string ToString()
        {
            return $"Operator:{Name} \n Registration:{Registration}";
        }
    }
}