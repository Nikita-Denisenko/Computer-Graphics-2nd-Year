namespace Lab8.Entities
{
    public sealed class Aircraft : GameObject
    {
        private const float ObjectWidth = 90f;
        private const float ObjectHeight = 42f;
        private const float Speed = 150f;
        private const float VerticalAmplitude = 45f;
        private const float VerticalFrequency = 2.2f;

        private readonly float _baseY;
        private float _time;

        public Aircraft(float x, float y)
            : base(x, y, ObjectWidth, ObjectHeight)
        {
            _baseY = y;
        }

        public int Score => 20;

        public override void Update(double deltaTime)
        {
            ValidateDeltaTime(deltaTime);

            if (IsDestroyed)
            {
                return;
            }

            _time += (float)deltaTime;

            X += Speed * (float)deltaTime;

            Y = _baseY +
                VerticalAmplitude *
                MathF.Sin(_time * VerticalFrequency);
        }

        private static void ValidateDeltaTime(double deltaTime)
        {
            if (!double.IsFinite(deltaTime) || deltaTime < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaTime));
            }
        }
    }
}
