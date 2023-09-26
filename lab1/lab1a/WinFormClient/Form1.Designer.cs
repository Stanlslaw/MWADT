namespace WinFormClient
{
    partial class Form1
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
            this.parm1 = new System.Windows.Forms.TextBox();
            this.parm2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.handleRes = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // parm1
            // 
            this.parm1.Location = new System.Drawing.Point(340, 183);
            this.parm1.Name = "parm1";
            this.parm1.Size = new System.Drawing.Size(100, 22);
            this.parm1.TabIndex = 0;
            // 
            // parm2
            // 
            this.parm2.Location = new System.Drawing.Point(340, 211);
            this.parm2.Name = "parm2";
            this.parm2.Size = new System.Drawing.Size(100, 22);
            this.parm2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "число 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "число2";
            // 
            // handleRes
            // 
            this.handleRes.Location = new System.Drawing.Point(354, 239);
            this.handleRes.Name = "handleRes";
            this.handleRes.Size = new System.Drawing.Size(75, 23);
            this.handleRes.TabIndex = 4;
            this.handleRes.Text = "равно";
            this.handleRes.UseVisualStyleBackColor = true;
            this.handleRes.Click += new System.EventHandler(this.handleRes_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(337, 265);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(80, 16);
            this.result.TabIndex = 5;
            this.result.Text = "Результат:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.result);
            this.Controls.Add(this.handleRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parm2);
            this.Controls.Add(this.parm1);
            this.Name = "Form1";
            this.Text = "Сумма";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox parm1;
        private System.Windows.Forms.TextBox parm2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button handleRes;
        private System.Windows.Forms.Label result;
    }
}

