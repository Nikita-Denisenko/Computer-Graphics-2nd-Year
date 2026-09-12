using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Lab3
{
    public partial class Form1 : Form
    {
        // файл в bin\Debug\net9.0-windows\strings.txt
        private readonly string filePath =
            Path.Combine(Application.StartupPath, "strings.txt");

        public Form1()
        {
            InitializeComponent();

            buttonWrite.Click += buttonWrite_Click!;
            buttonDisplay.Click += buttonDisplay_Click!;
            buttonClear.Click += buttonClear_Click!;

            pictureBox1.BackColor = Color.White;
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            string[] lines =
            {
                "First line",
                "Second line",
                "Third line",
                "Fourth line",
                "Fifth line",
                "Sixth line",
                "Seventh line",
                "Eighth line",
                "Ninth line",
                "Tenth line",
                "Eleventh line",
                "Twelfth line",
                "Thirteenth line",
                "Fourteenth line",
                "Fifteenth line"
            };

            File.WriteAllLines(filePath, lines);

            MessageBox.Show(
                "Строки записаны в файл.",
                "Готово",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    "Сначала нажмите «Запись в файл».",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            Bitmap bitmap = new Bitmap(
                pictureBox1.Width,
                pictureBox1.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                DrawFirstGroup(graphics, lines);
                DrawSecondGroup(graphics, lines);
                DrawThirdGroup(graphics, lines);
            }

            Image? oldImage = pictureBox1.Image;

            pictureBox1.Image = bitmap;

            oldImage?.Dispose();
        }

        private void DrawFirstGroup(Graphics graphics, string[] lines)
        {
            using Font font = new Font(
                "Calibri",
                36,
                FontStyle.Strikeout);

            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.DirectionVertical
            };

            RectangleF rectangle = new RectangleF(
                10,
                10,
                170,
                280);

            string text = string.Join(
                Environment.NewLine,
                lines[0..6]);

            graphics.DrawString(
                text,
                font,
                Brushes.Black,
                rectangle,
                format);
        }

        private void DrawSecondGroup(Graphics graphics, string[] lines)
        {
            using Font font = new Font(
                "Consolas",
                24,
                FontStyle.Bold);

            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Near
            };

            RectangleF rectangle = new RectangleF(
                190,
                10,
                480,
                240);

            string text = string.Join(
                Environment.NewLine,
                lines[6..11]);

            graphics.DrawString(
                text,
                font,
                Brushes.Black,
                rectangle,
                format);
        }

        private void DrawThirdGroup(Graphics graphics, string[] lines)
        {
            using Font font = new Font(
                "Corbel",
                0.5f,
                FontStyle.Underline,
                GraphicsUnit.Inch);

            using StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };

            RectangleF rectangle = new RectangleF(
                170,
                270,
                500,
                300);

            string text = string.Join(
                Environment.NewLine,
                lines[11..15]);

            graphics.DrawString(
                text,
                font,
                Brushes.Black,
                rectangle,
                format);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Image? oldImage = pictureBox1.Image;

            pictureBox1.Image = null;

            oldImage?.Dispose();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pictureBox1.Image?.Dispose();

            base.OnFormClosed(e);
        }
    }
}