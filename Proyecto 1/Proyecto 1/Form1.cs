using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Proyecto_1
{

    public partial class Form1 : Form
    {



        double nume1 = 0;
        double nume2 = 0;
        string operacion = "";



        //impresion de numeros y signos
        public Form1()
        {
            InitializeComponent();
        }





        private void GuardarResultado(string Operacion, double Numero1, double Numero2, double Resultado)
        {
            string conexionBD = @"Server=.\sqlexpress;Database=Proyecto1;Trusted_Connection=True;";
            using (SqlConnection con = new SqlConnection(conexionBD))
            {
                string query = "INSERT INTO Resultados (Operacion, Numero1,Numero2, Resultado) VALUES (@Operacion, @Numero1, @Numero2, @Resultado)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Operacion", Operacion);
                    cmd.Parameters.AddWithValue("@Numero1", Numero1);
                    cmd.Parameters.AddWithValue("@Numero2", Numero2);
                    cmd.Parameters.AddWithValue("@Resultado", Resultado);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
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
        private void btnN9_Click_1(object sender, EventArgs e)
        {
            double numero = 9;
            textBox1.Text += numero.ToString();
        }




        private void btnN0_Click(object sender, EventArgs e)
        {
            double numero = 0;
            textBox1.Text += numero.ToString();
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "-";
                return;
            }

            if (double.TryParse(textBox1.Text, out double valor))
            {
                valor = -valor;
                textBox1.Text = valor.ToString();
            }
        }








        // logica de operaciones binarias 
        private void bntSuma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un número primero.");
                return;
            }

            if (!double.TryParse(textBox1.Text, out nume1))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            operacion = "Suma";
            textBox1.Clear();
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un número primero.");
                return;
            }

            if (!double.TryParse(textBox1.Text, out nume1))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            operacion = "Resta";
            textBox1.Clear();
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un número primero.");
                return;
            }

            if (!double.TryParse(textBox1.Text, out nume1))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            operacion = "Multiplicacion";
            textBox1.Clear();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un número primero.");
                return;
            }

            if (!double.TryParse(textBox1.Text, out nume1))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            operacion = "Division";
            textBox1.Clear();
        }




        //logica de operaciones unitarias
        private void btncua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un número primero.");
                return;
            }

            if (!double.TryParse(textBox1.Text, out double valor))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            Cuadrado c = new Cuadrado(valor);
            double resultado = c.Operacion();

            textBox1 .Text = resultado.ToString();

            try
            {
                GuardarResultado("Cuadrado", valor, 0, resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar resultado: " + ex.Message);
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un número primero.");
                return;
            }

            if (!double.TryParse(textBox1.Text, out double nume1))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            if (nume1 < 0)
            {
                MessageBox.Show("No se puede calcular la raíz cuadrada de un número negativo.");
                return;
            }

            double resultado = Math.Sqrt(nume1);

            textBox1.Text = resultado.ToString();

            try
            {
                GuardarResultado("Raiz", nume1, 0, resultado);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("ERROR"+ex.ToString());
            }

        }






















        //logica de resultado
        private void btnIgual_Click(object sender, EventArgs e)
        {
            double resultado = 0;

            if (operacion == "Cuadrado")
            {
                Cuadrado c = new Cuadrado(nume1);
                resultado = c.Operacion();
            }
            else if (operacion == "Raiz")
            {
                if (nume1 < 0)
                {
                    MessageBox.Show("No se puede calcular la raíz cuadrada de un número negativo.");
                    return;
                }
                Raiz r = new Raiz(nume1);
                resultado = r.Operacion();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Ingresa el segundo número.");
                    return;
                }

                if (!double.TryParse(textBox1.Text, out nume2))
                {
                    MessageBox.Show("Segundo número inválido.");
                    return;
                }

                switch (operacion)
                {
                    case "Suma":
                        Suma sum = new Suma(nume1, nume2);
                        resultado = sum.Operacion();
                        break;

                    case "Resta":
                        Resta r2 = new Resta(nume1, nume2);
                        resultado = r2.Operacion();
                        break;

                    case "Multiplicacion":
                        Multiplicacion m = new Multiplicacion(nume1, nume2);
                        resultado = m.Operacion();
                        break;

                    case "Division":
                        if (nume2 == 0)
                        {
                            MessageBox.Show("No se puede dividir entre cero.");
                            return;
                        }
                        Division d = new Division(nume1, nume2);
                        resultado = d.Operacion();
                        break;

                    default:
                        MessageBox.Show("Operación no seleccionada.");
                        return;
                }
            }
            textBox1.Text = resultado.ToString();
            try
            {
                if (operacion == "Suma" || operacion == "Resta" || operacion == "Multiplicacion" || operacion == "Division")
                {
                    GuardarResultado(operacion, nume1, nume2, resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar resultado: " + ex.Message);
            }
            operacion = "";
        }




        //botones de borrado
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
       
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                MessageBox.Show("Ya borraste todo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conexionBD = @"Server=.\sqlexpress;Database=Proyecto1;Trusted_Connection=True;";
            string mensaje = "HISTORIAL DE OPERACIONES:\n\n";

            try
            {
                using (SqlConnection con = new SqlConnection(conexionBD))
                {
                    string query = "SELECT * FROM Resultados ORDER BY Id DESC";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        mensaje += $"ID: {reader["Id"]}\n";
                        mensaje += $"Operación: {reader["Operacion"]}\n";
                        mensaje += $"Número 1: {reader["Numero1"]}\n";
                        mensaje += $"Número 2: {reader["Numero2"]}\n";
                        mensaje += $"Resultado: {reader["Resultado"]}\n";
                        mensaje += $"Fecha: {reader["Fecha"]}\n";
                        mensaje += "\n\n";
                    }

                    reader.Close();
                }

                MessageBox.Show(mensaje, "Historial de Operaciones");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registros: " + ex.Message);
            }
        }
    }   
}   






