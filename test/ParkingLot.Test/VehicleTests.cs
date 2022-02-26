using ParkingLot.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ParkingLot.Test
{
    public class VehicleTests : IDisposable
    {
        private Vehicle _vehicle;
        private ITestOutputHelper _testOutputHelper;

        public VehicleTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Constructor invoke");
            _vehicle = new Vehicle();
        }

        [Fact]
        [Trait("Function", "SpeedUp")]
        public void SpeedUp()
        {
            //Act
            _vehicle.SpeedUp(10);

            //Assert
            Assert.Equal(100, _vehicle.CurrentSpeed);
        }

        [Fact]
        [Trait("Function", "Break")]
        public void Break()
        {
            //Act
            _vehicle.Break(10);

            //Assert
            Assert.Equal(-150, _vehicle.CurrentSpeed);
        }

        [Fact(Skip = "Ignore this test")]
        public void ValidateOwnerName()
        {
        }

        [Fact]
        public void ReportVehicle()
        {
            //Arrange
            _vehicle = new Vehicle
            {
                Owner = "Carlos Pereira",
                Plate = "ZAP-4532",
                Color = "Black",
                Model = "Variant",
                Type = VehicleType.Car
            };

            //Act
            string data = _vehicle.ToString();

            //Assert
            Assert.Contains("Vehicle Type: Car", data);
        }

        [Fact]
        public void OwerNameWithLessThreeCharacters()
        {
            //Arrange
            var ownerName = "BC";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Vehicle(ownerName)
            );
        }

        [Fact]
        public void ExceptionAboutFourCharacterInPlate()
        {
            //Arrange
            var plate = "AAAAAAAA";

            
            //Act
            var message = Assert.Throws<FormatException>(
                () => new Vehicle().Plate = plate 
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", message.Message);
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Dispose invoke");
        }
    }
}