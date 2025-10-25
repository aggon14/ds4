using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{

    public partial class Form1 : Form
    {
        double nume1 = 0;
        double nume2 = 0;
        string operacion = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void btnN1_Click(object sender, EventArgs e)
        {
            double numero = 1;
            textBox1.Text += numero.ToString();

        }

        private void btnN2_Click(object sender, EventArgs e)
        {
            double numero = 2;
            textBox1.Text += numero.ToString();
        }

        private void btnN3_Click(object sender, EventArgs e)
        {
            double numero = 3;
            textBox1.Text += numero.ToString();
        }

        private void btnN4_Click(object sender, EventArgs e)
        {
            double numero = 4;
            textBox1.Text += numero.ToString();
        }

        private void btnN5_Click(object sender, EventArgs e)
        {
            double numero = 5;
            textBox1.Text += numero.ToString();
        }

        private void btnN6_Click(object sender, EventArgs e)
        {
            double numero = 6;
            textBox1.Text += numero.ToString();
        }

        private void btnN7_Click(object sender, EventArgs e)
        {
            int numero = 7;
            textBox1.Text += numero.ToString();
        }

        private void btnN8_Click(object sender, EventArgs e)
        {
            double numero = 8;
            textBox1.Text += numero.ToString();
        }

        private void btnN9_Click(object sender, EventArgs e)
        {
            double numero = 9;
            textBox1.Text += numero.ToString();
        }

        private void btnN0_Click(object sender, EventArgs e)
        {
            double numero = 0;
            textBox1.Text += numero.ToString();
        }

        private void bntSuma_Click(object sender, EventArgs e)
        {
            nume1 = double.Parse(textBox1.Text);
            operacion = "Suma";
            textBox1.Clear();
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            nume1 = double.Parse(textBox1.Text);
            operacion = "Resta";
            textBox1.Clear();
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            nume1 = double.Parse(textBox1.Text);
            operacion = "Multiplicacion";
            textBox1.Clear();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            nume1 = int.Parse(textBox1.Text);
            operacion = "Division";
            textBox1.Clear();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {

            nume2 = double.Parse(textBox1.Text);

            double resultado = 0;


            switch (operacion)
            {
                case "Suma":
                    Suma sum = new Suma(nume1, nume2);
                        resultado = sum.Operacion();
                        break;

                case "Resta":
                    Resta r = new Resta(nume1, nume2);
                    resultado = r.Operacion();
                    break;

                case "Multiplicacion":
                    Multiplicacion m = new Multiplicacion(nume1, nume2);
                    resultado = m.Operacion();
                    break;

                case "Division":
                    Division d = new Division(nume1, nume2);
                    resultado = d.Operacion();
                    break;  
            }

            textBox1.Text = resultado.ToString();

        }
    }
}   
