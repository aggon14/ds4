using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSemiperimetro_Click(object sender, EventArgs e)
        {
            double Lado1 = Convert.ToDouble(txtLado1.Text);
            double Lado2 = Convert.ToDouble(txtLado2.Text);
            double Lado3 = Convert.ToDouble(txtLado3.Text);

            CalcularSemiperimetro Semi = new CalcularSemiperimetro(Lado1, Lado2, Lado3);

            txtSemiperimetro.Text = Semi.Semiperimetro().ToString();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            double lado1 = Convert.ToDouble(txtLado1.Text);
            double lado2 = Convert.ToDouble(txtLado2.Text);
            double lado3 = Convert.ToDouble(txtLado3.Text);

            CalcularArea Aria = new CalcularArea(lado1, lado2, lado3);

            txtArea.Text = Aria.Area().ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtLado1.Clear();
            txtLado2.Clear();
            txtLado3.Clear();
            txtArea.Clear();
            txtSemiperimetro.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
