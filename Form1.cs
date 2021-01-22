using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Distributions;
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(0.0);
            textBox2.Text = Convert.ToString(1.0);
            textBox3.Text = Convert.ToString(10);
        }
        Random ran = new Random();
        public  void GaussMethod(double[] massive, double mu, double sigma, int num, int chart, int chart_2)
        {
            double x,y, h = 1;
            int i_1 = 1;
            double max=0, min=0;
            double dSumm = 0, dRandValue = 0;
        
            for (int n = 0; n <= num; n++)
            {
                dSumm = 0;
                for (int i = 0; i <= num; i++)
                {
                    double R = ran.NextDouble();
                    dSumm = dSumm + R;
                }
                dRandValue = Math.Round(mu + sigma * (dSumm - ((num+1)/2)), 3);
                massive[n] = dRandValue;
                chart1.Series[chart].Points.AddXY(i_1 ,massive[n]);
                i_1++;
            }
            x = ((mu-3*sigma)-1);
            while (x <= (mu + 3 * sigma) + 1)
            {

                y = (1 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(Math.Pow(x - mu, 2) / (2*(Math.Pow(sigma,2)))));
                this.chart2.Series[chart_2].Points.AddXY(x, y);
                x += h;
            }
           // double k = 1;
           // x = ((mu - 3 * sigma) - 1);
           //double k1=MathNet.Numerics.SpecialFunctions.Gamma(k/2);
           // //MessageBox.Show(Convert.ToString(MathNet.Numerics.SpecialFunctions.Gamma(k/2)));
           // while (x <= (mu + 3 * sigma) + 1)
           // {
           //     //double hi = MathNet.Numerics.Distributions.ChiSquared.PDF(4, x);
           //     double hi = (Math.Pow(1 / 2, k / 2)) / (k1) * Math.Pow(dRandValue, k / 2 - 1) * Math.Exp(-dRandValue / 2);
           //     this.chart3.Series[0].Points.AddXY(hi, x);
           //     x += h;
           // }
            
        }
        int chart = 0;
        int chart_2 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //chart2.Series[0].Points.Clear();
            if(chart==10)
            {
                MessageBox.Show("Предельное колличество");
                return;
            }
            double[] mas = new double[Convert.ToInt32(textBox3.Text)];
            GaussMethod(mas,Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32(textBox3.Text)-1,chart,chart_2);
            chart++;
            chart_2++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<=chart-1;i++)
            chart1.Series[i].Points.Clear();
            chart = 0;
        }
    }
}
