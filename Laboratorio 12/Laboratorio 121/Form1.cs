using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_121
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double velocidad = Convert.ToDouble(txtVelocidad.Text);
            double tiempo = Convert.ToDouble(txtTiempo.Text);

            CalculoDistancia calc = new CalculoDistancia(velocidad, tiempo);


            txtResultado.Text = calc.Calcular().ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            txtTiempo.Clear();
            txtVelocidad.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
