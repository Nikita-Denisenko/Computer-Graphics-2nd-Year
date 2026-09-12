using System.Drawing.Drawing2D;

namespace Task2
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

                int[] temperatures = { 10, 16, 20, 23, 22, 16 };
                string[] months =
                {
                    "Апрель",
                    "Май",
                    "Июнь",
                    "Июль",
                    "Август",
                    "Сентябрь"
                };

                int zeroY = 430;
                int scale = 12;
                int barWidth = 65;
                int gap = 35;
                int startX = 65;

                using (Pen axisPen = new Pen(Color.Black, 2))
                using (Pen gridPen = new Pen(Color.Gray, 1))
                using (Font font = new Font("Arial", 10))
                using (Font valueFont = new Font("Arial", 10, FontStyle.Bold))
                {
                    gridPen.DashStyle = DashStyle.Dash;

                    graphics.DrawLine(
                        axisPen,
                        40,
                        zeroY,
                        pictureBox1.Width - 30,
                        zeroY);

                    for (int temperature = 5; temperature <= 25; temperature += 5)
                    {
                        int y = zeroY - temperature * scale;

                        graphics.DrawLine(
                            gridPen,
                            40,
                            y,
                            pictureBox1.Width - 30,
                            y);

                        graphics.DrawString(
                            temperature.ToString(),
                            font,
                            Brushes.Black,
                            10,
                            y - 8);
                    }

                    for (int i = 0; i < temperatures.Length; i++)
                    {
                        int height = temperatures[i] * scale;
                        int x = startX + i * (barWidth + gap);
                        int y = zeroY - height;

                        Rectangle rectangle = new Rectangle(
                            x,
                            y,
                            barWidth,
                            height);

                        if (i == 0 || i == 3)
                        {
                            using (SolidBrush brush =
                                   new SolidBrush(Color.SteelBlue))
                            {
                                graphics.FillRectangle(brush, rectangle);
                            }
                        }
                        else if (i == 1 || i == 4)
                        {
                            using (HatchBrush brush =
                                   new HatchBrush(
                                       HatchStyle.DiagonalCross,
                                       Color.DarkGreen,
                                       Color.LightGreen))
                            {
                                graphics.FillRectangle(brush, rectangle);
                            }
                        }
                        else
                        {
                            using (Bitmap texture = new Bitmap(10, 10))
                            {
                                using (Graphics textureGraphics =
                                       Graphics.FromImage(texture))
                                {
                                    textureGraphics.Clear(Color.LightGray);

                                    using (Pen texturePen =
                                           new Pen(Color.DarkRed, 2))
                                    {
                                        textureGraphics.DrawLine(
                                            texturePen,
                                            0,
                                            10,
                                            10,
                                            0);
                                    }
                                }

                                using (TextureBrush brush =
                                       new TextureBrush(texture))
                                {
                                    graphics.FillRectangle(brush, rectangle);
                                }
                            }
                        }

                        graphics.DrawRectangle(
                            Pens.Black,
                            rectangle);

                        string value = temperatures[i] + " °C";
                        SizeF valueSize =
                            graphics.MeasureString(value, valueFont);

                        graphics.DrawString(
                            value,
                            valueFont,
                            Brushes.Black,
                            x + (barWidth - valueSize.Width) / 2,
                            y - valueSize.Height - 5);

                        SizeF monthSize =
                            graphics.MeasureString(months[i], font);

                        graphics.DrawString(
                            months[i],
                            font,
                            Brushes.Black,
                            x + (barWidth - monthSize.Width) / 2,
                            zeroY + 8);
                    }
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