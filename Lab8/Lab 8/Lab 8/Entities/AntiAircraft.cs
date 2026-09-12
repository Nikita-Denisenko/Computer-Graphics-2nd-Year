namespace Lab8.Entities
{
    public sealed class AntiAircraft : GameObject
    {
        public const float ObjectWidth = 90f;

        private const float ObjectHeight = 55f;
        private const float Speed = 350f;

        public AntiAircraft(float x, float y)
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
        }

        public void MoveLeft(double deltaTime)
        {
            ValidateDeltaTime(deltaTime);

            X -= Speed * (float)deltaTime;
        }

        public void MoveRight(double deltaTime)
        {
            ValidateDeltaTime(deltaTime);

            X += Speed * (float)deltaTime;
        }

        private static void ValidateDeltaTime(double deltaTime)
        {
            if (!double.IsFinite(deltaTime) || deltaTime < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaTime));
            }
        }

        public void SetHorizontalPosition(float x)
        {
            if (!float.IsFinite(x))
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            X = x;
        }

        public void ResetPosition(float x, float y)
        {
            if (!float.IsFinite(x))
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (!float.IsFinite(y))
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            X = x;
            Y = y;
        }
    }
}
