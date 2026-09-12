namespace Lab3
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
            buttonWrite = new Button();
            buttonDisplay = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(102, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 600);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonWrite
            // 
            buttonWrite.BackColor = SystemColors.MenuHighlight;
            buttonWrite.Location = new Point(222, 676);
            buttonWrite.Name = "buttonWrite";
            buttonWrite.Size = new Size(141, 42);
            buttonWrite.TabIndex = 1;
            buttonWrite.Text = "Запись в файл";
            buttonWrite.UseVisualStyleBackColor = false;
            // 
            // buttonDisplay
            // 
            buttonDisplay.BackColor = SystemColors.MenuHighlight;
            buttonDisplay.Location = new Point(440, 676);
            buttonDisplay.Name = "buttonDisplay";
            buttonDisplay.Size = new Size(141, 42);
            buttonDisplay.TabIndex = 2;
            buttonDisplay.Text = "Отображение";
            buttonDisplay.UseVisualStyleBackColor = false;
            // 
            // buttonClear
            // 
            buttonClear.BackColor = SystemColors.MenuHighlight;
            buttonClear.Location = new Point(653, 676);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(141, 42);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Очистка";
            buttonClear.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(999, 750);
            Controls.Add(buttonClear);
            Controls.Add(buttonDisplay);
            Controls.Add(buttonWrite);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Лабораторная работа 3 Денисенко Никита ИВТ-2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonWrite;
        private Button buttonDisplay;
        private Button buttonClear;
    }
}
