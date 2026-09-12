using Lab8.Entities;

namespace Lab8.GameLogic
{
    public sealed class Game
    {
        private const int MaxEnemies = 30;

        private const float FieldWidth = 1000f;
        private const float FieldHeight = 620f;

        private const double InitialSpawnInterval = 1.2;
        private const double MinimumSpawnInterval = 0.45;
        private const double SpawnIntervalDecrease = 0.015;

        private const float PlayerStartX = 455f;
        private const float PlayerStartY = 550f;

        private readonly List<GameObject> _objects;
        private readonly List<Explosion> _explosions;
        private readonly Random _random;

        private double _spawnTimer;
        private double _spawnInterval;

        public Game()
        {
            _objects = new List<GameObject>();
            _explosions = new List<Explosion>();
            _random = new Random();

            AntiAircraft = new AntiAircraft(
                PlayerStartX,
                PlayerStartY);

            _spawnInterval = InitialSpawnInterval;
        }

        public IReadOnlyList<GameObject> Objects => _objects;

        public IReadOnlyList<Explosion> Explosions => _explosions;

        public AntiAircraft AntiAircraft { get; }

        public int TotalEnemies { get; private set; }

        public int DestroyedEnemies { get; private set; }

        public int MissedEnemies { get; private set; }

        public int Score { get; private set; }

        public double MuzzleFlashTimer { get; private set; }

        public bool IsGameOver =>
            TotalEnemies >= MaxEnemies &&
            DestroyedEnemies + MissedEnemies >= MaxEnemies;

        public void Update(double deltaTime)
        {
            ValidateDeltaTime(deltaTime);

            if (IsGameOver)
            {
                UpdateExplosions(deltaTime);
                return;
            }

            double clampedDeltaTime =
                Math.Min(deltaTime, 0.1);

            if (MuzzleFlashTimer > 0)
            {
                MuzzleFlashTimer =
                    Math.Max(0, MuzzleFlashTimer - clampedDeltaTime);
            }

            UpdateEnemies(clampedDeltaTime);
            UpdateProjectiles(clampedDeltaTime);
            UpdateExplosions(clampedDeltaTime);
            SpawnEnemies(clampedDeltaTime);
            ProcessCollisions();
            ProcessOutOfBoundsObjects();
            RemoveDestroyedObjects();
            RemoveFinishedExplosions();
        }

        public void MoveAntiAircraftLeft(double deltaTime)
        {
            ValidateDeltaTime(deltaTime);

            if (IsGameOver)
            {
                return;
            }

            AntiAircraft.MoveLeft(deltaTime);
            ClampAntiAircraftPosition();
        }

        public void MoveAntiAircraftRight(double deltaTime)
        {
            ValidateDeltaTime(deltaTime);

            if (IsGameOver)
            {
                return;
            }

            AntiAircraft.MoveRight(deltaTime);
            ClampAntiAircraftPosition();
        }

        public void Fire()
        {
            if (IsGameOver)
            {
                return;
            }

            float projectileX =
                AntiAircraft.X +
                AntiAircraft.Width / 2f -
                3f;

            float projectileY =
                AntiAircraft.Y -
                18f;

            _objects.Add(
                new Projectile(
                    projectileX,
                    projectileY));

            MuzzleFlashTimer = 0.08;
        }

        public void Reset()
        {
            _objects.Clear();
            _explosions.Clear();

            TotalEnemies = 0;
            DestroyedEnemies = 0;
            MissedEnemies = 0;
            Score = 0;
            MuzzleFlashTimer = 0;

            _spawnTimer = 0;
            _spawnInterval = InitialSpawnInterval;

            AntiAircraft.ResetPosition(
                PlayerStartX,
                PlayerStartY);
        }

        private void UpdateEnemies(double deltaTime)
        {
            foreach (GameObject gameObject in _objects)
            {
                if (gameObject is Aircraft or Balloon)
                {
                    gameObject.Update(deltaTime);
                }
            }
        }

