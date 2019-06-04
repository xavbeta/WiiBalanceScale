/*********************************************************************************
WiiBalanceStatokinesigram

MIT License

Copyright (c) 2017 Bernhard Schelling

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
**********************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WiiBalanceScale
{
    class WiiBalanceScaleForm : Form
    {
        public WiiBalanceScaleForm()
        {
            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        }
        internal Button btnStart;
        internal ProgressBar progressbar;
        internal Label countdown;
        private Panel panel1;
        internal Button btnReset;
        internal ComboBox boxSex;
        private Label label1;
        internal TextBox txtHeight;
        private Label label2;
        internal TextBox txtName;
        internal Button btnScale;
        internal TextBox txtWeight;
        private Label label3;
        internal Button btnZero;
        private Label label4;
        internal TextBox txtNotes;
        internal TextBox txtPath;
        internal Button button1;
        private Label label5;
        internal ComboBox boxType;

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
            this.btnStart = new System.Windows.Forms.Button();
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.countdown = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnScale = new System.Windows.Forms.Button();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxSex = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.boxType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStart.Location = new System.Drawing.Point(1329, 599);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(488, 123);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // progressbar
            // 
            this.progressbar.Location = new System.Drawing.Point(50, 756);
            this.progressbar.Margin = new System.Windows.Forms.Padding(4);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(1767, 28);
            this.progressbar.TabIndex = 11;
            // 
            // countdown
            // 
            this.countdown.AutoSize = true;
            this.countdown.Font = new System.Drawing.Font("Roboto Medium", 69.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdown.Location = new System.Drawing.Point(1165, 182);
            this.countdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countdown.Name = "countdown";
            this.countdown.Size = new System.Drawing.Size(304, 224);
            this.countdown.TabIndex = 12;
            this.countdown.Text = "30";
            this.countdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.boxType);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.txtNotes);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnZero);
            this.panel1.Controls.Add(this.btnScale);
            this.panel1.Controls.Add(this.txtWeight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boxSex);
            this.panel1.Location = new System.Drawing.Point(50, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 696);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 56);
            this.button1.TabIndex = 28;
            this.button1.Text = "DIRECTORY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(209, 622);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(457, 31);
            this.txtPath.TabIndex = 27;
            this.txtPath.TextChanged += new System.EventHandler(this.TextBox1_TextChanged_1);
            // 
            // txtNotes
            // 
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.Location = new System.Drawing.Point(47, 507);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(619, 76);
            this.txtNotes.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Sex";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(47, 420);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(619, 57);
            this.btnZero.TabIndex = 23;
            this.btnZero.Text = "ZERO";
            this.btnZero.UseVisualStyleBackColor = true;
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(47, 346);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(619, 57);
            this.btnScale.TabIndex = 22;
            this.btnScale.Text = "MEASURE";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(259, 282);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(407, 31);
            this.txtWeight.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Weight (kg)";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(259, 220);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(407, 31);
            this.txtHeight.TabIndex = 19;
            this.txtHeight.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Height (cm)";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(259, 158);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(407, 31);
            this.txtName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // boxSex
            // 
            this.boxSex.FormattingEnabled = true;
            this.boxSex.ItemHeight = 25;
            this.boxSex.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
            this.boxSex.Location = new System.Drawing.Point(259, 100);
            this.boxSex.Name = "boxSex";
            this.boxSex.Size = new System.Drawing.Size(407, 33);
            this.boxSex.TabIndex = 15;
            this.boxSex.Text = "MALE";
            this.boxSex.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReset.Location = new System.Drawing.Point(815, 599);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(488, 123);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 25);
            this.label5.TabIndex = 30;
            this.label5.Text = "Experiment Type";
            // 
            // boxType
            // 
            this.boxType.FormattingEnabled = true;
            this.boxType.ItemHeight = 25;
            this.boxType.Items.AddRange(new object[] {
            "TWO LEGS OPEN EYES",
            "TWO LEGS CLOSED EYES",
            "ONE LEG OPEN EYES",
            "ONE LEG CLOSED EYES"});
            this.boxType.Location = new System.Drawing.Point(259, 41);
            this.boxType.Name = "boxType";
            this.boxType.Size = new System.Drawing.Size(407, 33);
            this.boxType.TabIndex = 29;
            this.boxType.Text = "TWO LEGS OPEN EYES";
            // 
            // WiiBalanceScaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1866, 842);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.countdown);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "WiiBalanceScaleForm";
            this.Text = "Wii Balance Scale";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Button1_Click_2(object sender, EventArgs e)
        {

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderDialog.SelectedPath;
            }
        }
    }
}