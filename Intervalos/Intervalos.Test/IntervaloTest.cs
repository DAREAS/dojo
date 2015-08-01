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
            var interval = new AgrupadorDeIntervalo();
            interval.EntrarDados(10);
            interval.EntrarDados(11);

            // act
            var grupos = interval.Agrupar();

            // assert
            Assert.Equal(1, grupos.Count());
            var grupo = grupos.Single();
            Assert.Equal(10, grupo.NumeroMenor);
            Assert.Equal(11, grupo.NumeroMaior);
        }

        [Fact]
        public void Dado_dois_numeros_sequenciais_e_outro_numero_nao_sequencial_retornar_um_agrupamento_ordenado_com_dois_grupos()
        {
            // arrange
            var interval = new AgrupadorDeIntervalo();
            interval.EntrarDados(10);
            interval.EntrarDados(11);
            interval.EntrarDados(15);

            // act
            var grupos = interval.Agrupar();

            // assert
            Assert.Equal(2, grupos.Count());
            var grupo1=  grupos.First();
            Assert.Equal(10, grupo1.NumeroMenor);
            Assert.Equal(11, grupo1.NumeroMaior);

            var grupo2=  grupos.Last();
            Assert.Equal(15, grupo2.NumeroMenor);
            Assert.Null(grupo2.NumeroMaior);
        }

        [Fact]
        public void Dado_dois_grupos_sequenciais_dois_grupos_serao_gerados_com_menor_e_maior_preenchidos()
        {
            // arrange
            var interval = new AgrupadorDeIntervalo();
            interval.EntrarDados(10);
            interval.EntrarDados(11);
            interval.EntrarDados(15);
            interval.EntrarDados(16);

            // act
            var grupos = interval.Agrupar();

            // assert
            Assert.Equal(2, grupos.Count());
            var grupo1 = grupos.First();
            Assert.Equal(10, grupo1.NumeroMenor);
            Assert.Equal(11, grupo1.NumeroMaior);

            var grupo2 = grupos.Last();
            Assert.Equal(15, grupo2.NumeroMenor);
            Assert.Equal(16, grupo2.NumeroMaior);
        }

    }

    public class AgrupadorDeIntervalo
    {
        private readonly List<int> _numeros = new List<int>();

        public void EntrarDados(int i)
        {
            _numeros.Add(i);
        }

        public IEnumerable<Intervalo> Agrupar()
        {
            var numerosOrdenados = _numeros.OrderBy(n => n).ToList();
            var anterior = default(int?);
            var intervalos = new List<Intervalo>();
            Intervalo intervalo = null; 
            var numeroCorrente = numerosOrdenados.First();
            var grupoCorrente = new Intervalo(numeroCorrente, null);
            intervalos.Add(grupoCorrente);
            for (int i = 1; i < numerosOrdenados.Count(); i++)
            {
                numeroCorrente++;
                if (numerosOrdenados[i] == numeroCorrente)
                {
                    grupoCorrente.NumeroMaior = numeroCorrente;
                }
                else
                {
                    grupoCorrente.NumeroMaior = numeroCorrente;
                    intervalos.Add(grupoCorrente);
                    grupoCorrente = new Intervalo(numeroCorrente, null);
                }

            }
            return intervalos;
            //var numerosOrdenados = _numeros.Select(n => new int?(n)).OrderBy(n => n).ToList();

            //var indiceNumero = _numeros.ToDictionary(n => n);
            //var numeroAtual = numerosOrdenados.First();
            //var ultimoNumero = numerosOrdenados.Last();
            //do
            //{
            //    var maiorNumero = numerosOrdenados
            //        .FirstOrDefault(no => no >= numeroAtual + 1 && !indiceNumero.ContainsKey(numeroAtual.GetValueOrDefault() + 1));

            //    intervalos.Add(new Intervalo(numeroAtual.GetValueOrDefault(), maiorNumero));

            //    numeroAtual = numerosOrdenados
            //        .First(no => no > numeroAtual);

            //} while (numeroAtual != ultimoNumero);


            //return intervalos;
        }
    }

    public class Intervalo
    {
        private int _numeroMenor;
        private int? _numeroMaior;

        public Intervalo(int numeroMenor, int? numeroMaior)
        {
            _numeroMaior = numeroMaior;
            _numeroMenor = numeroMenor;
        }

        public int? NumeroMaior {
            get { return _numeroMaior; } 
            set { _numeroMaior = value; } 
        }

        public int NumeroMenor
        {
            get { return _numeroMenor; }
            set { _numeroMenor = value; }
        }

    }
}
