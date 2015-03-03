using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BatalhaNaval.Tests
{
    public class CriacaoAreaTest
    {
        [Fact]
        public void Possui_navio_em_coordenadas_com_orientacao_vertical_com_navio_retorna_true()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            area.AdicionarNavio(navio, 0, 0, Orientacao.Vertical);
            Assert.Equal(true, area.PossuiNavio(0, 0));
            Assert.Equal(true, area.PossuiNavio(1, 0));
        }

        [Fact]
        public void Possui_navio_em_coordenadas_na_orientacao_horizontal_navio_retorna_true()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            area.AdicionarNavio(navio, 0, 0, Orientacao.Horizontal);
            Assert.Equal(true, area.PossuiNavio(0, 0));
            Assert.Equal(true, area.PossuiNavio(0, 1));
        }

        [Fact]
        public void Possui_navio_em_coordenadas_sem_navio_com_orientacao_vertical_retorna_false()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();

            area.AdicionarNavio(navio, 0, 0, Orientacao.Vertical);
            Assert.False(area.PossuiNavio(0, 1));
            Assert.False(area.PossuiNavio(1, 1));
        }

        [Fact]
        public void Possui_navio_em_coordenadas_sem_navio_com_orientacao_horizontal_retorna_false()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();

            area.AdicionarNavio(navio, 0, 0, Orientacao.Horizontal);
            Assert.False(area.PossuiNavio(1, 0));
            Assert.False(area.PossuiNavio(0, 2));
        }

        [Fact]
        public void Nao_pode_adicionar_navios_fora_da_fronteira_largura_com_orientacao_vertical()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            Assert.Throws<ArgumentOutOfRangeException>(() => area.AdicionarNavio(navio, 9, 10, Orientacao.Vertical));
        }

        [Fact]
        public void Nao_pode_adicionar_navios_fora_da_fronteira_altura_com_orientacao_vertical()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            Assert.Throws<ArgumentOutOfRangeException>(() => area.AdicionarNavio(navio, 10, 9, Orientacao.Vertical));
        }

        [Fact]
        public void Nao_pode_adicionar_navios_dentro_da_fronteira_altura_mas_com_comprimento_ultrapassando_froteira_com_orientacao_vertical()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            Assert.Throws<ArgumentOutOfRangeException>(() => area.AdicionarNavio(navio, 9, 8, Orientacao.Vertical));
            area.AdicionarNavio(navio, 8, 9, Orientacao.Vertical);
        }

        [Fact]
        public void Nao_pode_adicionar_navios_dentro_da_fronteira_altura_mas_com_comprimento_ultrapassando_froteira_com_orientacao_horizontal()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            Assert.Throws<ArgumentOutOfRangeException>(() => area.AdicionarNavio(navio, 9, 8, Orientacao.Vertical));
        }

        [Fact]
        public void Ao_adicionar_um_navio_fora_da_fronteira_com_orientacao_vertical_a_area_nao_pode_conter_ele()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();
            Assert.Throws<ArgumentOutOfRangeException>(() => area.AdicionarNavio(navio, 9, 9, Orientacao.Vertical));
            Assert.False(area.PossuiNavio(9, 9));
        }

        [Fact]
        public void Adicionar_1_navio_na_posicao_vertical_e_outro_na_posicao_horizontal_nao_podem_sobrepor()
        {
            var area = new Area(10, 10);
            var navioA = new BarcoPatrulhaNavio();
            var navioB = new BarcoPatrulhaNavio();

            area.AdicionarNavio(navioA, 2, 1, Orientacao.Vertical);
            Assert.Throws<InvalidOperationException>(() => area.AdicionarNavio(navioB, 3, 1, Orientacao.Horizontal));
        }

        [Fact(Skip = "Not yet")]
        public void Validar_navio_vazio()
        {
            
        }

        [Fact(Skip = "Not yet")]
        public void Validar_x_y_negativo()
        {

        }

        [Fact]
        public void Ao_verificar_se_possui_navio_com_linha_coluna_fora_dos_limites_um_erro_ocorre()
        {
            var area = new Area(5, 10);
            // Negativo
            Assert.Throws<ArgumentOutOfRangeException>(() => area.PossuiNavio(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => area.PossuiNavio(-1, 0));
            // Fora da area
            Assert.Throws<ArgumentOutOfRangeException>(() => area.PossuiNavio(5, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => area.PossuiNavio(0, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => area.PossuiNavio(6, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => area.PossuiNavio(0, 11));
        }

        [Fact]
        public void Ao_adicionar_dois_navios_com_orientacao_vertical_as_duas_regioes_de_navios_irao_possuir_navio()
        {
            var area = new Area(10, 10);
            var navioA = new BarcoPatrulhaNavio();
            var navioB = new BarcoPatrulhaNavio();
            area.AdicionarNavio(navioA, 8, 9, Orientacao.Vertical);
            area.AdicionarNavio(navioB, 4, 4, Orientacao.Vertical);

            // navio A
            Assert.True(area.PossuiNavio(8, 9));
            Assert.True(area.PossuiNavio(9, 9));

            // navio B
            Assert.True(area.PossuiNavio(4, 4));
            Assert.True(area.PossuiNavio(5, 4));
        }

        [Fact]
        public void Ao_adicionar_dois_navios_com_orientacao_vertical_regioes_que_nao_possuem_navios_devem_estar_vazias()
        {
            var area = new Area(10, 10);
            var navioA = new BarcoPatrulhaNavio();
            var navioB = new BarcoPatrulhaNavio();
            area.AdicionarNavio(navioA, 8, 9, Orientacao.Vertical);
            area.AdicionarNavio(navioB, 4, 4, Orientacao.Vertical);

            // navio A
            Assert.False(area.PossuiNavio(1, 1));
            Assert.False(area.PossuiNavio(5, 6));


        }
    }
}
