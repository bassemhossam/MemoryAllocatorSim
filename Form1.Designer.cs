namespace OS2
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
            this.holesNumTxtBox = new System.Windows.Forms.TextBox();
            this.prosNumTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstFitBtn = new System.Windows.Forms.RadioButton();
            this.bestFitBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.form1NextBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // holesNumTxtBox
            // 
            this.holesNumTxtBox.Location = new System.Drawing.Point(116, 24);
            this.holesNumTxtBox.Name = "holesNumTxtBox";
            this.holesNumTxtBox.Size = new System.Drawing.Size(131, 20);
            this.holesNumTxtBox.TabIndex = 0;
            this.holesNumTxtBox.Text = "Enter number of holes";
            this.holesNumTxtBox.TextChanged += new System.EventHandler(this.holesNumTxtBox_TextChanged);
            this.holesNumTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // prosNumTxtBox
            // 
            this.prosNumTxtBox.Location = new System.Drawing.Point(116, 73);
            this.prosNumTxtBox.Name = "prosNumTxtBox";
            this.prosNumTxtBox.Size = new System.Drawing.Size(131, 20);
            this.prosNumTxtBox.TabIndex = 1;
            this.prosNumTxtBox.Text = "Enter number of processes";
            this.prosNumTxtBox.TextChanged += new System.EventHandler(this.prosNumTxtBox_TextChanged);
            this.prosNumTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "No. of holes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. of processes";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // firstFitBtn
            // 
            this.firstFitBtn.AutoSize = true;
            this.firstFitBtn.Location = new System.Drawing.Point(6, 29);
            this.firstFitBtn.Name = "firstFitBtn";
            this.firstFitBtn.Size = new System.Drawing.Size(55, 17);
            this.firstFitBtn.TabIndex = 4;
            this.firstFitBtn.TabStop = true;
            this.firstFitBtn.Text = "First fit";
            this.firstFitBtn.UseVisualStyleBackColor = true;
            this.firstFitBtn.CheckedChanged += new System.EventHandler(this.firstFitBtn_CheckedChanged);
            this.firstFitBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // bestFitBtn
            // 
            this.bestFitBtn.AutoSize = true;
            this.bestFitBtn.Location = new System.Drawing.Point(6, 66);
            this.bestFitBtn.Name = "bestFitBtn";
            this.bestFitBtn.Size = new System.Drawing.Size(57, 17);
            this.bestFitBtn.TabIndex = 5;
            this.bestFitBtn.TabStop = true;
            this.bestFitBtn.Text = "Best fit";
            this.bestFitBtn.UseVisualStyleBackColor = true;
            this.bestFitBtn.CheckedChanged += new System.EventHandler(this.bestFitBtn_CheckedChanged);
            this.bestFitBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.firstFitBtn);
            this.groupBox1.Controls.Add(this.bestFitBtn);
            this.groupBox1.Location = new System.Drawing.Point(16, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 108);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Method of allocation";
            // 
            // form1NextBtn
            // 
            this.form1NextBtn.Location = new System.Drawing.Point(197, 227);
            this.form1NextBtn.Name = "form1NextBtn";
            this.form1NextBtn.Size = new System.Drawing.Size(75, 23);
            this.form1NextBtn.TabIndex = 7;
            this.form1NextBtn.Text = "Next";
            this.form1NextBtn.UseVisualStyleBackColor = true;
            this.form1NextBtn.Click += new System.EventHandler(this.form1NextBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.form1NextBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prosNumTxtBox);
            this.Controls.Add(this.holesNumTxtBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox holesNumTxtBox;
        private System.Windows.Forms.TextBox prosNumTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton firstFitBtn;
        private System.Windows.Forms.RadioButton bestFitBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button form1NextBtn;
    }
}

