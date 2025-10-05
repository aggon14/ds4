﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratotio_89
{
    interface iTemplate
    {
        public void ponerVariable(string nombre, string var);
        public void verHtml(string template);
    }

    class Template : iTemplate
    {
        public void ponerVariable(string nombre, string var)
        {
            Console.WriteLine("Se ha puesto la variable {nombre} : {var}");
        }
        public void verHtml(string template)
        {
            Console.WriteLine(template);
        }
    }
}
