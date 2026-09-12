using Lab8.Entities;
using System.Drawing.Drawing2D;

namespace Lab8.Rendering
{
    public sealed class AntiAircraftRenderer
    {
        public void Render(
            Graphics graphics,
            AntiAircraft antiAircraft)
        {
            float x = antiAircraft.X;
            float y = antiAircraft.Y;
            float width = antiAircraft.Width;
            float height = antiAircraft.Height;

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

                DrawTracks(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawChassis(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawTurret(
                    graphics,
                    x,
                    y,
                    width,
                    height);

                DrawBarrel(
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
                        55,
                        0,
                        0,
                        0));

            graphics.FillEllipse(
                brush,
                x + 3f,
                y + height - 4f,
                width - 6f,
                10f);
        }

        private static void DrawTracks(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            float trackWidth = width * 0.18f;
            float trackHeight = height * 0.58f;
            float trackY = y + height * 0.36f;

            RectangleF leftTrack =
                new RectangleF(
                    x + width * 0.08f,
                    trackY,
                    trackWidth,
                    trackHeight);

            RectangleF rightTrack =
                new RectangleF(
                    x + width * 0.74f,
                    trackY,
                    trackWidth,
                    trackHeight);

            using Brush trackBrush =
                new SolidBrush(
                    Color.FromArgb(
                        35,
                        42,
                        45));

            using Pen trackPen =
                new Pen(
                    Color.FromArgb(
                        15,
                        20,
                        22),
                    2f);

            graphics.FillEllipse(
                trackBrush,
                leftTrack);

            graphics.DrawEllipse(
                trackPen,
                leftTrack);

            graphics.FillEllipse(
                trackBrush,
                rightTrack);

            graphics.DrawEllipse(
                trackPen,
                rightTrack);

            using Brush wheelBrush =
                new SolidBrush(
                    Color.FromArgb(
                        100,
                        110,
                        110));

            float wheelSize = 9f;

            for (int i = 0; i < 3; i++)
            {
                float wheelY =
                    trackY +
                    8f +
                    i * 14f;

                graphics.FillEllipse(
                    wheelBrush,
                    leftTrack.X + 4f,
                    wheelY,
                    wheelSize,
                    wheelSize);

                graphics.FillEllipse(
                    wheelBrush,
                    rightTrack.X + 4f,
                    wheelY,
                    wheelSize,
                    wheelSize);
            }
        }

        private static void DrawChassis(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            RectangleF chassis =
                new RectangleF(
                    x + width * 0.17f,
                    y + height * 0.42f,
                    width * 0.66f,
                    height * 0.42f);

            using Brush chassisBrush =
                new SolidBrush(
                    Color.FromArgb(
                        72,
                        86,
                        78));

            using Pen chassisPen =
                new Pen(
                    Color.FromArgb(
                        25,
                        32,
                        30),
                    2f);

            graphics.FillRectangle(
                chassisBrush,
                chassis);

            graphics.DrawRectangle(
                chassisPen,
                chassis.X,
                chassis.Y,
                chassis.Width,
                chassis.Height);

            using Brush frontBrush =
                new SolidBrush(
                    Color.FromArgb(
                        92,
                        105,
                        94));

            PointF[] front =
            {
                new PointF(
                    chassis.X,
                    chassis.Y),

                new PointF(
                    chassis.Right,
                    chassis.Y),

                new PointF(
                    chassis.Right - 7f,
                    chassis.Bottom),

                new PointF(
                    chassis.X + 7f,
                    chassis.Bottom)
            };

            graphics.FillPolygon(
                frontBrush,
                front);
        }

        private static void DrawTurret(
            Graphics graphics,
            float x,
            float y,
            float width,
            float height)
        {
            RectangleF turretBase =
                new RectangleF(
                    x + width * 0.28f,
                    y + height * 0.28f,
                    width * 0.44f,
                    height * 0.25f);

            using Brush baseBrush =
                new SolidBrush(
                    Color.FromArgb(
                        78,
                        94,
                        82));

            using Pen basePen =
                new Pen(
                    Color.FromArgb(
                        25,
                        30,
                        28),
                    2f);

            graphics.FillEllipse(
                baseBrush,
                turretBase);

            graphics.DrawEllipse(
                basePen,
                turretBase);

            RectangleF turret =
                new RectangleF(
                    x + width * 0.36f,
                    y + height * 0.19f,
                    width * 0.28f,
                    height * 0.25f);

            using Brush turretBrush =
                new SolidBrush(
                    Color.FromArgb(
                        102,
                        115,
                        103));

            graphics.FillRectangle(
                turretBrush,
                turret);

            graphics.DrawRectangle(
                basePen,
                turret.X,
                turret.Y,
                turret.Width,
                turret.Height);

            using Brush hatchBrush =
                new SolidBrush(
                    Color.FromArgb(
                        55,
                        65,
                        60));

            graphics.FillEllipse(
                hatchBrush,
                turret.X + 7f,
                turret.Y + 3f,
                turret.Width - 14f,
                8f);
        }

        private static void DrawBarrel(
     Graphics graphics,
     float x,
     float y,
     float width,
     float height)
        {
            float centerX =
                x + width / 2f;

            float startY =
                y + height * 0.28f;

            float barrelLength =
                height * 0.42f;

            using Pen shadowPen =
                new Pen(
                    Color.FromArgb(
                        25,
                        30,
                        28),
                    10f);

            graphics.DrawLine(
                shadowPen,
                centerX,
                startY,
                centerX,
                startY - barrelLength);

            using Pen barrelPen =
                new Pen(
                    Color.FromArgb(
                        115,
                        125,
                        112),
                    7f);

            graphics.DrawLine(
                barrelPen,
                centerX,
                startY,
                centerX,
                startY - barrelLength);

            using Pen highlightPen =
                new Pen(
                    Color.FromArgb(
                        175,
                        185,
                        165),
                    2f);

            graphics.DrawLine(
                highlightPen,
                centerX - 2f,
                startY,
                centerX - 2f,
                startY - barrelLength + 5f);

            using Brush muzzleBrush =
                new SolidBrush(
                    Color.FromArgb(
                        35,
                        40,
                        38));

            graphics.FillEllipse(
                muzzleBrush,
                centerX - 6f,
                startY - barrelLength - 5f,
                12f,
                10f);
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
                        135,
                        150,
                        135),
                    2f);

            graphics.DrawLine(
                detailPen,
                x + width * 0.25f,
                y + height * 0.56f,
                x + width * 0.75f,
                y + height * 0.56f);

            graphics.DrawLine(
                detailPen,
                x + width * 0.25f,
                y + height * 0.68f,
                x + width * 0.75f,
                y + height * 0.68f);

            using Brush yellowBrush =
                new SolidBrush(
                    Color.FromArgb(
                        255,
                        190,
                        45));

            graphics.FillEllipse(
                yellowBrush,
                x + width * 0.40f,
                y + height * 0.68f,
                6f,
                6f);

            using Brush redBrush =
                new SolidBrush(
                    Color.FromArgb(
                        220,
                        55,
                        45));

            graphics.FillEllipse(
                redBrush,
                x + width * 0.62f,
                y + height * 0.68f,
                6f,
                6f);
        }
    }
}