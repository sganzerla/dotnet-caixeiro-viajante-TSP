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
            ProblemaTSP MeuProblema = new(numeroPontos:  Convert.ToInt32( textBoxCountPoints.Text), pathRelatorio: textBoxPathReport.Text);
            MeuProblema.GerarPontosAleatorios();
            MeuProblema.CalcularMatrizDistancias();
            MeuProblema.CriarResolverModelo();
        }

        private void ButtonChangedPath_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPathReport.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
