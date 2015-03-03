using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BatalhaNaval.Tests
{
    public class JogoTest
    {

        [Fact(Skip = "em andamento")]
        public void Ao_Atingir_uma_navio_na_posicao_definida_ele_ficara_com_status_atingido()
        {
            var area = new Area(10, 10);
            var navio = new BarcoPatrulhaNavio();

            area.AdicionarNavio(navio, 2, 2, Orientacao.Horizontal);

            area.Atirar(-1, -1);  // TODO: posicoes conforme teste
        }
            

    }
}
