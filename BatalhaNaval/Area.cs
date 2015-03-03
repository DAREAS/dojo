using System;

namespace BatalhaNaval
{
    public class Area
    {
        private readonly int _largura;
        private readonly int _altura;
        private readonly PosicaoNavio[,] _posicoesNavios;

        public Area(int largura, int altura)
        {
            _largura = largura;
            _altura = altura;
            _posicoesNavios = new PosicaoNavio[largura, altura];
        }

        public void AdicionarNavio(Navio navio, int posicaoLinhaNavio, int posicaoColunaNavio, Orientacao orientacao)
        {
            var comprimento = navio.Comprimento - 1;
            var posicaoFinalLinha = posicaoLinhaNavio + (orientacao == Orientacao.Vertical ? comprimento : 0);
            var posicaoFinalColuna = posicaoColunaNavio + (orientacao == Orientacao.Horizontal ? comprimento : 0);

            if (posicaoFinalLinha > _altura - 1)
                throw new ArgumentOutOfRangeException();

            if (posicaoFinalColuna > _largura - 1)
                throw new ArgumentOutOfRangeException();

            var posicaoNavio = new PosicaoNavio
            {
                InicioLinha = posicaoLinhaNavio,
                InicioColuna = posicaoColunaNavio,
                FinalLinha = posicaoFinalLinha,
                FinalColuna = posicaoFinalColuna,
                Navio = navio,
                Orientacao = orientacao
            };

            for (int i = posicaoNavio.InicioLinha; i <= posicaoNavio.FinalLinha; i++)
                for (int j = posicaoNavio.InicioColuna; j <= posicaoNavio.FinalColuna; j++)
                {
                    if (PossuiNavio(i, j))
                    {
                        throw new InvalidOperationException();
                    }
                    _posicoesNavios[i, j] = posicaoNavio;
                }      
        }

        public bool PossuiNavio(int linha, int coluna)
        {
            // TODO: linha / coluna negativo / fora da área vai dar erro
            return _posicoesNavios[linha, coluna] != null;
        }

        private class PosicaoNavio
        {
            public int InicioLinha { get; set; }
            public int InicioColuna { get; set; }

            public Navio Navio { get; set; }
            public Orientacao Orientacao { get; set; }
            public int FinalColuna { get; set; }
            public int FinalLinha { get; set; }
        }

        public void Atirar(int linha, int coluna)
        {
            throw new NotImplementedException();
        }
    }
}