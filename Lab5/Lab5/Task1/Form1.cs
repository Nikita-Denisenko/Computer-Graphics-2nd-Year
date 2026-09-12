using System.Drawing.Drawing2D;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

                PointF[] points =
                {
                    new PointF(350, 70),
                    new PointF(570, 230),
                    new PointF(485, 440),
                    new PointF(215, 440),
                    new PointF(130, 230)
                };

                using (HatchBrush brush = new HatchBrush(
                    HatchStyle.DiagonalCross,
                    Color.DarkBlue,
                    Color.LightBlue))
                {
                    graphics.FillPolygon(brush, points);
                }

                string text =
                    "Средняя температура воздуха\n" +
                    "в г. Донецке за шесть месяцев.";

                using (Font font = new Font("Arial", 14, FontStyle.Bold))
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    RectangleF textArea = new RectangleF(
                        160,
                        190,
                        380,
                        130);

                    graphics.DrawString(
                        text,
                        font,
                        Brushes.Black,
                        textArea,
                        format);
                }
            }

            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = bitmap;
            oldImage?.Dispose();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = null;
            oldImage?.Dispose();
        }
    }
}