namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Выбираем перо myPen красного цвета толщиной в 1 пиксел:
            Pen myPen = new Pen(Color.Red, 1);
            // Объявляем объект «g» класса Graphics и предоставляем
            // ему возможность рисования на pictureBox1:
            Graphics g = pictureBox1.CreateGraphics();
            // Рисуем прямоугольник:
            g.DrawRectangle(myPen, 0, 0, pictureBox1.Size.Width - 1,
            pictureBox1.Size.Height - 1);
            g.Dispose();
        }
    }
}
