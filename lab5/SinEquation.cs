using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class SinEquation : Equation
    {
        private readonly double a;

        public SinEquation(double a)
        {
            this.a = a;
        }

        public override double GetValue(double x)
        {
            return Math.Sin(a * x) / x;
        }
    }
}
