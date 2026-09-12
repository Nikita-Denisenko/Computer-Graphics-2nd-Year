using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private readonly Timer animationTimer;
        private int ufoY = 80;
        private bool landed;

        public Form1()
        {
            InitializeComponent();

            animationTimer = new Timer();
            animationTimer.Interval = 30;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ufoY = 80;
            landed = false;
            animationTimer.Start();
            DrawScene();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (ufoY < 210)
            {
                ufoY += 2;
                DrawScene();
            }
            else
            {
                landed = true;
                animationTimer.Stop();
                DrawScene();
            }
        }

        private void DrawScene()
        {
            Bitmap bitmap = new Bitmap(
                pictureBox1.Width,
                pictureBox1.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.MidnightBlue);

                using (SolidBrush moonBrush =
                       new SolidBrush(Color.LightYellow))
                {
                    graphics.FillEllipse(
                        moonBrush,
                        650,
                        40,
                        80,
                        80);
                }

                using (Pen starPen = new Pen(Color.White, 2))
                {
                    graphics.DrawLine(starPen, 80, 60, 80, 75);
                    graphics.DrawLine(starPen, 73, 67, 87, 67);

                    graphics.DrawLine(starPen, 180, 100, 180, 115);
                    graphics.DrawLine(starPen, 173, 107, 187, 107);

                    graphics.DrawLine(starPen, 500, 60, 500, 75);
                    graphics.DrawLine(starPen, 493, 67, 507, 67);

                    graphics.DrawLine(starPen, 740, 150, 740, 165);
                    graphics.DrawLine(starPen, 733, 157, 747, 157);
                }

                using (SolidBrush grassBrush =
                       new SolidBrush(Color.ForestGreen))
                {
                    graphics.FillRectangle(
                        grassBrush,
                        0,
                        330,
                        pictureBox1.Width,
                        pictureBox1.Height - 330);
                }

                using (SolidBrush hillBrush =
                       new SolidBrush(Color.DarkGreen))
                {
                    PointF[] hill =
                    {
                        new PointF(0, 350),
                        new PointF(100, 290),
                        new PointF(210, 350),
                        new PointF(320, 285),
                        new PointF(450, 350),
                        new PointF(580, 300),
                        new PointF(700, 350),
                        new PointF(800, 290),
                        new PointF(800, 500),
                        new PointF(0, 500)
                    };

                    graphics.FillPolygon(hillBrush, hill);
                }

                using (SolidBrush treeBrush =
                       new SolidBrush(Color.DarkGreen))
                using (Pen treePen =
                       new Pen(Color.Black, 2))
                {
                    DrawTree(graphics, treeBrush, treePen, 70, 220);
                    DrawTree(graphics, treeBrush, treePen, 170, 250);
                    DrawTree(graphics, treeBrush, treePen, 650, 230);
                    DrawTree(graphics, treeBrush, treePen, 750, 250);
                }

                if (!landed)
                {
                    using (SolidBrush beamBrush =
                           new SolidBrush(
                               Color.FromArgb(70, 255, 255, 120)))
                    {
                        PointF[] beam =
                        {
                            new PointF(350, ufoY + 135),
                            new PointF(450, ufoY + 135),
                            new PointF(550, 430),
                            new PointF(250, 430)
                        };

                        graphics.FillPolygon(beamBrush, beam);
                    }

                    using (SolidBrush groundBrush =
                           new SolidBrush(
                               Color.FromArgb(100, 255, 255, 100)))
                    {
                        graphics.FillEllipse(
                            groundBrush,
                            250,
                            410,
                            300,
                            55);
                    }

                    using (Pen groundPen =
                           new Pen(Color.LightYellow, 3))
                    {
                        graphics.DrawEllipse(
                            groundPen,
                            270,
                            420,
                            260,
                            35);
                    }
                }

                DrawUfo(graphics, ufoY);

                using (SolidBrush rockBrush =
                       new SolidBrush(Color.Gray))
                {
                    PointF[] rock1 =
                    {
                        new PointF(120, 430),
                        new PointF(140, 405),
                        new PointF(170, 410),
                        new PointF(185, 435)
                    };

                    PointF[] rock2 =
                    {
                        new PointF(620, 440),
                        new PointF(645, 415),
                        new PointF(675, 425),
                        new PointF(690, 445)
                    };

                    graphics.FillPolygon(rockBrush, rock1);
                    graphics.FillPolygon(rockBrush, rock2);
                }

                using (Pen grassPen =
                       new Pen(Color.LightGreen, 2))
                {
                    for (int x = 20; x < 800; x += 35)
                    {
                        graphics.DrawLine(
                            grassPen,
                            x,
                            470,
                            x + 5,
                            450);

                        graphics.DrawLine(
                            grassPen,
                            x + 5,
                            470,
                            x + 15,
                            452);
                    }
                }

                using (Pen curvePen =
                       new Pen(Color.White, 2))
                {
                    PointF[] curve =
                    {
                        new PointF(40, 390),
                        new PointF(120, 370),
                        new PointF(200, 390),
                        new PointF(280, 370)
                    };

                    graphics.DrawCurve(curvePen, curve);
                }

                using (Pen bezierPen =
                       new Pen(Color.LightGreen, 2))
                {
                    graphics.DrawBezier(
                        bezierPen,
                        500,
                        390,
                        550,
                        350,
                        600,
                        430,
                        680,
                        390);
                }
            }

            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = bitmap;
            oldImage?.Dispose();
        }

        private void DrawUfo(Graphics graphics, int y)
        {
            PointF[] saucer =
            {
                new PointF(220, y + 90),
                new PointF(280, y + 60),
                new PointF(520, y + 60),
                new PointF(580, y + 90),
                new PointF(520, y + 130),
                new PointF(280, y + 130)
            };

            using (SolidBrush saucerBrush =
                   new SolidBrush(Color.Silver))
            {
                graphics.FillPolygon(
                    saucerBrush,
                    saucer);
            }

            using (Pen saucerPen =
                   new Pen(Color.Black, 3))
            {
                graphics.DrawPolygon(
                    saucerPen,
                    saucer);
            }

            using (SolidBrush domeBrush =
                   new SolidBrush(Color.LightSkyBlue))
            {
                graphics.FillEllipse(
                    domeBrush,
                    315,
                    y,
                    170,
                    100);
            }

            using (Pen domePen =
                   new Pen(Color.Black, 3))
            {
                graphics.DrawArc(
                    domePen,
                    315,
                    y,
                    170,
                    100,
                    180,
                    180);
            }

            using (SolidBrush alienBrush =
                   new SolidBrush(Color.LimeGreen))
            {
                graphics.FillEllipse(
                    alienBrush,
                    365,
                    y + 25,
                    70,
                    65);
            }

            using (SolidBrush eyeBrush =
                   new SolidBrush(Color.Black))
            {
                graphics.FillEllipse(
                    eyeBrush,
                    375,
                    y + 40,
                    18,
                    28);

                graphics.FillEllipse(
                    eyeBrush,
                    407,
                    y + 40,
                    18,
                    28);
            }

            using (SolidBrush bottomBrush =
                   new SolidBrush(Color.DimGray))
            {
                graphics.FillEllipse(
                    bottomBrush,
                    280,
                    y + 95,
                    240,
                    55);
            }

            using (Pen bottomPen =
                   new Pen(Color.Black, 3))
            {
                graphics.DrawEllipse(
                    bottomPen,
                    280,
                    y + 95,
                    240,
                    55);
            }

            using (SolidBrush lightBrush =
                   new SolidBrush(Color.Yellow))
            {
                graphics.FillEllipse(
                    lightBrush,
                    300,
                    y + 105,
                    25,
                    25);

                graphics.FillEllipse(
                    lightBrush,
                    345,
                    y + 110,
                    25,
                    25);

                graphics.FillEllipse(
                    lightBrush,
                    390,
                    y + 112,
                    25,
                    25);

                graphics.FillEllipse(
                    lightBrush,
                    435,
                    y + 110,
                    25,
                    25);

                graphics.FillEllipse(
                    lightBrush,
                    480,
                    y + 105,
                    25,
                    25);
            }

            using (Pen lightPen =
                   new Pen(Color.Orange, 2))
            {
                graphics.DrawEllipse(
                    lightPen,
                    300,
                    y + 105,
                    25,
                    25);

                graphics.DrawEllipse(
                    lightPen,
                    345,
                    y + 110,
                    25,
                    25);

                graphics.DrawEllipse(
                    lightPen,
                    390,
                    y + 112,
                    25,
                    25);

                graphics.DrawEllipse(
                    lightPen,
                    435,
                    y + 110,
                    25,
                    25);

                graphics.DrawEllipse(
                    lightPen,
                    480,
                    y + 105,
                    25,
                    25);
            }

            using (SolidBrush centerBrush =
                   new SolidBrush(Color.LightYellow))
            {
                graphics.FillEllipse(
                    centerBrush,
                    350,
                    y + 125,
                    100,
                    30);
            }

            using (Pen centerPen =
                   new Pen(Color.Black, 2))
            {
                graphics.DrawEllipse(
                    centerPen,
                    350,
                    y + 125,
                    100,
                    30);
            }
        }

        private void DrawTree(
            Graphics graphics,
            Brush brush,
            Pen pen,
            int x,
            int y)
        {
            graphics.FillRectangle(
                brush,
                x + 20,
                y + 70,
                20,
                90);

            graphics.DrawRectangle(
                pen,
                x + 20,
                y + 70,
                20,
                90);

            PointF[] crown =
            {
                new PointF(x + 30, y),
                new PointF(x, y + 80),
                new PointF(x + 60, y + 80)
            };

            graphics.FillPolygon(brush, crown);
            graphics.DrawPolygon(pen, crown);

            PointF[] crown2 =
            {
                new PointF(x + 30, y + 30),
                new PointF(x - 10, y + 105),
                new PointF(x + 70, y + 105)
            };

            graphics.FillPolygon(brush, crown2);
            graphics.DrawPolygon(pen, crown2);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();

            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = null;
            oldImage?.Dispose();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            animationTimer.Stop();
            animationTimer.Dispose();
            pictureBox1.Image?.Dispose();

            base.OnFormClosed(e);
        }
    }
}