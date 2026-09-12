namespace lab_1_Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Получаем объект Graphics
            Graphics g = e.Graphics;
            // Рисуем линию
            g.DrawLine(Pens.Red, 10, 5, 110, 15);
            // Рисуем эллипс
            g.DrawEllipse(Pens.Blue, 10, 20, 110, 45);
            // Рисуем прямоугольник
            g.DrawRectangle(Pens.Green, 10, 70, 110, 45);
            // Рисуем закрашенный эллипс
            g.FillEllipse(Brushes.Blue, 130, 20, 110, 45);
            // Рисуем закрашенный прямоугольник
            g.FillRectangle(Brushes.Green, 130, 70, 110, 45);
            base.OnPaint(e);
        }
    }
}
