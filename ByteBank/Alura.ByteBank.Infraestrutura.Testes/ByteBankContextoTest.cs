using Alura.ByteBank.Dados.Contexto;
using System;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTest
    {
        [Fact]
        public void ConnectionWithMyBDMySql()
        {
            //Arrange
            var context = new ByteBankContexto();
            bool connect;

            //Act
            try
            {
                connect = context.Database.CanConnect();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't possible connect wuth databse.");
            }

            //Assert
            Assert.True(connect);
        }
    }
}