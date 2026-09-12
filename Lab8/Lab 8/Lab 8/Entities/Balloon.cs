namespace Lab8.Entities
{
    public sealed class Balloon : GameObject
    {
        private const float ObjectWidth = 48f;
        private const float ObjectHeight = 64f;
        private const float Speed = 90f;

        public Balloon(float x, float y)
            : base(x, y, ObjectWidth, ObjectHeight)
        {
        }

        public int Score => 10;

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

            X -= Speed * (float)deltaTime;
        }
    }
}
