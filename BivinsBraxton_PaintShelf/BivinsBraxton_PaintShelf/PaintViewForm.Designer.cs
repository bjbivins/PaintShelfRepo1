﻿namespace BivinsBraxton_PaintShelf
{
    partial class PaintViewForm
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
            this.PaintInfo = new System.Windows.Forms.ListBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.MakeText = new System.Windows.Forms.TextBox();
            this.PntNameText = new System.Windows.Forms.TextBox();
            this.pntCodeText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ColorDrop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.YearUD = new System.Windows.Forms.NumericUpDown();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.YearUD)).BeginInit();
            this.SuspendLayout();
            // 
            // PaintInfo
            // 
            this.PaintInfo.FormattingEnabled = true;
            this.PaintInfo.Location = new System.Drawing.Point(12, 83);
            this.PaintInfo.Name = "PaintInfo";
            this.PaintInfo.Size = new System.Drawing.Size(417, 355);
            this.PaintInfo.TabIndex = 0;
            this.PaintInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PaintInfo_MouseDoubleClick);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(160, 49);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 1;
            this.colorLabel.Text = "Color";
            // 
            // MakeText
            // 
            this.MakeText.Location = new System.Drawing.Point(503, 83);
            this.MakeText.Name = "MakeText";
            this.MakeText.Size = new System.Drawing.Size(121, 20);
            this.MakeText.TabIndex = 2;
            this.MakeText.TextChanged += new System.EventHandler(this.MakeText_TextChanged);
            // 
            // PntNameText
            // 
            this.PntNameText.Location = new System.Drawing.Point(503, 161);
            this.PntNameText.Name = "PntNameText";
            this.PntNameText.Size = new System.Drawing.Size(121, 20);
            this.PntNameText.TabIndex = 3;
            this.PntNameText.TextChanged += new System.EventHandler(this.PntNameText_TextChanged);
            // 
            // pntCodeText
            // 
            this.pntCodeText.Location = new System.Drawing.Point(503, 135);
            this.pntCodeText.Name = "pntCodeText";
            this.pntCodeText.Size = new System.Drawing.Size(121, 20);
            this.pntCodeText.TabIndex = 4;
            this.pntCodeText.TextChanged += new System.EventHandler(this.pntCodeText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Make";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Paint Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Paint Name";
            // 
            // ColorDrop
            // 
            this.ColorDrop.FormattingEnabled = true;
            this.ColorDrop.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Green",
            "Yellow",
            "Pink",
            "Black",
            "Gray",
            "Silver",
            "Orange",
            "Purple",
            "White",
            "Special"});
            this.ColorDrop.Location = new System.Drawing.Point(503, 187);
            this.ColorDrop.Name = "ColorDrop";
            this.ColorDrop.Size = new System.Drawing.Size(121, 21);
            this.ColorDrop.TabIndex = 12;
            this.ColorDrop.SelectedIndexChanged += new System.EventHandler(this.ColorDrop_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "color";
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(503, 214);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(121, 23);
            this.EditButton.TabIndex = 14;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // YearUD
            // 
            this.YearUD.Location = new System.Drawing.Point(504, 105);
            this.YearUD.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.YearUD.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearUD.Name = "YearUD";
            this.YearUD.Size = new System.Drawing.Size(120, 20);
            this.YearUD.TabIndex = 15;
            this.YearUD.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(504, 243);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 23);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "Add Paint";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(504, 272);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Delete Paint";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PaintViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.YearUD);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColorDrop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pntCodeText);
            this.Controls.Add(this.PntNameText);
            this.Controls.Add(this.MakeText);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.PaintInfo);
            this.Name = "PaintViewForm";
            this.Text = "PaintViewForm";
            this.Load += new System.EventHandler(this.PaintViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YearUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PaintInfo;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox MakeText;
        private System.Windows.Forms.TextBox PntNameText;
        private System.Windows.Forms.TextBox pntCodeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ColorDrop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.NumericUpDown YearUD;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}