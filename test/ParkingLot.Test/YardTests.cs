using ParkingLot.Models;
using Xunit;

namespace ParkingLot.Test
{
    public class YardTests
    {
        [Fact]
        public void ValidateBilling()
        {
            //Arrange
            var yard = new Yard();
            Vehicle andreVehicle = new()
            {
                Owner = "André Silva",
                Type = VehicleType.Car,
                Color = "Green",
                Model = "Fusca",
                Plate = "NEA-1505"
            };

            yard.CheckIn(andreVehicle);
            yard.CheckOut(andreVehicle.Plate);

            //Act
            var billing = yard.TotalBilling();

            //Arrange
            Assert.Equal(2, billing);
        }

        [Theory]
        [InlineData("Héctor Cucoro", "BBB-8888", "Black", "Mustang")]
        [InlineData("Marcos Bonetts", "AAA-9999", "Yellow", "Vectar")]
        public void MultiplesValidateBilling(string Owner, string Plate, string Color, string Model)
        {
            //Arrange
            Yard yard = new();
            var vehicle = new Vehicle()
            {
                Owner = Owner,
                Type = VehicleType.Car,
                Color = Color,
                Model = Model,
                Plate = Plate
            };

            yard.CheckIn(vehicle);
            yard.CheckOut(vehicle.Plate);

            //Act
            var billing = yard.TotalBilling();

            //Arrange
            Assert.Equal(2, billing);
        }

        [Theory]
        [InlineData("Héctor Cucoro", "BBB-8888", "Black", "Mustang")]
        [InlineData("Marcos Bonetts", "AAA-9999", "Yellow", "Vectar")]
        public void SearchVehicleInTheYard(string Owner, string Plate, string Color, string Model)
        { 
            //Arrange
            Yard yard = new();
            var vehicle = new Vehicle()
            {
                Owner = Owner,
                Type = VehicleType.Car,
                Color = Color,
                Model = Model,
                Plate = Plate
            };

            yard.CheckIn(vehicle);

            //Act
            var consulted = yard.SearchVehicleInTheYard(Plate);

            //Act
            Assert.Equal(Plate, consulted?.Plate);
        }

        [Fact]
        public void UpdateVehicle()
        {
            //Arrange
            Yard yard = new();
            var vehicle = new Vehicle()
            {
                Owner = "José Augusto",
                Type = VehicleType.Car,
                Color = "Blue",
                Model = "Nissan Vectra",
                Plate = "ZXC-8524"
            };

            yard.CheckIn(vehicle);

            var updatedvehicle = new Vehicle
            {
                Owner = "José Augusto",
                Type = VehicleType.Car,
                Color = "Black",
                Model = "Nissan Vectra",
                Plate = "ZXC-8524"
            };

            //Act
            var updated = yard.UpdateVehicle(updatedvehicle);

            //Assert
            Assert.Equal(updatedvehicle.Color, updated?.Color);
        }
    }
}