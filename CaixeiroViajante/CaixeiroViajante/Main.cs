using System;
using System.Windows.Forms;

namespace CaixeiroViajante
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProblemaTSP MeuProblema = new(numeroPontos:8);
            MeuProblema.GerarPontosAleatorios();
            MeuProblema.CalcularMatrizDistancias();
        }
    }
}
