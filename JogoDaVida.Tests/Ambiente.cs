using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaVida.Tests
{
    internal class Ambiente
    {
        public Ambiente()
        {
            Celulas = new List<Celula>();
        }

        public Ambiente(int largura, int altura)
        {
            Area = new Celula[largura,altura];
        }

        [Obsolete()]
        public IEnumerable<Celula> Celulas { get; }

        [Obsolete()]
        private int CelulasVivasCount
        {
            get { return Celulas.Count(c => c.Viva); }
        }

        public Celula[,] Area { get; set; }

        internal void CicloVida()
        {
            for (var x= 0; x < Area.GetLength(0);x++)
            {
                for (var y = 0; y < Area.GetLength(1); y++)
                {
                    
                }
            }
        }

        public void AdicionarCelula(int posicaoX, int posicaoY, Celula celula)
        {
            if (Area[posicaoX, posicaoY] != null)
                throw new InvalidOperationException();
            Area[posicaoX, posicaoY] = celula;
        }
    }
}