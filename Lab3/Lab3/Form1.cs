using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private readonly string _filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "strings.txt");

        private string[] _lines = Array.Empty<string>();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
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
                "Twelfth line"
            };

            File.WriteAllLines(_filePath, lines);
            _lines = lines;

            drawingPanel.Invalidate();

            MessageBox.Show(
                "Файл успешно создан и записан.",
                "Запись в файл",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_filePath))
            {
                MessageBox.Show(
                    "Сначала создайте файл кнопкой «Запись в файл».",
                    "Файл не найден",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _lines = File.ReadAllLines(_filePath);

            if (_lines.Length < 12)
            {
                MessageBox.Show(
                    "В файле должно находиться не менее 12 строк.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            drawingPanel.Invalidate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _lines = Array.Empty<string>();
            drawingPanel.Invalidate();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            graphics.Clear(Color.LightCyan);

            if (_lines.Length < 12)
            {
                return;
            }

            // Группа 1: строки 1–6
            // Calibri, Strikeout, 36 pt, вертикальное направление,
            // выравнивание Near / Near.
            using (Font font1 = new Font(
                "Calibri",
                36f,
                FontStyle.Strikeout,
                GraphicsUnit.Point))
            using (StringFormat format1 = new StringFormat())
            {
                format1.Alignment = StringAlignment.Near;
                format1.LineAlignment = StringAlignment.Near;
                format1.FormatFlags = StringFormatFlags.DirectionVertical;

                float x = 8f;

                for (int i = 0; i < 6; i++)
                {
                    RectangleF area = new RectangleF(
                        x,
                        8f,
                        48f,
                        drawingPanel.ClientSize.Height - 16f);

                    graphics.DrawString(
                        _lines[i],
                        font1,
                        Brushes.Black,
                        area,
                        format1);

                    x += 42f;
                }
            }

            // Группа 2: строки 7–11
            // Consolas, Bold, 24 pt, горизонтальное направление,
            // выравнивание Far / Near.
            using (Font font2 = new Font(
                "Consolas",
                24f,
                FontStyle.Bold,
                GraphicsUnit.Point))
            using (StringFormat format2 = new StringFormat())
            {
                format2.Alignment = StringAlignment.Far;
                format2.LineAlignment = StringAlignment.Near;

                float y = 8f;

                for (int i = 6; i < 11; i++)
                {
                    RectangleF area = new RectangleF(
                        310f,
                        y,
                        Math.Max(100f, drawingPanel.ClientSize.Width - 325f),
                        35f);

                    graphics.DrawString(
                        _lines[i],
                        font2,
                        Brushes.Blue,
                        area,
                        format2);

                    y += 39f;
                }
            }

            // Группа 3: строка 12
            // Corbel, Underline, 0.5 inch = 36 pt, горизонтальное направление,
            // выравнивание Center / Near.
            using (Font font3 = new Font(
                "Corbel",
                36f,
                FontStyle.Underline,
                GraphicsUnit.Point))
            using (StringFormat format3 = new StringFormat())
            {
                format3.Alignment = StringAlignment.Center;
                format3.LineAlignment = StringAlignment.Near;

                RectangleF area = new RectangleF(
                    250f,
                    225f,
                    Math.Max(200f, drawingPanel.ClientSize.Width - 300f),
                    55f);

                graphics.DrawString(
                    _lines[11],
                    font3,
                    Brushes.Green,
                    area,
                    format3);
            }
        }
    }
}