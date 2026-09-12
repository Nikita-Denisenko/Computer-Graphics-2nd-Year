namespace Lab8.Entities
{
    public sealed class Projectile : GameObject
    {
        private const float ObjectWidth = 6f;
        private const float ObjectHeight = 18f;
        private const float Speed = 600f;

        public Projectile(float x, float y)
            : base(x, y, ObjectWidth, ObjectHeight)
        {
        }

        public override void Update(double deltaTime)
        {
            if (!double.IsFinite(deltaTime) || deltaTime < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaTime));
            }

            if (IsDestroyed)
            {
                return;
            }

            Y -= Speed * (float)deltaTime;
        }
    }
}
