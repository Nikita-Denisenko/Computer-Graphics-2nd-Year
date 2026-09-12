using System.Drawing.Drawing2D;
using Lab8.Entities;

namespace Lab8.Rendering
{
    public sealed class BalloonRenderer
    {
        public void Render(Graphics graphics, Balloon balloon)
        {
            ArgumentNullException.ThrowIfNull(graphics);
            ArgumentNullException.ThrowIfNull(balloon);

            if (balloon.IsDestroyed)
            {
                return;
            }

            GraphicsState state = graphics.Save();

            try
            {
                float x = balloon.X;
                float y = balloon.Y;

                using SolidBrush balloonBrush = new SolidBrush(Color.Red);
                using SolidBrush highlightBrush = new SolidBrush(Color.LightCoral);
                using SolidBrush basketBrush = new SolidBrush(Color.SaddleBrown);
                using Pen outlinePen = new Pen(Color.Black, 2f);
                using Pen ropePen = new Pen(Color.SaddleBrown, 2f);

                RectangleF balloonBounds = new RectangleF(
                    x,
                    y,
                    balloon.Width,
                    balloon.Height * 0.72f);

                graphics.FillEllipse(balloonBrush, balloonBounds);
                graphics.DrawEllipse(outlinePen, balloonBounds);

                graphics.FillEllipse(
                    highlightBrush,
                    x + balloon.Width * 0.2f,
                    y + balloon.Height * 0.12f,
                    balloon.Width * 0.2f,
                    balloon.Height * 0.2f);

                float basketX = x + balloon.Width * 0.32f;
                float basketY = y + balloon.Height * 0.76f;
                float basketWidth = balloon.Width * 0.36f;
                float basketHeight = balloon.Height * 0.2f;

                graphics.DrawLine(
                    ropePen,
                    x + balloon.Width * 0.3f,
                    y + balloon.Height * 0.65f,
                    basketX,
                    basketY);

                graphics.DrawLine(
                    ropePen,
                    x + balloon.Width * 0.7f,
                    y + balloon.Height * 0.65f,
                    basketX + basketWidth,
                    basketY);

                graphics.FillRectangle(
                    basketBrush,
                    basketX,
                    basketY,
                    basketWidth,
                    basketHeight);

                graphics.DrawRectangle(
                    outlinePen,
                    basketX,
                    basketY,
                    basketWidth,
                    basketHeight);
            }
            finally
            {
                graphics.Restore(state);
            }
        }
    }
}