        private void UpdateProjectiles(double deltaTime)
        {
            foreach (GameObject gameObject in _objects)
            {
                if (gameObject is Projectile)
                {
                    gameObject.Update(deltaTime);
                }
            }
        }

        private void UpdateExplosions(double deltaTime)
        {
            foreach (Explosion explosion in _explosions)
            {
                explosion.Update(deltaTime);
            }
        }

        private void SpawnEnemies(double deltaTime)
        {
            if (TotalEnemies >= MaxEnemies)
            {
                return;
            }

            _spawnTimer += deltaTime;

            while (_spawnTimer >= _spawnInterval &&
                   TotalEnemies < MaxEnemies)
            {
                _spawnTimer -= _spawnInterval;

                SpawnEnemy();

                _spawnInterval = Math.Max(
                    MinimumSpawnInterval,
                    _spawnInterval - SpawnIntervalDecrease);
            }
        }

        private void SpawnEnemy()
        {
            float y = _random.Next(
                60,
                Math.Max(
                    61,
                    (int)FieldHeight - 180));

            if (_random.Next(2) == 0)
            {
                _objects.Add(
                    new Aircraft(
                        -90f,
                        y));
            }
            else
            {
                _objects.Add(
                    new Balloon(
                        FieldWidth,
                        y));
            }

            TotalEnemies++;
        }

        private void ProcessCollisions()
        {
            List<Projectile> projectiles = _objects
                .OfType<Projectile>()
                .Where(projectile =>
                    !projectile.IsDestroyed)
                .ToList();

            List<GameObject> enemies = _objects
                .Where(gameObject =>
                    !gameObject.IsDestroyed &&
                    gameObject is Aircraft or Balloon)
                .ToList();

            foreach (Projectile projectile in projectiles)
            {
                foreach (GameObject enemy in enemies)
                {
                    if (projectile.IsDestroyed ||
                        enemy.IsDestroyed)
                    {
                        continue;
                    }

                    if (!projectile.Bounds.IntersectsWith(
                        enemy.Bounds))
                    {
                        continue;
                    }

                    projectile.Destroy();
                    enemy.Destroy();

                    float explosionX =
                        enemy.X +
                        enemy.Width / 2f;

                    float explosionY =
                        enemy.Y +
                        enemy.Height / 2f;

                    _explosions.Add(
                        new Explosion(
                            explosionX,
                            explosionY));

                    DestroyedEnemies++;

                    Score += enemy switch
                    {
                        Aircraft aircraft => aircraft.Score,
                        Balloon balloon => balloon.Score,
                        _ => 0
                    };
                }
            }
        }

        private void ProcessOutOfBoundsObjects()
        {
            foreach (GameObject gameObject in _objects)
            {
                if (gameObject.IsDestroyed)
                {
                    continue;
                }

                switch (gameObject)
                {
                    case Aircraft aircraft
                        when aircraft.X > FieldWidth:

                        aircraft.Destroy();
                        MissedEnemies++;
                        break;

                    case Balloon balloon
                        when balloon.X + balloon.Width < 0:

                        balloon.Destroy();
                        MissedEnemies++;
                        break;

                    case Projectile projectile
                        when projectile.Y + projectile.Height < 0:

                        projectile.Destroy();
                        break;
                }
            }
        }

        private void RemoveDestroyedObjects()
        {
            _objects.RemoveAll(
                gameObject =>
                    gameObject.IsDestroyed);
        }

        private void RemoveFinishedExplosions()
        {
            _explosions.RemoveAll(
                explosion =>
                    explosion.IsFinished);
        }

        private void ClampAntiAircraftPosition()
        {
            float maxX =
                FieldWidth -
                AntiAircraft.ObjectWidth;

            float clampedX = Math.Clamp(
                AntiAircraft.X,
                0f,
                maxX);

            AntiAircraft.SetHorizontalPosition(clampedX);
        }

        private static void ValidateDeltaTime(
            double deltaTime)
        {
            if (!double.IsFinite(deltaTime) ||
                deltaTime < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(deltaTime));
            }
        }
    }
}
