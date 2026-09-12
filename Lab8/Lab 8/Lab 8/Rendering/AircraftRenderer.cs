using Lab8.Entities;
using System.Drawing.Drawing2D;

namespace Lab8.Rendering
{
    public sealed class AircraftRenderer
    {
        public void Render(
            Graphics graphics,
            Aircraft aircraft)
        {
            float x = aircraft.X;
            float y = aircraft.Y;
            float width = aircraft.Width;
            float height = aircraft.Height;

            GraphicsState state = graphics.Save();

            try
            {
                graphics.SmoothingMode =
                    SmoothingMode.AntiAlias;

                DrawShadow(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawMainBody(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawWings(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawTail(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawCockpit(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawEngines(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawDetails(
                    graphics,
                    x,
                    y,
                    width,
                    height);
            }
            finally
            {
                graphics.Restore(state);
            }
        }

        private static void DrawShadow(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            using Brush brush =
                new SolidBrush(
                    Color.FromArgb(
                        45,
                        0,
                        0,
                        0));

            graphics.FillEllipse(
                brush,
                x + width * 0.12f,
                y + height * 0.72f,
                width * 0.76f,
                height * 0.16f);
        }

        private static void DrawMainBody(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            PointF[] body =
            {
                new PointF(
                    x + width,
                    y + height * 0.50f),

                new PointF(
                    x + width * 0.80f,
                    y + height * 0.32f),

                new PointF(
                    x + width * 0.42f,
                    y + height * 0.25f),

                new PointF(
                    x + width * 0.10f,
                    y + height * 0.40f),

                new PointF(
                    x,
                    y + height * 0.50f),

                new PointF(
                    x + width * 0.10f,
                    y + height * 0.60f),

                new PointF(
                    x + width * 0.42f,
                    y + height * 0.75f),

                new PointF(
                    x + width * 0.80f,
                    y + height * 0.68f)
            };

            using Brush bodyBrush =
                new SolidBrush(
                    Color.FromArgb(
                        95,
                        105,
                        120));

            using Pen bodyPen =
                new Pen(
                    Color.FromArgb(
                        35,
                        40,
                        50),
                    2f);

            graphics.FillPolygon(
                bodyBrush,
                body);

            graphics.DrawPolygon(
                bodyPen,
                body);
        }

        private static void DrawWings(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            PointF[] topWing =
            {
                new PointF(
                    x + width * 0.55f,
                    y + height * 0.42f),

                new PointF(
                    x + width * 0.34f,
                    y),

                new PointF(
                    x + width * 0.18f,
                    y),

                new PointF(
                    x + width * 0.28f,
                    y + height * 0.50f)
            };

            PointF[] bottomWing =
            {
                new PointF(
                    x + width * 0.55f,
                    y + height * 0.58f),

                new PointF(
                    x + width * 0.34f,
                    y + height),

                new PointF(
                    x + width * 0.18f,
                    y + height),

                new PointF(
                    x + width * 0.28f,
                    y + height * 0.50f)
            };

            using Brush wingBrush =
                new SolidBrush(
                    Color.FromArgb(
                        70,
                        80,
                        95));

            using Pen wingPen =
                new Pen(
                    Color.FromArgb(
                        30,
                        35,
                        45),
                    2f);

            graphics.FillPolygon(
                wingBrush,
                topWing);

            graphics.DrawPolygon(
                wingPen,
                topWing);

            graphics.FillPolygon(
                wingBrush,
                bottomWing);

            graphics.DrawPolygon(
                wingPen,
                bottomWing);
        }

        private static void DrawTail(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            PointF[] tail =
            {
                new PointF(
                    x + width * 0.18f,
                    y + height * 0.42f),

                new PointF(
                    x + width * 0.04f,
                    y + height * 0.12f),

                new PointF(
                    x + width * 0.18f,
                    y + height * 0.28f),

                new PointF(
                    x + width * 0.28f,
                    y + height * 0.45f),

                new PointF(
                    x + width * 0.18f,
                    y + height * 0.72f),

                new PointF(
                    x + width * 0.04f,
                    y + height * 0.88f),

                new PointF(
                    x + width * 0.18f,
                    y + height * 0.58f)
            };

            using Brush brush =
                new SolidBrush(
                    Color.FromArgb(
                        65,
                        75,
                        90));

            using Pen pen =
                new Pen(
                    Color.FromArgb(
                        30,
                        35,
                        45),
                    2f);

            graphics.FillPolygon(
                brush,
                tail);

            graphics.DrawPolygon(
                pen,
                tail);
        }

        private static void DrawCockpit(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            RectangleF cockpit =
                new RectangleF(
                    x + width * 0.52f,
                    y + height * 0.34f,
                    width * 0.24f,
                    height * 0.32f);

            using Brush glassBrush =
                new SolidBrush(
                    Color.FromArgb(
                        60,
                        180,
                        225));

            using Pen glassPen =
                new Pen(
                    Color.FromArgb(
                        25,
                        80,
                        110),
                    2f);

            graphics.FillEllipse(
                glassBrush,
                cockpit);

            graphics.DrawEllipse(
                glassPen,
                cockpit);

            using Pen reflectionPen =
                new Pen(
                    Color.FromArgb(
                        190,
                        235,
                        255),
                    2f);

            graphics.DrawLine(
                reflectionPen,
                cockpit.Left + 5,
                cockpit.Top + 6,
                cockpit.Right - 5,
                cockpit.Top + 2);
        }

        private static void DrawEngines(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            float engineWidth = width * 0.14f;
            float engineHeight = height * 0.24f;

            RectangleF topEngine =
                new RectangleF(
                    x + width * 0.32f,
                    y + height * 0.13f,
                    engineWidth,
                    engineHeight);

            RectangleF bottomEngine =
                new RectangleF(
                    x + width * 0.32f,
                    y + height * 0.63f,
                    engineWidth,
                    engineHeight);

            using Brush engineBrush =
                new SolidBrush(
                    Color.FromArgb(
                        40,
                        45,
                        55));

            using Pen enginePen =
                new Pen(
                    Color.FromArgb(
                        20,
                        25,
                        30),
                    2f);

            graphics.FillEllipse(
                engineBrush,
                topEngine);

            graphics.DrawEllipse(
                enginePen,
                topEngine);

            graphics.FillEllipse(
                engineBrush,
                bottomEngine);

            graphics.DrawEllipse(
                enginePen,
                bottomEngine);

            using Brush exhaustBrush =
                new SolidBrush(
                    Color.FromArgb(
                        255,
                        170,
                        45));

            graphics.FillEllipse(
                exhaustBrush,
                x + width * 0.29f,
                y + height * 0.18f,
                width * 0.07f,
                height * 0.12f);

            graphics.FillEllipse(
                exhaustBrush,
                x + width * 0.29f,
                y + height * 0.70f,
                width * 0.07f,
                height * 0.12f);
        }

        private static void DrawDetails(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            using Pen detailPen =
                new Pen(
                    Color.FromArgb(
                        150,
                        160,
                        175),
                    1.5f);

            graphics.DrawLine(
                detailPen,
                x + width * 0.30f,
                y + height * 0.50f,
                x + width * 0.80f,
                y + height * 0.50f);

            graphics.DrawLine(
                detailPen,
                x + width * 0.39f,
                y + height * 0.32f,
                x + width * 0.48f,
                y + height * 0.43f);

            graphics.DrawLine(
                detailPen,
                x + width * 0.39f,
                y + height * 0.68f,
                x + width * 0.48f,
                y + height * 0.57f);

            using Brush lightBrush =
                new SolidBrush(
                    Color.FromArgb(
                        255,
                        70,
                        70));

            graphics.FillEllipse(
                lightBrush,
                x + width * 0.12f,
                y + height * 0.45f,
                5f,
                5f);
        }
    }
}
