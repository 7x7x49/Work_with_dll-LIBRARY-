namespace LibraryCS
{
    partial class ClassDllForm1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassDllForm1));
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            labelTimeBegin = new System.Windows.Forms.Label();
            labelTimeEnd = new System.Windows.Forms.Label();
            labelTimeSpan = new System.Windows.Forms.Label();
            labelTimeThread = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new System.Windows.Forms.ProgressBar();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Sitka Text", 9F);
            label1.Location = new System.Drawing.Point(51, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 21);
            label1.TabIndex = 0;
            label1.Text = "Начало";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Sitka Text", 9F);
            label2.Location = new System.Drawing.Point(164, 50);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 21);
            label2.TabIndex = 1;
            label2.Text = "Окончание";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Sitka Text", 9F);
            label3.Location = new System.Drawing.Point(302, 50);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(160, 21);
            label3.TabIndex = 2;
            label3.Text = "Продолжительность";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Sitka Text", 9F);
            label4.Location = new System.Drawing.Point(506, 50);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 21);
            label4.TabIndex = 3;
            label4.Text = "Поток";
            // 
            // labelTimeBegin
            // 
            labelTimeBegin.AutoSize = true;
            labelTimeBegin.Location = new System.Drawing.Point(45, 98);
            labelTimeBegin.Name = "labelTimeBegin";
            labelTimeBegin.Size = new System.Drawing.Size(72, 16);
            labelTimeBegin.TabIndex = 4;
            labelTimeBegin.Text = "0:00:00:000";
            // 
            // labelTimeEnd
            // 
            labelTimeEnd.AutoSize = true;
            labelTimeEnd.Location = new System.Drawing.Point(176, 98);
            labelTimeEnd.Name = "labelTimeEnd";
            labelTimeEnd.Size = new System.Drawing.Size(72, 16);
            labelTimeEnd.TabIndex = 5;
            labelTimeEnd.Text = "0:00:00:000";
            // 
            // labelTimeSpan
            // 
            labelTimeSpan.AutoSize = true;
            labelTimeSpan.Location = new System.Drawing.Point(352, 98);
            labelTimeSpan.Name = "labelTimeSpan";
            labelTimeSpan.Size = new System.Drawing.Size(51, 16);
            labelTimeSpan.TabIndex = 6;
            labelTimeSpan.Text = "0:0:0:00";
            // 
            // labelTimeThread
            // 
            labelTimeThread.AutoSize = true;
            labelTimeThread.Location = new System.Drawing.Point(530, 98);
            labelTimeThread.Name = "labelTimeThread";
            labelTimeThread.Size = new System.Drawing.Size(14, 16);
            labelTimeThread.TabIndex = 7;
            labelTimeThread.Text = "0";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = System.Drawing.Color.MistyRose;
            progressBar1.ForeColor = System.Drawing.Color.Salmon;
            progressBar1.Location = new System.Drawing.Point(48, 166);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(512, 38);
            progressBar1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Sitka Text", 9F);
            button1.Location = new System.Drawing.Point(233, 270);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(159, 41);
            button1.TabIndex = 9;
            button1.Text = "Закрыть";
            button1.UseVisualStyleBackColor = true;
            // 
            // ClassDllForm1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(632, 359);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(labelTimeThread);
            Controls.Add(labelTimeSpan);
            Controls.Add(labelTimeEnd);
            Controls.Add(labelTimeBegin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            Name = "ClassDllForm1";
            Text = "Прогресс вычислений";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTimeBegin;
        private System.Windows.Forms.Label labelTimeEnd;
        private System.Windows.Forms.Label labelTimeSpan;
        private System.Windows.Forms.Label labelTimeThread;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
    }
}