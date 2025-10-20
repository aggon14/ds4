namespace Laboratorio_123
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLado1 = new System.Windows.Forms.Label();
            this.lblLado2 = new System.Windows.Forms.Label();
            this.lblLado3 = new System.Windows.Forms.Label();
            this.lblSemiperimetro = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.txtSemiperimetro = new System.Windows.Forms.TextBox();
            this.txtLado3 = new System.Windows.Forms.TextBox();
            this.txtLado2 = new System.Windows.Forms.TextBox();
            this.txtLado1 = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.btnSemiperimetro = new System.Windows.Forms.Button();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLado1
            // 
            this.lblLado1.AutoSize = true;
            this.lblLado1.Location = new System.Drawing.Point(12, 54);
            this.lblLado1.Name = "lblLado1";
            this.lblLado1.Size = new System.Drawing.Size(98, 13);
            this.lblLado1.TabIndex = 0;
            this.lblLado1.Text = "Longitud del lado A";
            // 
            // lblLado2
            // 
            this.lblLado2.AutoSize = true;
            this.lblLado2.Location = new System.Drawing.Point(12, 109);
            this.lblLado2.Name = "lblLado2";
            this.lblLado2.Size = new System.Drawing.Size(101, 13);
            this.lblLado2.TabIndex = 1;
            this.lblLado2.Text = "Longitud del lado B ";
            // 
            // lblLado3
            // 
            this.lblLado3.AutoSize = true;
            this.lblLado3.Location = new System.Drawing.Point(12, 161);
            this.lblLado3.Name = "lblLado3";
            this.lblLado3.Size = new System.Drawing.Size(101, 13);
            this.lblLado3.TabIndex = 2;
            this.lblLado3.Text = "Longitud del lado C ";
            // 
            // lblSemiperimetro
            // 
            this.lblSemiperimetro.AutoSize = true;
            this.lblSemiperimetro.Location = new System.Drawing.Point(12, 289);
            this.lblSemiperimetro.Name = "lblSemiperimetro";
            this.lblSemiperimetro.Size = new System.Drawing.Size(114, 13);
            this.lblSemiperimetro.TabIndex = 3;
            this.lblSemiperimetro.Text = "Calcular Semiperimetro";
            // 
            // lblPerimetro
            // 
            this.lblPerimetro.AutoSize = true;
            this.lblPerimetro.Location = new System.Drawing.Point(12, 354);
            this.lblPerimetro.Name = "lblPerimetro";
            this.lblPerimetro.Size = new System.Drawing.Size(91, 13);
            this.lblPerimetro.TabIndex = 4;
            this.lblPerimetro.Text = "Area de Triangulo";
            // 
            // txtSemiperimetro
            // 
            this.txtSemiperimetro.Location = new System.Drawing.Point(175, 286);
            this.txtSemiperimetro.Name = "txtSemiperimetro";
            this.txtSemiperimetro.Size = new System.Drawing.Size(100, 20);
            this.txtSemiperimetro.TabIndex = 5;
            // 
            // txtLado3
            // 
            this.txtLado3.Location = new System.Drawing.Point(175, 158);
            this.txtLado3.Name = "txtLado3";
            this.txtLado3.Size = new System.Drawing.Size(100, 20);
            this.txtLado3.TabIndex = 6;
            // 
            // txtLado2
            // 
            this.txtLado2.Location = new System.Drawing.Point(175, 106);
            this.txtLado2.Name = "txtLado2";
            this.txtLado2.Size = new System.Drawing.Size(100, 20);
            this.txtLado2.TabIndex = 7;
            // 
            // txtLado1
            // 
            this.txtLado1.Location = new System.Drawing.Point(175, 51);
            this.txtLado1.Name = "txtLado1";
            this.txtLado1.Size = new System.Drawing.Size(100, 20);
            this.txtLado1.TabIndex = 8;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(175, 351);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(100, 20);
            this.txtArea.TabIndex = 9;
            // 
            // btnSemiperimetro
            // 
            this.btnSemiperimetro.Location = new System.Drawing.Point(46, 218);
            this.btnSemiperimetro.Name = "btnSemiperimetro";
            this.btnSemiperimetro.Size = new System.Drawing.Size(115, 23);
            this.btnSemiperimetro.TabIndex = 10;
            this.btnSemiperimetro.Text = "Semiperimetro";
            this.btnSemiperimetro.UseVisualStyleBackColor = true;
            this.btnSemiperimetro.Click += new System.EventHandler(this.btnSemiperimetro_Click);
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(233, 218);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(75, 23);
            this.btnArea.TabIndex = 11;
            this.btnArea.Text = "Area";
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(567, 218);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(397, 218);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnArea);
            this.Controls.Add(this.btnSemiperimetro);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtLado1);
            this.Controls.Add(this.txtLado2);
            this.Controls.Add(this.txtLado3);
            this.Controls.Add(this.txtSemiperimetro);
            this.Controls.Add(this.lblPerimetro);
            this.Controls.Add(this.lblSemiperimetro);
            this.Controls.Add(this.lblLado3);
            this.Controls.Add(this.lblLado2);
            this.Controls.Add(this.lblLado1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLado1;
        private System.Windows.Forms.Label lblLado2;
        private System.Windows.Forms.Label lblLado3;
        private System.Windows.Forms.Label lblSemiperimetro;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.TextBox txtSemiperimetro;
        private System.Windows.Forms.TextBox txtLado3;
        private System.Windows.Forms.TextBox txtLado2;
        private System.Windows.Forms.TextBox txtLado1;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button btnSemiperimetro;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

