namespace Lab4
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
            buttonDraw = new Button();
            buttonСlear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ScrollBar;
            pictureBox1.Location = new Point(121, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 600);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonDraw
            // 
            buttonDraw.BackColor = SystemColors.MenuHighlight;
            buttonDraw.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDraw.ForeColor = SystemColors.ButtonFace;
            buttonDraw.Location = new Point(257, 657);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Size = new Size(186, 53);
            buttonDraw.TabIndex = 1;
            buttonDraw.Text = "Построить";
            buttonDraw.UseVisualStyleBackColor = false;
            buttonDraw.Click += buttonDraw_Click;
            // 
            // buttonСlear
            // 
            buttonСlear.BackColor = SystemColors.MenuHighlight;
            buttonСlear.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonСlear.ForeColor = SystemColors.ButtonFace;
            buttonСlear.Location = new Point(578, 657);
            buttonСlear.Name = "buttonСlear";
            buttonСlear.Size = new Size(186, 53);
            buttonСlear.TabIndex = 2;
            buttonСlear.Text = "Очистить";
            buttonСlear.UseVisualStyleBackColor = false;
            buttonСlear.Click += buttonClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1042, 740);
            Controls.Add(buttonСlear);
            Controls.Add(buttonDraw);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Лабораторная работа 4 Денисенко Никита ИВТ-2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonDraw;
        private Button buttonСlear;
    }
}
