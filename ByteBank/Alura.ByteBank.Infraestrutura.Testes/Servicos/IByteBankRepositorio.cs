﻿using Alura.ByteBank.Dominio.Entidades;
using System.Collections.Generic;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();

        public List<Agencia> BuscarAgencias();

        public List<ContaCorrente> BuscarContasCorrentes();
    }
}