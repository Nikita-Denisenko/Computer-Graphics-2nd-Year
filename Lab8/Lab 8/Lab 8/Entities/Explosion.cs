namespace Lab8.Entities
{
    public sealed class Explosion
    {
        private const double Duration = 0.45;

        public Explosion(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }

        public float Y { get; }

        public double Elapsed { get; private set; }

        public bool IsFinished =>
            Elapsed >= Duration;

        public float Progress =>
            Math.Clamp(
                (float)(Elapsed / Duration),
                0f,
                1f);

        public void Update(double deltaTime)
        {
            if (!double.IsFinite(deltaTime) || deltaTime < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaTime));
            }

            if (IsFinished)
            {
                return;
            }

            Elapsed += deltaTime;
        }
    }
}