using System.Drawing.Drawing2D;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.BackColor = Color.White;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(
                pictureBox1.Width,
                pictureBox1.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                DrawDragon(graphics);
            }

            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = bitmap;

            oldImage?.Dispose();
        }

        private void DrawDragon(Graphics graphics)
        {
            string formula = "110110011100100";

            float length = 50;
            float x = 0;
            float y = 0;
            double angle = 0;

            PointF[] points = new PointF[formula.Length + 1];

            points[0] = new PointF(x, y);

            for (int i = 0; i < formula.Length; i++)
            {
                double radians = angle * Math.PI / 180.0;

                x += (float)(Math.Cos(radians) * length);
                y += (float)(Math.Sin(radians) * length);

                points[i + 1] = new PointF(x, y);

                if (i < formula.Length - 1)
                {
                    if (formula[i] == '1')
                    {
                        angle -= 90;
                    }
                    else
                    {
                        angle += 90;
                    }
                }
            }

            PointF tail = points[0];
            PointF head = points[^1];

            float dx = head.X - tail.X;
            float dy = head.Y - tail.Y;

            double dragonAngle =
                Math.Atan2(dy, dx) * 180.0 / Math.PI;

            double rotation = -dragonAngle;

            double rotationRadians =
                rotation * Math.PI / 180.0;

            float cos = (float)Math.Cos(rotationRadians);
            float sin = (float)Math.Sin(rotationRadians);

            for (int i = 0; i < points.Length; i++)
            {
                float rotatedX =
                    points[i].X * cos -
                    points[i].Y * sin;

                float rotatedY =
                    points[i].X * sin +
                    points[i].Y * cos;

                points[i] = new PointF(
                    rotatedX,
                    rotatedY);
            }

            float minX = points.Min(p => p.X);
            float maxX = points.Max(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxY = points.Max(p => p.Y);

            float dragonCenterX =
                (minX + maxX) / 2f;

            float dragonCenterY =
                (minY + maxY) / 2f;

            float pictureCenterX =
                pictureBox1.Width / 2f;

            float pictureCenterY =
                pictureBox1.Height / 2f;

            float offsetX =
                pictureCenterX - dragonCenterX;

            float offsetY =
                pictureCenterY - dragonCenterY;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(
                    points[i].X + offsetX,
                    points[i].Y + offsetY);
            }

            using Pen dragonPen =
                new Pen(Color.Black, 3);

            dragonPen.DashStyle =
                DashStyle.Dash;

            graphics.DrawLines(
                dragonPen,
                points);

            PointF finalHead = points[^1];

            double finalAngle =
                angle + rotation;

            DrawHead(
                graphics,
                finalHead,
                finalAngle);
        }

        private void DrawHead(
            Graphics graphics,
            PointF position,
            double angle)
        {
            using Pen headPen =
                new Pen(Color.Black, 3);

            headPen.DashStyle =
                DashStyle.DashDot;

            double radians =
                angle * Math.PI / 180.0;

            float headLength = 30;
            float headWidth = 20;

            PointF direction = new PointF(
                (float)Math.Cos(radians),
                (float)Math.Sin(radians));

            PointF perpendicular = new PointF(
                -direction.Y,
                direction.X);

            PointF nose = new PointF(
                position.X +
                direction.X * headLength,

                position.Y +
                direction.Y * headLength);

            PointF upper = new PointF(
                position.X +
                perpendicular.X * headWidth / 2,

                position.Y +
                perpendicular.Y * headWidth / 2);

            PointF lower = new PointF(
                position.X -
                perpendicular.X * headWidth / 2,

                position.Y -
                perpendicular.Y * headWidth / 2);

            graphics.DrawLine(
                headPen,
                upper,
                nose);

            graphics.DrawLine(
                headPen,
                nose,
                lower);

            graphics.DrawLine(
                headPen,
                lower,
                upper);

            PointF mouthStart = new PointF(
                nose.X -
                direction.X * 10 +
                perpendicular.X * 5,

                nose.Y -
                direction.Y * 10 +
                perpendicular.Y * 5);

            PointF mouthEnd = new PointF(
                nose.X -
                direction.X * 10 -
                perpendicular.X * 5,

                nose.Y -
                direction.Y * 10 -
                perpendicular.Y * 5);

            graphics.DrawLine(
                headPen,
                mouthStart,
                mouthEnd);

            PointF eye = new PointF(
                position.X +
                direction.X * 12 +
                perpendicular.X * 5,

                position.Y +
                direction.Y * 12 +
                perpendicular.Y * 5);

            using Brush brush =
                new SolidBrush(Color.Black);

            graphics.FillEllipse(
                brush,
                eye.X - 2,
                eye.Y - 2,
                4,
                4);
        }

        private void buttonClear_Click(
            object sender,
            EventArgs e)
        {
            Image? oldImage = pictureBox1.Image;

            pictureBox1.Image = null;

            oldImage?.Dispose();
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            pictureBox1.Image?.Dispose();

            base.OnFormClosed(e);
        }
    }
}