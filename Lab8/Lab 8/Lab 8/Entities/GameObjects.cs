using System.Drawing;

namespace Lab8.Entities
{
    public abstract class GameObject
    {
        protected GameObject(
            float x,
            float y,
            float width,
            float height)
        {
            if (!float.IsFinite(x))
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (!float.IsFinite(y))
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            if (!float.IsFinite(width) || width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (!float.IsFinite(height) || height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public float X { get; protected set; }

        public float Y { get; protected set; }

        public float Width { get; }

        public float Height { get; }

        public bool IsDestroyed { get; private set; }

        public RectangleF Bounds => new RectangleF(
            X,
            Y,
            Width,
            Height);

        public void Destroy()
        {
            IsDestroyed = true;
        }

        public abstract void Update(double deltaTime);
    }
}
