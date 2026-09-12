using Lab8.Entities;

namespace Lab8.Rendering
{
    public sealed class ProjectileRenderer
    {
        public void Render(Graphics graphics, Projectile projectile)
        {
            ArgumentNullException.ThrowIfNull(graphics);
            ArgumentNullException.ThrowIfNull(projectile);

            if (projectile.IsDestroyed)
            {
                return;
            }

            using SolidBrush projectileBrush = new SolidBrush(Color.Yellow);
            using Pen outlinePen = new Pen(Color.OrangeRed, 1f);

            graphics.FillRectangle(
                projectileBrush,
                projectile.Bounds);

            graphics.DrawRectangle(
                outlinePen,
                projectile.Bounds.X,
                projectile.Bounds.Y,
                projectile.Bounds.Width,
                projectile.Bounds.Height);
        }
    }
}
