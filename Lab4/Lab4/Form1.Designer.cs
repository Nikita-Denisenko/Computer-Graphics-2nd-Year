namespace Lab4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 700);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Лабораторная работа №4 — Кривая дракона";

            Paint += Form1_Paint;
            Resize += Form1_Resize;

            ResumeLayout(false);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        #endregion
    }
}