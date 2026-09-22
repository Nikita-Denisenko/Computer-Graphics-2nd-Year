namespace Lab3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonDisplay;
        private System.Windows.Forms.Button buttonClear;

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
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonDisplay = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.LightCyan;
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1000, 560);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.bottomPanel.Controls.Add(this.buttonClear);
            this.bottomPanel.Controls.Add(this.buttonDisplay);
            this.bottomPanel.Controls.Add(this.buttonWrite);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 560);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1000, 60);
            this.bottomPanel.TabIndex = 1;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonWrite.Location = new System.Drawing.Point(150, 18);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(150, 28);
            this.buttonWrite.TabIndex = 0;
            this.buttonWrite.Text = "Запись в файл";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonDisplay
            // 
            this.buttonDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDisplay.Location = new System.Drawing.Point(425, 18);
            this.buttonDisplay.Name = "buttonDisplay";
            this.buttonDisplay.Size = new System.Drawing.Size(150, 28);
            this.buttonDisplay.TabIndex = 1;
            this.buttonDisplay.Text = "Отображение";
            this.buttonDisplay.UseVisualStyleBackColor = true;
            this.buttonDisplay.Click += new System.EventHandler(this.buttonDisplay_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClear.Location = new System.Drawing.Point(700, 18);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(150, 28);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистка";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.bottomPanel);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №3";
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
