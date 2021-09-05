using System;
using Gurobi;

namespace CaixeiroViajante
{
    class ProblemaTSP
    {
        private int _numeroPontos;
        public double[,] Coordenadas;
        public double[,] MatrizDistancias;
        public GRBEnv Ambiente;
        public GRBModel Modelo;


        public ProblemaTSP(int numeroPontos)
        {
            _numeroPontos = numeroPontos;
        }


        public void CriarResolverModelo()
        {
            Ambiente = new GRBEnv();
            Modelo = new GRBModel(Ambiente)
            {
                ModelSense = GRB.MINIMIZE
            };
            GRBVar[,] X = new GRBVar[_numeroPontos, _numeroPontos];
            // criação das variáveis de decisão da função objetivo
            for(int i = 0; i < _numeroPontos; i++)
            {
                for(int j=0; j < _numeroPontos; j++)
                {
                    X[i, j] = Modelo.AddVar(0, 1, MatrizDistancias[i, j], GRB.BINARY, "X_" + i.ToString() + "_");
                }
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
                        expr.AddTerm(1, X[i, j]);
                    }
                }
                Modelo.AddConstr(expr == 1, "R2_" + i.ToString());
            }

            // para cada ponto a chegada só ocorre por apenas um ponto
            for (int j = 0; j < _numeroPontos; j++)
            {
                for (int i = 0; i < _numeroPontos; i++)
                {
                    if (i != j)
                    {
                        expr.AddTerm(1, X[i, j]);
                    }
                }
                Modelo.AddConstr(expr == 1, "R3_" + j.ToString());
            }
            //escrever modelo
            Modelo.Write(@"C:\gurobi\00tsp.lp");
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
            Console.WriteLine(MatrizDistancias);
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
