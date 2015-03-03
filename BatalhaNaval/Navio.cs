using System;

namespace BatalhaNaval
{
    public abstract class Navio
    {
        protected Navio(int comprimento)
        {
            Comprimento = comprimento;
        }

        public Int32 Comprimento { get; private set; }
    }
}