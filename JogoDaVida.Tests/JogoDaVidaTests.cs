using System;
using Xunit;

namespace JogoDaVida.Tests
{
    public class JogoDaVidaTests
    {
        [Fact]
        public void Duas_celulas_nao_podem_ser_adicionadas_na_mesma_posicao()
        {
            // arrange
            var ambiente = new Ambiente();
            ambiente.Area = new Celula[2,2];
            // act
            ambiente.AdicionarCelula(1, 1, new Celula());
            // assert
            Assert.Throws<InvalidOperationException>(() => ambiente.AdicionarCelula(1, 1, new Celula()));
        }

        [Fact]
        public void Qualquer_celula_viva_com_menos_que_duas_células_vivas_vizinhas_morre_por_baixa_populacao()
        {
            var ambiente = new Ambiente();
            ambiente.Area = new Celula[4,4];
            
            ambiente.AdicionarCelula(1, 1, new Celula() { Viva = true });
            ambiente.AdicionarCelula(3, 2, new Celula() { Viva = true });
            ambiente.AdicionarCelula(3, 3, new Celula() { Viva = true });

            ambiente.CicloVida();
            
            Assert.False(ambiente.Area[1, 1].Viva);
            Assert.False(ambiente.Area[3, 2].Viva);
            Assert.False(ambiente.Area[3, 3].Viva);
        }

        [Fact]
        public void Qualquer_celula_viva_com_duas_células_vivas_vizinhas_continua_viva()
        {
            // arrange
            var ambiente = new Ambiente();
            var celula1 = new Celula { Viva = true };
            var celula2 = new Celula { Viva = true };
            var celula3 = new Celula { Viva = true };
            ambiente.AdicionarCelula(1, 1, celula1);
            ambiente.AdicionarCelula(1, 1, celula2);
            ambiente.AdicionarCelula(1, 1, celula3);

            // act
            ambiente.CicloVida();

            // assert
            Assert.True(celula1.Viva);
            Assert.True(celula2.Viva);
            Assert.True(celula3.Viva);
        }

        [Fact]
        public void Qualquer_celula_morta_com_exatamente_tres_celulas_vivas_vizinhas_se_transforma_em_uma_celula_viva()
        {
            // arrange
            var ambiente = new Ambiente();
            var celula1 = new Celula { Viva = false };
            var celula2 = new Celula { Viva = true };
            var celula3 = new Celula { Viva = true };
            var celula4 = new Celula { Viva = true };
            ambiente.AdicionarCelula(1, 1, celula1);
            ambiente.AdicionarCelula(1, 1, celula2);
            ambiente.AdicionarCelula(1, 1, celula3);
            ambiente.AdicionarCelula(1, 1, celula4);

            // act
            ambiente.CicloVida();

            // assert
            Assert.True(celula1.Viva);
            Assert.True(celula2.Viva);
            Assert.True(celula3.Viva);
            Assert.True(celula4.Viva);
        }

        [Fact]
        public void Qualquer_celula_viva_com_três_células_vivas_vizinhas_continua_viva()
        {
            // arrange
            var ambiente = new Ambiente();
            var celula1 = new Celula { Viva = true };
            var celula2 = new Celula { Viva = true };
            var celula3 = new Celula { Viva = true };
            var celula4 = new Celula { Viva = true };
            ambiente.AdicionarCelula(1, 1, celula1);
            ambiente.AdicionarCelula(1, 1, celula2);
            ambiente.AdicionarCelula(1, 1, celula3);
            ambiente.AdicionarCelula(1, 1, celula4);

            // act
            ambiente.CicloVida();

            // assert
            Assert.True(celula1.Viva);
            Assert.True(celula2.Viva);
            Assert.True(celula3.Viva);
            Assert.True(celula4.Viva);
        }

        [Fact]
        public void Qualquer_celula_viva_com_mais_que_três_células_vivas_vizinhas_morre_por_alta_populacao()
        {
            // arrange
            var ambiente = new Ambiente();
            var celula1 = new Celula { Viva = true };
            var celula2 = new Celula { Viva = true };
            var celula3 = new Celula { Viva = true };
            var celula4 = new Celula { Viva = true };
            var celula5 = new Celula { Viva = true };
            ambiente.AdicionarCelula(1, 1, celula1);
            ambiente.AdicionarCelula(1, 1, celula2);
            ambiente.AdicionarCelula(1, 1, celula3);
            ambiente.AdicionarCelula(1, 1, celula4);
            ambiente.AdicionarCelula(1, 1, celula5);

            // act
            ambiente.CicloVida();

            // assert
            Assert.False(celula1.Viva);
            Assert.True(celula2.Viva);
            Assert.True(celula3.Viva);
            Assert.True(celula4.Viva);
            Assert.True(celula5.Viva);
        }

        [Fact]
        public void Qualquer_celula_viva_com_mais_que_três_células_mas_nao_vivas_vizinhas_Continua_viva()
        {
            // arrange
            var ambiente = new Ambiente();
            var celula1 = new Celula { Viva = true };
            var celula2 = new Celula { Viva = true };
            var celula3 = new Celula { Viva = false };
            var celula4 = new Celula { Viva = true };
            var celula5 = new Celula { Viva = true };
            ambiente.AdicionarCelula(1, 1, celula1);
            ambiente.AdicionarCelula(1, 1, celula2);
            ambiente.AdicionarCelula(1, 1, celula3);
            ambiente.AdicionarCelula(1, 1, celula4);
            ambiente.AdicionarCelula(1, 1, celula5);

            // act
            ambiente.CicloVida();

            // assert
            Assert.True(celula1.Viva);
            Assert.True(celula2.Viva);
            Assert.False(celula3.Viva);
            Assert.True(celula4.Viva);
            Assert.True(celula5.Viva);
        }

        [Fact]
        public void Criar_ambiente_com_4x5_unidades()
        {
            // arrange
            // act
            var ambiente = new Ambiente(4, 5);
    
            // assert
            Assert.Equal(2, ambiente.Area.Rank);
            Assert.Equal(4, ambiente.Area.GetLength(0));
            Assert.Equal(5, ambiente.Area.GetLength(1));
        }

        public void C()
        {
            // arrange
            // act

        }

    }
}
