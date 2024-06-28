using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // уравнения
            Equation quadEquation = new QuadEquation(1, -2, 1); // y = x^2 - 2x + 1
            Equation sinEquation = new SinEquation(2); // y = sin(2x)/x

            
            Integrator rectIntegrator = new RectangleIntegrator(quadEquation, 100);
            Integrator trapIntegrator = new TrapezoidIntegrator(sinEquation, 100);

            // Интегрирование
            double rectResult = rectIntegrator.Integrate(0, 10);
            double trapResult = trapIntegrator.Integrate(1, 10);

            // Вывод результатов
            Console.WriteLine($"Интеграл методом прямоугольников: {rectResult}");
            Console.WriteLine($"Интеграл методом трапеций: {trapResult}");

            // График
            var series1 = new Series
            {
                ChartType = SeriesChartType.Line
            };

            DrawFunction(0, 10, series1, quadEquation);
            chart1.Series.Add(series1);
        }

        public static void DrawFunction(double x1, double x2, Series series, Equation equation)
        {
            double step = (x2 - x1) / 100; // Шаг для графика
            for (double x = x1; x <= x2; x += step)
            {
                double y = equation.GetValue(x);
                series.Points.AddXY(x, y);
            }
        }
    }
}
