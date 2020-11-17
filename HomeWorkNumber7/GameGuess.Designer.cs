namespace HomeWorkNumber7
{
    partial class GameGuess
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LblTry = new System.Windows.Forms.Label();
            this.LblTryText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(172, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 31);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblTry
            // 
            this.LblTry.AutoSize = true;
            this.LblTry.Location = new System.Drawing.Point(258, 202);
            this.LblTry.Name = "LblTry";
            this.LblTry.Size = new System.Drawing.Size(13, 13);
            this.LblTry.TabIndex = 7;
            this.LblTry.Text = "0";
            // 
            // LblTryText
            // 
            this.LblTryText.AutoSize = true;
            this.LblTryText.Location = new System.Drawing.Point(133, 202);
            this.LblTryText.Name = "LblTryText";
            this.LblTryText.Size = new System.Drawing.Size(118, 13);
            this.LblTryText.TabIndex = 6;
            this.LblTryText.Text = "Количество попыток: ";
            // 
            // GameGuess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 247);
            this.Controls.Add(this.LblTry);
            this.Controls.Add(this.LblTryText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "GameGuess";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GameGuess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblTry;
        private System.Windows.Forms.Label LblTryText;
    }
}