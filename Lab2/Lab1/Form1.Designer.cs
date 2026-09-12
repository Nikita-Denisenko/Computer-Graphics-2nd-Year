namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            buttonPixel = new Button();
            buttonMillimeter = new Button();
            buttonInch = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(42, 42, 60);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(124, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 450);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonPixel
            // 
            buttonPixel.BackColor = Color.FromArgb(59, 130, 246);
            buttonPixel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonPixel.ForeColor = Color.White;
            buttonPixel.Location = new Point(222, 515);
            buttonPixel.Name = "buttonPixel";
            buttonPixel.Size = new Size(100, 30);
            buttonPixel.TabIndex = 1;
            buttonPixel.Text = "Pixel";
            buttonPixel.UseVisualStyleBackColor = false;
            buttonPixel.Click += buttonPixel_Click;
            // 
            // buttonMillimeter
            // 
            buttonMillimeter.BackColor = Color.FromArgb(59, 130, 246);
            buttonMillimeter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonMillimeter.ForeColor = Color.White;
            buttonMillimeter.Location = new Point(421, 515);
            buttonMillimeter.Name = "buttonMillimeter";
            buttonMillimeter.Size = new Size(100, 30);
            buttonMillimeter.TabIndex = 2;
            buttonMillimeter.Text = "Millimeter";
            buttonMillimeter.UseVisualStyleBackColor = false;
            buttonMillimeter.Click += buttonMillimeter_Click;
            // 
            // buttonInch
            // 
            buttonInch.BackColor = Color.FromArgb(59, 130, 246);
            buttonInch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonInch.ForeColor = Color.White;
            buttonInch.Location = new Point(621, 515);
            buttonInch.Name = "buttonInch";
            buttonInch.Size = new Size(100, 30);
            buttonInch.TabIndex = 3;
            buttonInch.Text = "Inch";
            buttonInch.UseVisualStyleBackColor = false;
            buttonInch.Click += buttonInch_Click;
            // 
            // buttonClear
            // 
            buttonClear.BackColor = Color.FromArgb(59, 130, 246);
            buttonClear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(818, 515);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(100, 30);
            buttonClear.TabIndex = 4;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += buttonClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1165, 625);
            Controls.Add(buttonClear);
            Controls.Add(buttonInch);
            Controls.Add(buttonMillimeter);
            Controls.Add(buttonPixel);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GDI+ График функции";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonPixel;
        private Button buttonMillimeter;
        private Button buttonInch;
        private Button buttonClear;
    }
}
