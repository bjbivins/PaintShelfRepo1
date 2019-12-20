namespace BivinsBraxton_PaintShelf
{
    partial class VinDecoderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VinTText = new System.Windows.Forms.TextBox();
            this.YearUD = new System.Windows.Forms.NumericUpDown();
            this.vinDecodeButton = new System.Windows.Forms.Button();
            this.makeText = new System.Windows.Forms.TextBox();
            this.modelText = new System.Windows.Forms.TextBox();
            this.PaintCodeText = new System.Windows.Forms.TextBox();
            this.PaintNameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDrop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddPaint = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.YearUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year";
            // 
            // VinTText
            // 
            this.VinTText.Location = new System.Drawing.Point(278, 260);
            this.VinTText.Name = "VinTText";
            this.VinTText.Size = new System.Drawing.Size(208, 20);
            this.VinTText.TabIndex = 4;
            this.VinTText.TextChanged += new System.EventHandler(this.VinTText_TextChanged);
            // 
            // YearUD
            // 
            this.YearUD.Location = new System.Drawing.Point(278, 286);
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
            this.YearUD.Size = new System.Drawing.Size(208, 20);
            this.YearUD.TabIndex = 5;
            this.YearUD.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearUD.ValueChanged += new System.EventHandler(this.YearUD_ValueChanged);
            // 
            // vinDecodeButton
            // 
            this.vinDecodeButton.Enabled = false;
            this.vinDecodeButton.Location = new System.Drawing.Point(180, 341);
            this.vinDecodeButton.Name = "vinDecodeButton";
            this.vinDecodeButton.Size = new System.Drawing.Size(306, 109);
            this.vinDecodeButton.TabIndex = 6;
            this.vinDecodeButton.Text = "Decode VIN";
            this.vinDecodeButton.UseVisualStyleBackColor = true;
            this.vinDecodeButton.Click += new System.EventHandler(this.vinDecodeButton_Click);
            // 
            // makeText
            // 
            this.makeText.Location = new System.Drawing.Point(278, 518);
            this.makeText.Name = "makeText";
            this.makeText.ReadOnly = true;
            this.makeText.Size = new System.Drawing.Size(208, 20);
            this.makeText.TabIndex = 7;
            // 
            // modelText
            // 
            this.modelText.Location = new System.Drawing.Point(278, 544);
            this.modelText.Name = "modelText";
            this.modelText.ReadOnly = true;
            this.modelText.Size = new System.Drawing.Size(208, 20);
            this.modelText.TabIndex = 8;
            // 
            // PaintCodeText
            // 
            this.PaintCodeText.Location = new System.Drawing.Point(278, 570);
            this.PaintCodeText.Name = "PaintCodeText";
            this.PaintCodeText.ReadOnly = true;
            this.PaintCodeText.Size = new System.Drawing.Size(208, 20);
            this.PaintCodeText.TabIndex = 9;
            // 
            // PaintNameText
            // 
            this.PaintNameText.Enabled = false;
            this.PaintNameText.Location = new System.Drawing.Point(278, 596);
            this.PaintNameText.Name = "PaintNameText";
            this.PaintNameText.Size = new System.Drawing.Size(208, 20);
            this.PaintNameText.TabIndex = 10;
            this.PaintNameText.TextChanged += new System.EventHandler(this.PaintNameText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Make";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Model";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 570);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Paint Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 599);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Paint Name";
            // 
            // colorDrop
            // 
            this.colorDrop.Enabled = false;
            this.colorDrop.FormattingEnabled = true;
            this.colorDrop.Items.AddRange(new object[] {
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
            this.colorDrop.Location = new System.Drawing.Point(278, 622);
            this.colorDrop.Name = "colorDrop";
            this.colorDrop.Size = new System.Drawing.Size(208, 21);
            this.colorDrop.TabIndex = 15;
            this.colorDrop.SelectedIndexChanged += new System.EventHandler(this.colorDrop_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 625);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Color";
            // 
            // AddPaint
            // 
            this.AddPaint.Enabled = false;
            this.AddPaint.Location = new System.Drawing.Point(180, 665);
            this.AddPaint.Name = "AddPaint";
            this.AddPaint.Size = new System.Drawing.Size(306, 75);
            this.AddPaint.TabIndex = 17;
            this.AddPaint.Text = "Add Paint";
            this.AddPaint.UseVisualStyleBackColor = true;
            this.AddPaint.Click += new System.EventHandler(this.AddPaint_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(238, 801);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(180, 104);
            this.HomeButton.TabIndex = 18;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // VinDecoderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::BivinsBraxton_PaintShelf.Properties.Resources.iPhone7Image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(671, 1061);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.AddPaint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.colorDrop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PaintNameText);
            this.Controls.Add(this.PaintCodeText);
            this.Controls.Add(this.modelText);
            this.Controls.Add(this.makeText);
            this.Controls.Add(this.vinDecodeButton);
            this.Controls.Add(this.YearUD);
            this.Controls.Add(this.VinTText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "VinDecoderForm";
            this.Text = "VinDecoderForm";
            this.Load += new System.EventHandler(this.VinDecoderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YearUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox VinTText;
        private System.Windows.Forms.NumericUpDown YearUD;
        private System.Windows.Forms.Button vinDecodeButton;
        private System.Windows.Forms.TextBox makeText;
        private System.Windows.Forms.TextBox modelText;
        private System.Windows.Forms.TextBox PaintCodeText;
        private System.Windows.Forms.TextBox PaintNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox colorDrop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddPaint;
        private System.Windows.Forms.Button HomeButton;
    }
}