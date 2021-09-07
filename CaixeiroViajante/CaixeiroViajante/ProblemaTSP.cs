using System;
using System.Diagnostics;
using System.Windows.Forms;
using Gurobi;

namespace CaixeiroViajante
{
    class ProblemaTSP
    {
        private readonly int _numeroPontos;
        private readonly string _pathRelatorio;
        public double[,] Coordenadas;
        public double[,] MatrizDistancias;
        public GRBEnv Ambiente;
        public GRBModel Modelo;


        public ProblemaTSP(int numeroPontos, string pathRelatorio)
        {
            _numeroPontos = numeroPontos;
            _pathRelatorio = pathRelatorio;
        }


        public void CriarResolverModelo()
        {
            Ambiente = new GRBEnv();
            Modelo = new GRBModel(Ambiente)
            {
                ModelSense = GRB.MINIMIZE
            };
            GRBVar[,] X = new GRBVar[_numeroPontos, _numeroPontos];
            GRBVar[] U = new GRBVar[_numeroPontos];
            // criação das variáveis de decisão da função objetivo
            for(int i = 0; i < _numeroPontos; i++)
            {
                for(int j=0; j < _numeroPontos; j++)
                {
                    // função objetivo
                    X[i, j] = Modelo.AddVar(lb: 0, ub: 1, obj: MatrizDistancias[i, j], type: GRB.BINARY, name: $"X_{i}");
                }
            }

            U[0] = Modelo.AddVar(lb: 0, ub: 10000000, obj: 0, type: GRB.CONTINUOUS, name: $"u_{0}");

            for (int i = 1; i < _numeroPontos; i++)
            {
                U[i] = Modelo.AddVar(lb: 1, ub: 10000000, obj: 0, type: GRB.CONTINUOUS, name: $"u_{i}");
            }

            // de cada ponto sai para exatamento um ponto
            GRBLinExpr expr = new();
            for (int i = 0; i < _numeroPontos;   i++)
            {
                expr.Clear();
                for (int j = 0; j < _numeroPontos; j++)
                {
                    if (i != j)
                    {
                        expr.AddTerm(coeff: 1, var: X[i, j]);
                    }
                }
                // restrição 2
                Modelo.AddConstr(constr: expr == 1, name: $"R2_{i}");
            }

            // para cada ponto a chegada só ocorre por apenas um ponto
            for (int j = 0; j < _numeroPontos; j++)
            {
                expr.Clear();
                for (int i = 0; i < _numeroPontos; i++)
                {
                    if (i != j)
                    {
                        expr.AddTerm(coeff: 1, var: X[i, j]);
                    }
                }
                // restrição 3
                Modelo.AddConstr(constr: expr == 1, name: $"R3_{j}");
            }

            // Restrição MTZ
            Modelo.AddConstr(constr: U[0] == 0, name: "Ryyyyy");
            for (int i = 1; i < _numeroPontos; i++)
            {
                for (int j = 1; j < _numeroPontos; j++)
                {
                    if(i!=j)
                    Modelo.AddConstr(U[i] - U[j] + (_numeroPontos - 1) * X[i, j] <= _numeroPontos - 1 - 1, name: $"RMTZ_{i}_{j}");
                }
            }

            //escrever modelo
            Modelo.Write(filename: @$"{_pathRelatorio}\00tsp.lp");
            Stopwatch cronometro = new();
            cronometro.Start();
            Modelo.Optimize();

            cronometro.Stop();
            MessageBox.Show(cronometro.ElapsedMilliseconds.ToString());
            Modelo.Write(filename: @$"{_pathRelatorio}\00tsp.sol");

        }

        public   void GerarPontosAleatorios()
        {
            Coordenadas = new double[_numeroPontos, 2];
            Random aleatorio = new(1);
            for (int i =0; i< _numeroPontos; i++)
            {
                Coordenadas[i, 0] = 10 + aleatorio.NextDouble()*490;
                Coordenadas[i, 1] = 10 + aleatorio.NextDouble()*490;
            }
        }

        public   void CalcularMatrizDistancias()
        {
            MatrizDistancias = new double[_numeroPontos, _numeroPontos];
            for(int i=0; i< _numeroPontos; i++)
            {
                for (int j=0; j < _numeroPontos; j++)
                {
                    double x1 = Coordenadas[i, 0];
                    double y1 = Coordenadas[i, 1];
                    double x2 = Coordenadas[j, 0];
                    double y2 = Coordenadas[j, 1];
                    MatrizDistancias[i, j] = CalcularDistanciaEuclidiana2Pontos(x1, y1, x2, y2);
                 }
            }
        }

        public static double CalcularDistanciaEuclidiana2Pontos(double x1, double y1, double x2, double y2)
        {
            // fórmula distância euclidiana entre dois pontos
            // raiz((x2-x1)^2 + (y2-y1)^2)
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

    }
}
