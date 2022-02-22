using ParkingLot.Models;
using Xunit;

namespace ParkingLot.Test
{
    public class VehicleTests
    {
        [Fact]
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
        public void Break()
        {
            //Arrange
            var vehicle = new Vehicle();

            //Act
            vehicle.Break(10);

            //Assert
            Assert.Equal(-150, vehicle.CurrentSpeed);
        }
    }
}