using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public abstract class Integrator
    {
        protected readonly Equation equation;
        protected Integrator(Equation equation)
        {
            this.equation = equation ?? throw new ArgumentNullException();
        }
        public abstract double Integrate(double x1, double x2);
        public abstract string MethodName { get; }
    }
}
