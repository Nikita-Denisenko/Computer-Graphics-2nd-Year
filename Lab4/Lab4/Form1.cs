using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private const string DragonFormula = "110110011100100";
        private const float Step = 35f;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            PointF[] points = BuildDragon();

            using (Pen dragonPen = new Pen(Color.Black, 3f))
            using (Pen headPen = new Pen(Color.Black, 20f))
            {
                // Кривая дракона — прерывистая линия.
                dragonPen.DashStyle = DashStyle.Dash;

                // Голова — комбинированное перо.
                headPen.CompoundArray = new float[]
                {
                    0.0f, 0.20f,
                    0.35f, 0.65f,
                    0.80f, 1.0f
                };

                for (int i = 0; i < points.Length - 2; i++)
                {
                    g.DrawLine(
                        dragonPen,
                        points[i],
                        points[i + 1]);
                }

                // Последний отрезок является головой.
                g.DrawLine(
                    headPen,
                    points[points.Length - 2],
                    points[points.Length - 1]);
            }
        }

        private PointF[] BuildDragon()
        {
            PointF[] points = new PointF[DragonFormula.Length + 1];

            float angle = 0f;
            float x = 0f;
            float y = 0f;

            points[0] = new PointF(x, y);

            for (int i = 0; i < DragonFormula.Length; i++)
            {
                x += Step * (float)Math.Cos(angle * Math.PI / 180f);
                y += Step * (float)Math.Sin(angle * Math.PI / 180f);

                points[i + 1] = new PointF(x, y);

                if (DragonFormula[i] == '1')
                    angle += 90f;
                else
                    angle -= 90f;
            }

            float dx = points[points.Length - 1].X - points[0].X;
            float dy = points[points.Length - 1].Y - points[0].Y;

            float rotation =
                (float)(-Math.Atan2(dy, dx) * 180.0 / Math.PI);

            float radians = rotation * (float)Math.PI / 180f;

            float cos = (float)Math.Cos(radians);
            float sin = (float)Math.Sin(radians);

            for (int i = 0; i < points.Length; i++)
            {
                float oldX = points[i].X;
                float oldY = points[i].Y;

                points[i] = new PointF(
                    oldX * cos - oldY * sin,
                    oldX * sin + oldY * cos);
            }

            float minX = points[0].X;
            float maxX = points[0].X;
            float minY = points[0].Y;
            float maxY = points[0].Y;

            foreach (PointF point in points)
            {
                minX = Math.Min(minX, point.X);
                maxX = Math.Max(maxX, point.X);
                minY = Math.Min(minY, point.Y);
                maxY = Math.Max(maxY, point.Y);
            }

            float scale = Math.Min(
                (ClientSize.Width - 100f) /
                Math.Max(maxX - minX, 1f),

                (ClientSize.Height - 100f) /
                Math.Max(maxY - minY, 1f));

            scale = Math.Min(scale, 1.8f);

            float centerX = ClientSize.Width / 2f;
            float centerY = ClientSize.Height / 2f;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(
                    centerX +
                    (points[i].X - (minX + maxX) / 2f) * scale,

                    centerY +
                    (points[i].Y - (minY + maxY) / 2f) * scale);
            }

            return points;
        }
    }
}