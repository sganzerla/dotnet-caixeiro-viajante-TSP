using System;

namespace CaixeiroViajante
{
    class ProblemaTSP
    {
        private int _numeroPontos;
        public double[,] Coordenadas;
        public double[,] MatrizDistancias;



        public ProblemaTSP(int numeroPontos)
        {
            _numeroPontos = numeroPontos;
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
