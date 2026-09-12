namespace Lab_8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox pictureBoxGame;
        private System.Windows.Forms.Timer gameTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBoxGame = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGame).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxGame
            // 
            pictureBoxGame.BackColor = Color.SkyBlue;
            pictureBoxGame.Location = new Point(0, 0);
            pictureBoxGame.Name = "pictureBoxGame";
            pictureBoxGame.Size = new Size(1000, 700);
            pictureBoxGame.TabIndex = 0;
            pictureBoxGame.TabStop = false;
            pictureBoxGame.Paint += pictureBoxGame_Paint;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 16;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(pictureBoxGame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа 8 Денисенко Никита ИВТ-2";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxGame).EndInit();
            ResumeLayout(false);
        }
    }
}