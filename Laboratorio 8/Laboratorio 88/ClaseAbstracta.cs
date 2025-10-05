using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_88
{
    abstract class ClaseAbstracta
    {
        abstract protected string tomarValor();
        abstract public string prefixValor(string prefix);
        public void printOut()
        {
            Console.WriteLine(tomarValor());
        }
    }
    class ClaseConcretal : ClaseAbstracta
    {
        protected override string tomarValor()
        {
            return "ClaseConcretal";
        }
        public override string prefixValor(string prefix)
        {
            return $"{prefix}ClaseConcretal";
        }
    }

    class ClaseConcreta2 : ClaseAbstracta
    {
        protected override string tomarValor()
        {
            return "ClaseConcreta2";

        }
        public override string prefixValor(string prefix)
        {
            return $"{prefix}Claseconcreta2";
            {

            }
        }
    }
}