using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace moskal_05._03._18_10_f_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int P=0;//сума довжин сторін
        int a;//лічильник намальованих крапок фігури
        int n;//всього крапок в фігурі
        //х і у - масиви точок
        int[] x;
        int[] y;
        double[] P1;//масив довжини кожної прямої
        private void Form1_Load(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            a = -1;
            x = new int[n];
            y = new int[n];
            this.BackColor = Color.White;
            P1 = new double[n+1];
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            a++;
            if (a < n&&a>-1)
            {
                timer1.Enabled = true;
                timer1.Interval = 1;
                x[a] = MousePosition.X - this.Location.X;
                y[a] = MousePosition.Y - this.Location.Y;
                Pen pen = new Pen(Color.Blue, 2);
                Graphics g = CreateGraphics();
                g.DrawEllipse(pen, x[a] - 5, y[a] - 5, 10, 10);
            }
            else
            {
                timer1.Enabled = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
            if (Convert.ToInt32(textBox1.Text) < 3)
            {
                MessageBox.Show("Замало точок для побудови фігури");
            }
            else
            {
                timer1.Enabled = false;
                a = -1;
                n = Convert.ToInt32(textBox1.Text);
                x = new int[n];
                y = new int[n];
                for (int i = 0; i < n; i++)
                {
                    x[i] = 0;
                    y[i] = 0;
                }
                this.Refresh();

                P1 = new double[n + 1];
                P = 0;
                label3.Text = P.ToString();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Drawing.Font font = new System.Drawing.Font(new FontFamily("Arial"),12);
            P = 0;
            Pen pen = new Pen(Color.Blue, 2);
            Pen p = new Pen(Color.Black,3);
            Pen p2 = new Pen(Color.White, 3);
            Graphics g = CreateGraphics();
            for (int j = 0; j < n; j++)
            {
                if(a==j+1&&a!=0&&a!=n-1)
                {
                    g.DrawLine(p, x[j], y[j], x[j + 1], y[j + 1]);
                    P1[j] = Math.Sqrt(Math.Abs(x[j] - x[j + 1]) * Math.Abs(x[j] - x[j + 1]) + Math.Abs(y[j] - y[j + 1]) * Math.Abs(y[j] - y[j + 1]));
                    g.DrawEllipse(pen, x[j] - 5, y[j] - 5, 10, 10);
                }
                if (a == n - 1)
                {
                    g.DrawLine(p, x[a - 1], y[a - 1], x[a], y[a]);
                    g.DrawLine(p, x[0], y[0], x[a], y[a]);
                    P1[a - 1] = Math.Sqrt(Math.Abs(x[a - 2] - x[a - 1]) * Math.Abs(x[a - 2] - x[a - 1]) + Math.Abs(y[a - 2] - y[a - 1]) * Math.Abs(y[a - 2] - y[a - 1]));
                    P1[a] = Math.Sqrt(Math.Abs(x[0] - x[a - 1]) * Math.Abs(x[0] - x[a - 1]) + Math.Abs(y[0] - y[a - 1]) * Math.Abs(y[0] - y[a - 1]));
                    g.DrawEllipse(pen, x[j] - 5, y[j] - 5, 10, 10);
                    g.DrawString((j+1).ToString(), font, Brushes.Blue, x[j] + 10, y[j] + 10);
                    Point[] point;
                    point = new Point[n];
                    for (int i = 0; i < n; i++)
                    {
                        point[i].X = x[i];
                        point[i].Y = y[i];
                    }
                    g.FillPolygon(Brushes.Red, point);
                    
                }
            }
            for (int i = 0; i < a+1; i++)
            {
                g.DrawEllipse(pen, x[i] - 5, y[i] - 5, 10, 10);
                g.DrawString((i+1).ToString(),font,Brushes.Blue,x[i]+10,y[i]+10);
                
            }
            for(int i=0;i<n+1;i++)
            {
                P += Convert.ToInt32(P1[i]);
            }
            label3.Text = P.ToString();
            if(a==n-1)
            {
                timer1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
