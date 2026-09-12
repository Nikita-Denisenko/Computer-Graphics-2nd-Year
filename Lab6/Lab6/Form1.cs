using System.Drawing.Drawing2D;

namespace Lab6
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
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.LightSkyBlue);

                using (SolidBrush seaBrush = new SolidBrush(Color.RoyalBlue))
                {
                    graphics.FillRectangle(
                        seaBrush,
                        0,
                        300,
                        pictureBox1.Width,
                        pictureBox1.Height - 300);
                }

                using (SolidBrush sunBrush = new SolidBrush(Color.Gold))
                {
                    graphics.FillEllipse(
                        sunBrush,
                        560,
                        45,
                        90,
                        90);
                }

                using (Pen wavePen = new Pen(Color.White, 3))
                {
                    for (int y = 330; y <= 470; y += 35)
                    {
                        for (int x = 0; x < pictureBox1.Width; x += 80)
                        {
                            graphics.DrawArc(
                                wavePen,
                                x,
                                y,
                                80,
                                25,
                                180,
                                180);
                        }
                    }
                }

                PointF[] hull =
                {
                    new PointF(180, 275),
                    new PointF(560, 275),
                    new PointF(500, 345),
                    new PointF(250, 345)
                };

                using (SolidBrush hullBrush =
                       new SolidBrush(Color.SaddleBrown))
                {
                    graphics.FillPolygon(hullBrush, hull);
                }

                using (Pen hullPen = new Pen(Color.Black, 3))
                {
                    graphics.DrawPolygon(hullPen, hull);
                }

                using (SolidBrush deckBrush =
                       new SolidBrush(Color.Peru))
                {
                    graphics.FillRectangle(
                        deckBrush,
                        230,
                        245,
                        280,
                        30);
                }

                using (Pen mastPen = new Pen(Color.SaddleBrown, 8))
                {
                    graphics.DrawLine(
                        mastPen,
                        370,
                        245,
                        370,
                        90);
                }

                PointF[] sail =
                {
                    new PointF(365, 105),
                    new PointF(365, 235),
                    new PointF(270, 235)
                };

                using (SolidBrush sailBrush =
                       new SolidBrush(Color.WhiteSmoke))
                {
                    graphics.FillPolygon(sailBrush, sail);
                }

                using (Pen sailPen = new Pen(Color.Black, 2))
                {
                    graphics.DrawPolygon(sailPen, sail);
                }

                PointF[] secondSail =
                {
                    new PointF(375, 125),
                    new PointF(375, 235),
                    new PointF(465, 235)
                };

                using (SolidBrush sailBrush =
                       new SolidBrush(Color.WhiteSmoke))
                {
                    graphics.FillPolygon(sailBrush, secondSail);
                }

                using (Pen sailPen = new Pen(Color.Black, 2))
                {
                    graphics.DrawPolygon(sailPen, secondSail);
                }

                using (SolidBrush cabinBrush =
                       new SolidBrush(Color.Beige))
                {
                    graphics.FillRectangle(
                        cabinBrush,
                        430,
                        200,
                        80,
                        45);
                }

                using (Pen cabinPen = new Pen(Color.Black, 2))
                {
                    graphics.DrawRectangle(
                        cabinPen,
                        430,
                        200,
                        80,
                        45);
                }

                using (SolidBrush windowBrush =
                       new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(
                        windowBrush,
                        445,
                        210,
                        18,
                        15);

                    graphics.FillRectangle(
                        windowBrush,
                        475,
                        210,
                        18,
                        15);
                }

                using (Pen windowPen = new Pen(Color.Black, 2))
                {
                    graphics.DrawRectangle(
                        windowPen,
                        445,
                        210,
                        18,
                        15);

                    graphics.DrawRectangle(
                        windowPen,
                        475,
                        210,
                        18,
                        15);
                }

                using (SolidBrush flagBrush =
                       new SolidBrush(Color.Red))
                {
                    PointF[] flag =
                    {
                        new PointF(370, 90),
                        new PointF(420, 105),
                        new PointF(370, 120)
                    };

                    graphics.FillPolygon(flagBrush, flag);
                }

                using (Pen flagPen = new Pen(Color.Black, 2))
                {
                    graphics.DrawLine(
                        flagPen,
                        370,
                        90,
                        370,
                        120);
                }

                using (SolidBrush cloudBrush =
                       new SolidBrush(Color.White))
                {
                    graphics.FillEllipse(
                        cloudBrush,
                        80,
                        70,
                        100,
                        45);

                    graphics.FillEllipse(
                        cloudBrush,
                        125,
                        50,
                        100,
                        65);

                    graphics.FillEllipse(
                        cloudBrush,
                        175,
                        70,
                        100,
                        45);
                }

                using (Pen cloudPen = new Pen(Color.LightGray, 2))
                {
                    graphics.DrawEllipse(
                        cloudPen,
                        80,
                        70,
                        100,
                        45);

                    graphics.DrawEllipse(
                        cloudPen,
                        125,
                        50,
                        100,
                        65);

                    graphics.DrawEllipse(
                        cloudPen,
                        175,
                        70,
                        100,
                        45);
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