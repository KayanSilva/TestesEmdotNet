﻿using Alura.ByteBank.Infraestrutura.Testes.DTO;
using System;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
        public PixDTO ConsultaPix(Guid pix);
    }
}