using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private readonly Color _backgroundColor =
            Color.FromKnownColor(KnownColor.Info);

        private readonly Color _clearColor =
            Color.FromArgb(240, 248, 255);

        private readonly Color _axisColor =
            Color.FromKnownColor(KnownColor.Red);

        private readonly Color _graphColor =
            Color.FromArgb(50, 205, 50);

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Size = new Size(900, 450);

            pictureBox1.BackColor = Color.FromName("Info");
        }

        private void DrawGraph(GraphicsUnit unit)
        {
            using Graphics graphics = pictureBox1.CreateGraphics();

            graphics.PageUnit = unit;

            graphics.Clear(_clearColor);

            RectangleF bounds = graphics.VisibleClipBounds;

            float width = bounds.Width;
            float height = bounds.Height;

            float centerX = width / 2f;
            float centerY = height / 2f;

            using Pen axisPen = new Pen(_axisColor, 1);
            using Pen graphPen = new Pen(_graphColor, 1);

            graphics.DrawLine(axisPen, 0, 0, width - 1, 0);
            graphics.DrawLine(axisPen, width - 1, 0, width - 1, height - 1);
            graphics.DrawLine(axisPen, width - 1, height - 1, 0, height - 1);
            graphics.DrawLine(axisPen, 0, height - 1, 0, 0);

            graphics.DrawLine(
                axisPen,
                0,
                centerY,
                width,
                centerY);

            graphics.DrawLine(
                axisPen,
                centerX,
                0,
                centerX,
                height);

            const float xMin = -2f;
            const float xMax = 2f;

            float xScale = width / (xMax - xMin);

            const float yMax = 13f;

            float yScale = (height / 2f) / yMax;

            PointF previousPoint = GetGraphPoint(
                xMin,
                centerX,
                centerY,
                xScale,
                yScale);

            const float step = 0.01f;

            for (float x = xMin + step; x <= xMax; x += step)
            {
                PointF currentPoint = GetGraphPoint(
                    x,
                    centerX,
                    centerY,
                    xScale,
                    yScale);

                graphics.DrawLine(
                    graphPen,
                    previousPoint,
                    currentPoint);

                previousPoint = currentPoint;
            }
        }

        private PointF GetGraphPoint(
            float x,
            float centerX,
            float centerY,
            float xScale,
            float yScale)
        {
            float y = 3 * x * x + 1;

            float screenX = centerX + x * xScale;
            float screenY = centerY - y * yScale;

            return new PointF(screenX, screenY);
        }

        private void buttonPixel_Click(object sender, EventArgs e)
        {
            DrawGraph(GraphicsUnit.Pixel);
        }

        private void buttonMillimeter_Click(object sender, EventArgs e)
        {
            DrawGraph(GraphicsUnit.Millimeter);
        }

        private void buttonInch_Click(object sender, EventArgs e)
        {
            DrawGraph(GraphicsUnit.Inch);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            using Graphics graphics = pictureBox1.CreateGraphics();

            graphics.PageUnit = GraphicsUnit.Pixel;
            graphics.Clear(_clearColor);
        }
    }
}
