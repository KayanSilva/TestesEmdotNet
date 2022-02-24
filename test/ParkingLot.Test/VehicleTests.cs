using ParkingLot.Models;
using Xunit;

namespace ParkingLot.Test
{
    public class VehicleTests
    {
        [Fact(DisplayName = "Test about method speedUp in Vehicle class")]
        [Trait("Function", "SpeedUp")]
        public void SpeedUp()
        {
            //Arrange
            var vehicle = new Vehicle();

            //Act
            vehicle.SpeedUp(10);

            //Assert
            Assert.Equal(100, vehicle.CurrentSpeed);
        }

        [Fact]
        [Trait("Function", "Break")]
        public void Break()
        {
            //Arrange
            var vehicle = new Vehicle();

            //Act
            vehicle.Break(10);

            //Assert
            Assert.Equal(-150, vehicle.CurrentSpeed);
        }

        [Fact(Skip = "Ignore this test")]
        public void ValidateOwnerName()
        {
        }

        [Fact]
        public void UpdateVehicleInfos()
        {
            //Arrange
            var vehicle = new Vehicle
            {
                Owner = "Carlos Pereira",
                Plate = "ZAP-4532",
                Color = "Black",
                Model = "Variant",
                Type =  VehicleType.Car
            };

            //Act
            string data = vehicle.ToString();

            //Assert
            Assert.Contains("Vehicle Type: Car", data);
        }
    }
}