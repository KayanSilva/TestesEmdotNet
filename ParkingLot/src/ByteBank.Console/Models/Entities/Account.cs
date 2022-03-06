using System.ComponentModel.DataAnnotations;

namespace ByteBank.Console.Models.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public Guid Identificador { get; set; }

        public Account()
        {

        }
        private Client _cliente;
        public virtual Client Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Cliente não pode ser nulo.");
                }
                _cliente = value;
            }
        }

        private Agency _agencia;
        public virtual Agency Agencia
        {
            get { return _agencia; }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Agência não pode ser nulo.");
                }
                _agencia = value;
            }
        }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("O valor para saldo não pode ser menor ou igual a zero.");
                }

                _saldo += value;
            }
        }
        private Guid _pix;
        public Guid PixConta { get => _pix; set => _pix = value; }




    }
}
