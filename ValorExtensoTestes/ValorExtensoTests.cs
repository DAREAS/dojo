using System;
using System.Collections.Generic;
using Xunit;

namespace ValorExtensoTestes
{
    public class ValorExtensoTests
    {

        [Fact]
        public void Valores_um_digito_sao_convertidos_corretamente()
        {
            var parser = new ValorExtensoParser();

            var valorUm = parser.Parse("um");
            Assert.Equal(1, valorUm);

            var valorDois = parser.Parse("dois");
            Assert.Equal(2, valorDois);

            var valorTres = parser.Parse("três");
            Assert.Equal(3, valorTres);

            var valorQuatro = parser.Parse("quatro");
            Assert.Equal(4, valorQuatro);

            var valorCinco = parser.Parse("cinco");
            Assert.Equal(5, valorCinco);

            var valorSeis = parser.Parse("seis");
            Assert.Equal(6, valorSeis);

            var valorSete = parser.Parse("sete");
            Assert.Equal(7, valorSete);

            var valorOito = parser.Parse("oito");
            Assert.Equal(8, valorOito);

            var valorNove = parser.Parse("nove");
            Assert.Equal(9, valorNove);
        }

        [Fact]
        public void Valor_dezenas_eh_convertido_corretamente()
        {
            var parser = new ValorExtensoParser();

            var valorVinteUm = parser.Parse("vinte e um");
            Assert.Equal(21, valorVinteUm);

            var valorTrintaUm = parser.Parse("trinta e um");
            Assert.Equal(31, valorTrintaUm);

            var valorQuarentaUm = parser.Parse("quarenta e um");
            Assert.Equal(41, valorQuarentaUm);

            var valorCinquentaUm = parser.Parse("cinquenta e um");
            Assert.Equal(51, valorCinquentaUm);

            var valorSessentaUm = parser.Parse("sessenta e um");
            Assert.Equal(61, valorSessentaUm);
        }

        [Fact]
        public void Valor_vinte_um_eh_convertido_corretamente()
        {
            // arrange
            const string valorExtenso = "vinte e um";
            //act
            var parser = new ValorExtensoParser();
            var valor = parser.Parse(valorExtenso);
            // assert
            Assert.Equal(21, valor);
        }

        [Fact(Skip = "depois")]
        public void Parser_eh_case_insensitive() { }

        [Fact(Skip = "depois")]
        public void Argument_null_ou_empty() { }


        [Fact]
        public void Valor_por_extenso_nao_existente_erro()
        {
            // arrange
            const string valorExtenso = "valor_invalido";
            // act
            var parser = new ValorExtensoParser();
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => parser.Parse(valorExtenso));
        }
    }

    public class ValorExtensoParser
    {
        private static readonly IDictionary<string, int> DeParaDigitoUnico;

        static ValorExtensoParser()
        {
            DeParaDigitoUnico = new Dictionary<string, int>
            {
                { "zero", 0 },
                { "um", 1 },
                { "dois", 2 },
                { "três", 3 },
                { "quatro", 4 },
                { "cinco", 5 },
                { "seis", 6 },
                { "sete", 7 },
                { "oito", 8 },
                { "nove", 9 },
                { "vinte", 2 },
                { "trinta", 3 },
                { "quarenta", 4 },
                { "cinquenta", 5 },
                { "sessenta", 6 }
            };
        }
        public int Parse(string valorExtenso)
        {
            var valoresSplited = valorExtenso.Split(' ');
            var valorEhComposto = valoresSplited.Length > 1;
            if (!valorEhComposto)
            {
                if (!DeParaDigitoUnico.ContainsKey(valorExtenso))
                    throw new ArgumentOutOfRangeException("valorExtenso", valorExtenso + ": inválido.");
                return DeParaDigitoUnico[valorExtenso];
            }

            var result = "";
            foreach (var valor in valoresSplited)
            {
                if (valor == "e")
                    continue;
                var valorNumerico = DeParaDigitoUnico[valor];
                result += valorNumerico.ToString();
            }
            return int.Parse(result);
        }
    }
}
