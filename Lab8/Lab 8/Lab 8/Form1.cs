using System.Diagnostics;
using Lab8.GameLogic;
using Lab8.Rendering;

namespace Lab_8
{
    public partial class Form1 : Form
    {
        private readonly Game _game;
        private readonly GameRenderer _gameRenderer;
        private readonly Stopwatch _stopwatch;

        private bool _moveLeft;
        private bool _moveRight;
        private bool _spacePressed;

        public Form1()
        {
            InitializeComponent();

            _game = new Game();
            _gameRenderer = new GameRenderer();
            _stopwatch = Stopwatch.StartNew();

            KeyPreview = true;

            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            double deltaTime = _stopwatch.Elapsed.TotalSeconds;

            _stopwatch.Restart();

            _game.Update(deltaTime);

            if (_moveLeft)
            {
                _game.MoveAntiAircraftLeft(deltaTime);
            }

            if (_moveRight)
            {
                _game.MoveAntiAircraftRight(deltaTime);
            }

            pictureBoxGame.Invalidate();
        }

        private void pictureBoxGame_Paint(
            object sender,
            PaintEventArgs e)
        {
            _gameRenderer.Render(
                e.Graphics,
                _game,
                pictureBoxGame.Width,
                pictureBoxGame.Height);
        }

        private void Form1_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _moveLeft = true;
                    e.Handled = true;
                    break;

                case Keys.Right:
                    _moveRight = true;
                    e.Handled = true;
                    break;

                case Keys.Space:
                    if (!_spacePressed)
                    {
                        _game.Fire();
                        _spacePressed = true;
                    }

                    e.Handled = true;
                    break;

                case Keys.Enter:
                    if (_game.IsGameOver)
                    {
                        _game.Reset();
                        _stopwatch.Restart();
                        pictureBoxGame.Invalidate();
                    }

                    e.Handled = true;
                    break;
            }
        }

        private void Form1_KeyUp(
            object sender,
            KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _moveLeft = false;
                    e.Handled = true;
                    break;

                case Keys.Right:
                    _moveRight = false;
                    e.Handled = true;
                    break;

                case Keys.Space:
                    _spacePressed = false;
                    e.Handled = true;
                    break;
            }
        }

        private void Form1_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            gameTimer.Stop();
        }
    }
}