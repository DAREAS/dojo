using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Intervalos.Test
{
    public class IntervaloTest
    {
        
        [Fact]
        public void Dado_dois_numeros_sequenciais_retornar_um_agrupamento_com_menor_numero_sendo_primeiro_e_maior_sendo_segundo()
        {
            // arrange
            var interval = new Intervalo();
            interval.EntrarDados(10);
            interval.EntrarDados(11);

            // act
            var grupos = interval.Agrupar();

            // assert
            Assert.Equal(1, grupos.Count());
            var grupo = grupos.Single();
            Assert.Equal(10, grupo.Item1);
            Assert.Equal(11, grupo.Item2);
        }

        [Fact]
        public void Dado_dois_numeros_sequenciais_e_outro_numero_nao_sequencial_retornar_um_agrupamento_ordenado_com_dois_grupos()
        {
            // arrange
            var interval = new Intervalo();
            interval.EntrarDados(10);
            interval.EntrarDados(11);
            interval.EntrarDados(15);

            // act
            var grupos = interval.Agrupar();

            // assert
            Assert.Equal(2, grupos.Count());
            var grupo1=  grupos.First();
            Assert.Equal(10, grupo1.Item1);
            Assert.Equal(11, grupo1.Item2);

            var grupo2=  grupos.Last();
            Assert.Equal(15, grupo2.Item1);
            Assert.Null(grupo2.Item2);
        }
    }

    public class Intervalo
    {
        private readonly List<int> _numeros = new List<int>();

        public void EntrarDados(int i)
        {
            _numeros.Add(i);
        }

        public IEnumerable<Grupo> Agrupar()
        {
            var anterior = default(int?);
            var grupos = new List<Grupo>();
            Grupo grupo = null;

            foreach (var numero in _numeros.OrderBy(o => o))
            {
                if (anterior == null)
                {
                    grupo = new Grupo(numero, null);
                    anterior = numero;
                }

                if (_numeros.Contains(numero + 1))
                {
                    grupo.Item2 = numero + 1;
                }
                else
                {
                    grupos.Add(grupo);
                    grupo = null;
                }
            }
            if (grupo != null)
                grupos.Add(grupo);

            return grupos;
        }
    }

    public class Grupo
    {
        private readonly int _numeroMenor;
        private readonly int? _numeroMaior;

        public Grupo(int numeroMenor, int? numeroMaior)
        {
            _numeroMaior = numeroMaior;
            _numeroMenor = numeroMenor;
        }
    }
}
