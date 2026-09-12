using Lab8.Entities;
using Lab8.GameLogic;
using System.Drawing.Drawing2D;

namespace Lab8.Rendering
{
    public sealed class GameRenderer
    {
        private const float ScoreBoardHeight = 80f;

        private readonly AircraftRenderer _aircraftRenderer;
        private readonly AntiAircraftRenderer _antiAircraftRenderer;
        private readonly BalloonRenderer _balloonRenderer;
        private readonly ProjectileRenderer _projectileRenderer;

        public GameRenderer()
        {
            _aircraftRenderer = new AircraftRenderer();
            _antiAircraftRenderer = new AntiAircraftRenderer();
            _balloonRenderer = new BalloonRenderer();
            _projectileRenderer = new ProjectileRenderer();
        }

        public void Render(
            Graphics graphics,
            Game game,
            int width,
            int height)
        {
            graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            graphics.Clear(Color.SkyBlue);

            DrawBackground(
                graphics,
                width,
                height);

            foreach (GameObject gameObject in game.Objects)
            {
                switch (gameObject)
                {
                    case Aircraft aircraft:
                        _aircraftRenderer.Render(
                            graphics,
                            aircraft);
                        break;

                    case Balloon balloon:
                        _balloonRenderer.Render(
                            graphics,
                            balloon);
                        break;

                    case Projectile projectile:
                        _projectileRenderer.Render(
                            graphics,
                            projectile);
                        break;
                }
            }

            DrawExplosions(
                graphics,
                game.Explosions);

            _antiAircraftRenderer.Render(
                graphics,
                game.AntiAircraft);

            if (game.MuzzleFlashTimer > 0)
            {
                DrawMuzzleFlash(
                    graphics,
                    game.AntiAircraft);
            }

            DrawScoreBoard(
                graphics,
                game,
                width);

            if (game.IsGameOver)
            {
                DrawGameOver(
                    graphics,
                    width,
                    height);
            }
        }

        private static void DrawBackground(
            Graphics graphics,
            int width,
            int height)
        {
            float groundTop = height - 100f;

            using Brush groundBrush =
                new SolidBrush(
                    Color.FromArgb(
                        76,
                        150,
                        76));

            graphics.FillRectangle(
                groundBrush,
                0,
                groundTop,
                width,
                100);

            using Brush sunBrush =
                new SolidBrush(
                    Color.FromArgb(
                        255,
                        220,
                        80));

            graphics.FillEllipse(
                sunBrush,
                width - 130,
                105,
                75,
                75);

            using Pen sunGlowPen =
                new Pen(
                    Color.FromArgb(
                        80,
                        255,
                        225,
                        80),
                    3f);

            graphics.DrawEllipse(
                sunGlowPen,
                width - 137,
                98,
                89,
                89);

            using Brush cloudBrush =
                new SolidBrush(
                    Color.FromArgb(
                        245,
                        255,
                        255));

            DrawCloud(
                graphics,
                cloudBrush,
                100,
                120,
                1f);

            DrawCloud(
                graphics,
                cloudBrush,
                480,
                150,
                0.8f);

            DrawCloud(
                graphics,
                cloudBrush,
                760,
                110,
                0.7f);

            using Pen grassPen =
                new Pen(
                    Color.FromArgb(
                        55,
                        120,
                        55),
                    2f);

            for (int x = 0; x < width; x += 18)
            {
                graphics.DrawLine(
                    grassPen,
                    x,
                    groundTop,
                    x - 3,
                    groundTop - 8);
            }
        }

        private static void DrawCloud(
            Graphics graphics,
            Brush brush,
            float x,
            float y,
            float scale)
        {
            graphics.FillEllipse(
                brush,
                x,
                y + 15 * scale,
                70 * scale,
                35 * scale);

            graphics.FillEllipse(
                brush,
                x + 25 * scale,
                y,
                55 * scale,
                45 * scale);

            graphics.FillEllipse(
                brush,
                x + 60 * scale,
                y + 12 * scale,
                65 * scale,
                38 * scale);
        }

