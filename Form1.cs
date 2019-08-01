using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NumIntegration
{
    public partial class Form1 : Form
    {
        IntegrationMethod p = new IntegrationMethod();
        public Form1()
        {
            InitializeComponent();
            p.CalcIntegrals();

            /* ... */

            PrinValXY(dataGridView1); PrintFuncGraphic(chart1); PrintLeftRec();
            PrinValXY(dataGridView2); PrintFuncGraphic(chart2); PrintRightRec();
            PrinValXY(dataGridView3); PrintFuncGraphic(chart3); PrintMiddleRec();
            PrinValXY(dataGridView4); PrintFuncGraphic(chart4); PrintTrapezium();
            PrinValXY(dataGridView5); PrintFuncGraphic(chart5); PrintSimpsonMethod();
            PrinValXY(dataGridView6); PrintFuncGraphic(chart6); PrintGaussMethod(); 
        }

        void PrinValXY(DataGridView datagridview)
        {
            int cnt = p.points.Count;
            datagridview.ColumnCount = 3;

            datagridview.Rows.Add();
            datagridview.Rows[0].Cells[0].Value = "i";
            datagridview.Rows[0].Cells[1].Value = "Xi";
            datagridview.Rows[0].Cells[2].Value = "f(Xi)";

            for (int i = 1; i <= cnt; i++)
            {
                datagridview.Rows.Add();
                datagridview.Rows[i].Cells[0].Value = i-1;
                datagridview.Rows[i].Cells[1].Value = String.Format("{0:f4}", p.points[i - 1].GetX());
                datagridview.Rows[i].Cells[2].Value = String.Format("{0:f4}", p.points[i - 1].GetY());
            }
        }

        void PrintFuncGraphic(Chart chartName)
        {
            /* ... */

            int cnt = p.points.Count;
            for (int i = 0; i < cnt; i++)
            {
                chartName.Series["graphic"].Points.AddXY(p.points[i].GetX(), p.points[i].GetY());
            }
        }

        void PrintLeftRec()
        {
            int cnt = p.points.Count;
            for (int i = 0; i < cnt-1; i++)
            {
                chart1.Series["RecL"].Points.AddXY(p.points[i].GetX() + p.h / 2, p.points[i].GetY());
            }

            chart1.ApplyPaletteColors();
            foreach (var point in chart1.Series["RecL"].Points)
            {
                point.Color = Color.FromArgb(80, point.Color);
            }
        }

        void PrintRightRec()
        {
            int cnt = p.points.Count;
            for (int i = 1; i < cnt; i++)
            {
                chart2.Series["RecR"].Points.AddXY(p.points[i].GetX() - p.h / 2, p.points[i].GetY());
            }

            chart2.ApplyPaletteColors();
            foreach (var point in chart2.Series["RecR"].Points)
            {
                point.Color = Color.FromArgb(80, point.Color);
            }
        }

        void PrintMiddleRec()
        {
            int cnt = p.points.Count;
            for (int i = 0; i < cnt; i++)
            {
                chart3.Series[0].Points.AddXY(p.points[i].GetX(), p.points[i].GetY());
            }

            chart3.ApplyPaletteColors();
            foreach (var point in chart3.Series["RecM"].Points)
            {
                point.Color = Color.FromArgb(80, point.Color);
            }
        }

        void PrintTrapezium()
        {
            int cnt = p.points.Count;
            for (int i = 0; i < cnt; i++)
            {
                chart4.Series["Trapezium"].Points.AddXY(p.points[i].GetX(), p.points[i].GetY());
            }

            chart4.ApplyPaletteColors();
            foreach (var point in chart4.Series["Trapezium"].Points)
            {
                point.Color = Color.FromArgb(80, point.Color);
            }
        }

        void PrintSimpsonMethod()
        {
            int cnt = p.points.Count;
            for (int i = 1; i < cnt; i++)
            {
                double x0 = p.points[i-1].GetX();
                double x2 = p.points[i].GetX();

                double x1 = (x0 + x2) / 2.0;
                double y1 = p.points[i].GetY() - x0 * p.h * p.h - x2 * p.h;

                chart5.Series["Simps"].Points.AddXY(p.points[i - 1].GetX(), p.points[i - 1].GetY());
                chart5.Series["Simps"].Points.AddXY(x1, y1);
                chart5.Series["Simps"].Points.AddXY(p.points[i].GetX(), p.points[i].GetY());
            }

            chart5.ApplyPaletteColors();
            foreach (var point in chart5.Series["Simps"].Points)
            {
                point.Color = Color.FromArgb(80, point.Color);
            }
        }

        void PrintGaussMethod()
        {
            int cnt = p.points.Count;
            for (int i = 0; i < cnt; i++)
            {
                chart6.Series["Gauss"].Points.AddXY(p.points[i].GetX(), p.points[i].GetY());
            }

            chart6.ApplyPaletteColors();
            chart6.Series[0].Color = Color.FromArgb(80, Color.LightBlue);
        }
    }
}
