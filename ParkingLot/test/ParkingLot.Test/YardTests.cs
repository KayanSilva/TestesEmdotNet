using ParkingLot.Console.Models;
using ParkingLot.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ParkingLot.Test
{
    public class YardTests : IDisposable
    {
        private Vehicle _vehicle;
        private Yard _yard;
        private ITestOutputHelper _testOutputHelper;

        public YardTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Constructor invoke");
            _vehicle = new Vehicle();
            _yard = new Yard { OperatorYard = new Operator { Name = "Luis Marciano" } };
        }


        [Fact]
        public void ValidateBilling()
        {
            //Arrange
            _vehicle = new()
            {
                Owner = "André Silva",
                Type = VehicleType.Car,
                Color = "Green",
                Model = "Fusca",
                Plate = "NEA-1505"
            };

            _yard.CheckIn(_vehicle);
            _yard.CheckOut(_vehicle.Plate);

            //Act
            var billing = _yard.TotalBilling();

            //Arrange
            Assert.Equal(2, billing);
        }

        [Theory]
        [InlineData("Héctor Cucoro", "BBB-8888", "Black", "Mustang")]
        [InlineData("Marcos Bonetts", "AAA-9999", "Yellow", "Vectar")]
        public void MultiplesValidateBilling(string Owner, string Plate, string Color, string Model)
        {
            //Arrange
            _vehicle = new Vehicle()
            {
                Owner = Owner,
                Type = VehicleType.Car,
                Color = Color,
                Model = Model,
                Plate = Plate
            };

            _yard.CheckIn(_vehicle);
            _yard.CheckOut(_vehicle.Plate);

            //Act
            var billing = _yard.TotalBilling();

            //Arrange
            Assert.Equal(2, billing);
        }

        [Theory]
        [InlineData("Héctor Cucoro", "BBB-8888", "Black", "Mustang")]
        [InlineData("Marcos Bonetts", "AAA-9999", "Yellow", "Vectar")]
        public void SearchVehicleInTheYard(string Owner, string Plate, string Color, string Model)
        {
            //Arrange
            _vehicle = new Vehicle
            {
                Owner = Owner,
                Type = VehicleType.Car,
                Color = Color,
                Model = Model,
                Plate = Plate
            };

            _yard.CheckIn(_vehicle);

            //Act
            var consulted = _yard.SearchVehicleInTheYard(_vehicle.TicketId);

            //Act
            Assert.Contains("### Ticket Park Alura ###", consulted?.Ticket);
        }

        [Fact]
        public void UpdateVehicle()
        {
            //Arrange
            _vehicle = new Vehicle
            {
                Owner = "José Augusto",
                Type = VehicleType.Car,
                Color = "Blue",
                Model = "Nissan Vectra",
                Plate = "ZXC-8524"
            };

            _yard.CheckIn(_vehicle);

            var updatedvehicle = new Vehicle
            {
                Owner = "José Augusto",
                Type = VehicleType.Car,
                Color = "Black",
                Model = "Nissan Vectra",
                Plate = "ZXC-8524"
            };

            //Act
            var updated = _yard.UpdateVehicle(updatedvehicle);

            //Assert
            Assert.Equal(updatedvehicle.Color, updated?.Color);
        }

        public void Dispose() => _testOutputHelper.WriteLine("Dispose invoke");
    }
}