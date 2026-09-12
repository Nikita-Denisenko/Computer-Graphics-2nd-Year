namespace Lab6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox pictureBox1;
        private Button buttonDraw;
        private Button buttonClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            buttonDraw = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 500);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonDraw
            // 
            buttonDraw.Location = new Point(12, 525);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Size = new Size(120, 35);
            buttonDraw.TabIndex = 1;
            buttonDraw.Text = "Нарисовать";
            buttonDraw.UseVisualStyleBackColor = true;
            buttonDraw.Click += buttonDraw_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(145, 525);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(120, 35);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 575);
            Controls.Add(buttonClear);
            Controls.Add(buttonDraw);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа 6 Денисенко Никита ИВТ-2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}