using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class RectangleIntegrator : Integrator
    {
        private readonly int N;

        public RectangleIntegrator(Equation equation, int N) : base(equation)
        {
            if (N <= 0)
                throw new ArgumentException("Количество интервалов должно быть больше нуля.");
            this.N = N;
        }

        public override double Integrate(double x1, double x2)
        {
            if (x1 >= x2)
                throw new ArgumentException("Правая граница интегрирования должна быть больше левой!");

            double h = (x2 - x1) / N;
            double sum = 0;

            for (int i = 0; i < N; i++)
            {
                sum += equation.GetValue(x1 + i * h) * h;
            }

            return sum;
        }

        public override string MethodName => "Метод прямоугольников";
    }
}
