﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void IblHelloWorld_Click(object sender, EventArgs e)
        {
            ;
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            IblHelloWorld.Text = "Hello, World";
        }
    }
}
