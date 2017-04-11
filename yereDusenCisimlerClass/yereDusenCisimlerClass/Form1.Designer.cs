namespace yereDusenCisimlerClass
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.oyunSkor = new System.Windows.Forms.Label();
            this.oyunCani = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 21;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // oyunSkor
            // 
            this.oyunSkor.AutoSize = true;
            this.oyunSkor.BackColor = System.Drawing.Color.Transparent;
            this.oyunSkor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oyunSkor.Location = new System.Drawing.Point(0, 0);
            this.oyunSkor.Name = "oyunSkor";
            this.oyunSkor.Size = new System.Drawing.Size(43, 17);
            this.oyunSkor.TabIndex = 0;
            this.oyunSkor.Text = "label1";
            // 
            // oyunCani
            // 
            this.oyunCani.AutoSize = true;
            this.oyunCani.BackColor = System.Drawing.Color.Transparent;
            this.oyunCani.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oyunCani.Location = new System.Drawing.Point(0, 28);
            this.oyunCani.Name = "oyunCani";
            this.oyunCani.Size = new System.Drawing.Size(43, 17);
            this.oyunCani.TabIndex = 1;
            this.oyunCani.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.oyunCani);
            this.Controls.Add(this.oyunSkor);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yere Düşen Cisimler Class";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label oyunSkor;
        private System.Windows.Forms.Label oyunCani;
    }
}