        private static void DrawExplosions(
            Graphics graphics,
            IReadOnlyList<Explosion> explosions)
        {
            foreach (Explosion explosion in explosions)
            {
                float progress = explosion.Progress;

                float radius =
                    8f +
                    48f * progress;

                float alpha =
                    1f - progress;

                int outerAlpha =
                    Math.Clamp(
                        (int)(220f * alpha),
                        0,
                        255);

                int innerAlpha =
                    Math.Clamp(
                        (int)(255f * alpha),
                        0,
                        255);

                using Brush outerBrush =
                    new SolidBrush(
                        Color.FromArgb(
                            outerAlpha,
                            255,
                            90,
                            10));

                using Brush innerBrush =
                    new SolidBrush(
                        Color.FromArgb(
                            innerAlpha,
                            255,
                            225,
                            70));

                graphics.FillEllipse(
                    outerBrush,
                    explosion.X - radius,
                    explosion.Y - radius,
                    radius * 2,
                    radius * 2);

                float innerRadius =
                    radius * 0.55f;

                graphics.FillEllipse(
                    innerBrush,
                    explosion.X - innerRadius,
                    explosion.Y - innerRadius,
                    innerRadius * 2,
                    innerRadius * 2);

                for (int i = 0; i < 12; i++)
                {
                    double angle =
                        i * Math.PI * 2 / 12;

                    float distance =
                        radius *
                        (1.2f + (i % 3) * 0.25f);

                    float particleX =
                        explosion.X +
                        (float)Math.Cos(angle) *
                        distance;

                    float particleY =
                        explosion.Y +
                        (float)Math.Sin(angle) *
                        distance;

                    float particleSize =
                        3f +
                        3f * (1f - progress);

                    using Brush particleBrush =
                        new SolidBrush(
                            Color.FromArgb(
                                outerAlpha,
                                255,
                                160,
                                20));

                    graphics.FillEllipse(
                        particleBrush,
                        particleX - particleSize / 2f,
                        particleY - particleSize / 2f,
                        particleSize,
                        particleSize);
                }
            }
        }

        private static void DrawMuzzleFlash(
            Graphics graphics,
            AntiAircraft antiAircraft)
        {
            float centerX =
                antiAircraft.X +
                antiAircraft.Width / 2f;

            float topY =
                antiAircraft.Y - 12f;

            PointF[] flash =
            {
                new PointF(centerX, topY - 18f),
                new PointF(centerX - 7f, topY - 5f),
                new PointF(centerX - 14f, topY),
                new PointF(centerX, topY + 3f),
                new PointF(centerX + 14f, topY),
                new PointF(centerX + 7f, topY - 5f)
            };

            using Brush flashBrush =
                new SolidBrush(
                    Color.FromArgb(
                        230,
                        255,
                        230,
                        70));

            graphics.FillPolygon(
                flashBrush,
                flash);
        }

        private static void DrawScoreBoard(
            Graphics graphics,
            Game game,
            int width)
        {
            using Brush backgroundBrush =
                new SolidBrush(
                    Color.FromArgb(
                        185,
                        20,
                        30,
                        45));

            graphics.FillRectangle(
                backgroundBrush,
                0,
                0,
                width,
                ScoreBoardHeight);

            using Font font =
                new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold);

            using Brush textBrush =
                new SolidBrush(Color.White);

            graphics.DrawString(
                $"SCORE: {game.Score}",
                font,
                textBrush,
                20,
                15);

            graphics.DrawString(
                $"ENEMIES: {game.DestroyedEnemies}/{game.TotalEnemies}",
                font,
                textBrush,
                250,
                15);

            graphics.DrawString(
                $"MISSED: {game.MissedEnemies}",
                font,
                textBrush,
                650,
                15);
        }

        private static void DrawGameOver(
            Graphics graphics,
            int width,
            int height)
        {
            using Brush overlayBrush =
                new SolidBrush(
                    Color.FromArgb(
                        165,
                        0,
                        0,
                        0));

            graphics.FillRectangle(
                overlayBrush,
                0,
                0,
                width,
                height);

            using Font titleFont =
                new Font(
                    "Segoe UI",
                    42,
                    FontStyle.Bold);

            using Font textFont =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            using Brush textBrush =
                new SolidBrush(Color.White);

            string title = "ИГРА ОКОНЧЕНА";
            string text = "НАЖМИТЕ ENTER чтобы начать заново";

            SizeF titleSize =
                graphics.MeasureString(
                    title,
                    titleFont);

            SizeF textSize =
                graphics.MeasureString(
                    text,
                    textFont);

            graphics.DrawString(
                title,
                titleFont,
                textBrush,
                (width - titleSize.Width) / 2f,
                height / 2f - 70f);

            graphics.DrawString(
                text,
                textFont,
                textBrush,
                (width - textSize.Width) / 2f,
                height / 2f + 5f);
        }
    }
}