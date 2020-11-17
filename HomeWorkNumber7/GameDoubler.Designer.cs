namespace HomeWorkNumber7
{
    partial class GameDoubler
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCommand1 = new System.Windows.Forms.Button();
            this.BtnCommand2 = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.LblNumber = new System.Windows.Forms.Label();
            this.LblTryText = new System.Windows.Forms.Label();
            this.LblTry = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTarget = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnBackTry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCommand1
            // 
            this.BtnCommand1.Location = new System.Drawing.Point(237, 43);
            this.BtnCommand1.Name = "BtnCommand1";
            this.BtnCommand1.Size = new System.Drawing.Size(75, 23);
            this.BtnCommand1.TabIndex = 0;
            this.BtnCommand1.Text = "+1";
            this.BtnCommand1.UseVisualStyleBackColor = true;
            this.BtnCommand1.Click += new System.EventHandler(this.BtnCommand1_Click);
            // 
            // BtnCommand2
            // 
            this.BtnCommand2.Location = new System.Drawing.Point(237, 72);
            this.BtnCommand2.Name = "BtnCommand2";
            this.BtnCommand2.Size = new System.Drawing.Size(75, 23);
            this.BtnCommand2.TabIndex = 1;
            this.BtnCommand2.Text = "x2";
            this.BtnCommand2.UseVisualStyleBackColor = true;
            this.BtnCommand2.Click += new System.EventHandler(this.BtnCommand2_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(237, 102);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 2;
            this.BtnReset.Text = "Сброс";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Location = new System.Drawing.Point(140, 77);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(13, 13);
            this.LblNumber.TabIndex = 3;
            this.LblNumber.Text = "0";
            // 
            // LblTryText
            // 
            this.LblTryText.AutoSize = true;
            this.LblTryText.Location = new System.Drawing.Point(25, 107);
            this.LblTryText.Name = "LblTryText";
            this.LblTryText.Size = new System.Drawing.Size(118, 13);
            this.LblTryText.TabIndex = 4;
            this.LblTryText.Text = "Количество попыток: ";
            // 
            // LblTry
            // 
            this.LblTry.AutoSize = true;
            this.LblTry.Location = new System.Drawing.Point(150, 107);
            this.LblTry.Name = "LblTry";
            this.LblTry.Size = new System.Drawing.Size(13, 13);
            this.LblTry.TabIndex = 5;
            this.LblTry.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текущий результат: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Цель: ";
            // 
            // LblTarget
            // 
            this.LblTarget.AutoSize = true;
            this.LblTarget.Location = new System.Drawing.Point(70, 48);
            this.LblTarget.Name = "LblTarget";
            this.LblTarget.Size = new System.Drawing.Size(13, 13);
            this.LblTarget.TabIndex = 8;
            this.LblTarget.Text = "0";
            // 
            // BtnBackTry
            // 
            this.BtnBackTry.Location = new System.Drawing.Point(126, 152);
            this.BtnBackTry.Name = "BtnBackTry";
            this.BtnBackTry.Size = new System.Drawing.Size(93, 23);
            this.BtnBackTry.TabIndex = 9;
            this.BtnBackTry.Text = "Отменить ход";
            this.BtnBackTry.UseVisualStyleBackColor = true;
            this.BtnBackTry.Click += new System.EventHandler(this.BtnBackTry_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 187);
            this.Controls.Add(this.BtnBackTry);
            this.Controls.Add(this.LblTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblTry);
            this.Controls.Add(this.LblTryText);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnCommand2);
            this.Controls.Add(this.BtnCommand1);
            this.Name = "GameForm";
            this.Text = "Удвоитель";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCommand1;
        private System.Windows.Forms.Button BtnCommand2;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.Label LblTryText;
        private System.Windows.Forms.Label LblTry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTarget;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BtnBackTry;
    }
}

