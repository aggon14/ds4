﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_85
{
    public partial class Coordenadas
    {
        private int x;
        private int y;

        public Coordenadas(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Coordenadas
    {
        public void verCoordenadas()
        {
            Console.WriteLine("Coordenadas: {0},{1}", x,y);
        }
    }
}
