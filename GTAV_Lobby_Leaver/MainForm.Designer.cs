namespace GTA_V_Lobby_Leaver
{

    partial class MainForm

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

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ButtonStartStop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonLeave = new System.Windows.Forms.Button();

            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkStatusWorker = new System.ComponentModel.BackgroundWorker();

            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 186);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 184);
            this.panel2.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel10.Controls.Add(this.ButtonStartStop);
            this.panel10.Location = new System.Drawing.Point(6, 155);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(247, 23);
            this.panel10.TabIndex = 1;
            // 
            // ButtonStartStop
            // 
            this.ButtonStartStop.BackColor = System.Drawing.Color.SteelBlue;
            this.ButtonStartStop.FlatAppearance.BorderSize = 0;
            this.ButtonStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStartStop.ForeColor = System.Drawing.Color.White;
            this.ButtonStartStop.Location = new System.Drawing.Point(1, 1);
            this.ButtonStartStop.Name = "ButtonStartStop";
            this.ButtonStartStop.Size = new System.Drawing.Size(245, 21);
            this.ButtonStartStop.TabIndex = 0;
            this.ButtonStartStop.TabStop = false;
            this.ButtonStartStop.Text = "Prozess starten";
            this.ButtonStartStop.UseVisualStyleBackColor = false;
            this.ButtonStartStop.Click += new System.EventHandler(this.ButtonStartStop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 106);
            this.progressBar1.Maximum = 7;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(246, 17);

            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 106);
            this.progressBar1.Maximum = 7;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(244, 17);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel3.Controls.Add(this.ButtonLeave);
            this.panel3.Location = new System.Drawing.Point(7, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 23);
            this.panel3.TabIndex = 0;
            // 
            // ButtonLeave
            // 
            this.ButtonLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ButtonLeave.Enabled = false;
            this.ButtonLeave.FlatAppearance.BorderSize = 0;
            this.ButtonLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLeave.ForeColor = System.Drawing.Color.White;
            this.ButtonLeave.Location = new System.Drawing.Point(1, 1);
            this.ButtonLeave.Name = "ButtonLeave";
            this.ButtonLeave.Size = new System.Drawing.Size(244, 21);
            this.ButtonLeave.TabIndex = 0;
            this.ButtonLeave.TabStop = false;
            this.ButtonLeave.Text = "Lobby verlassen (F6)";
            this.ButtonLeave.UseVisualStyleBackColor = false;
            this.ButtonLeave.Click += new System.EventHandler(this.ButtonLeave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Laufzeit: 00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PID: 0";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.Controls.Add(this.label5);
            this.panel11.Location = new System.Drawing.Point(0, 131);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(260, 17);
            this.panel11.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Prozess";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel8.Location = new System.Drawing.Point(0, 130);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(260, 19);
            this.panel8.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(0, 54);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(260, 17);
            this.panel9.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lobby";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel7.Location = new System.Drawing.Point(0, 53);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(260, 19);
            this.panel7.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(260, 18);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.IndianRed;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 17);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status: GTA V ist nicht gestartet";
            // 
            // checkStatusWorker
            // 
            this.checkStatusWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckStatusWorker_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(272, 196);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;

            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lobby Tool V1.0.6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);

            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ButtonLeave;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.ComponentModel.BackgroundWorker checkStatusWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button ButtonStartStop;
    }
}

