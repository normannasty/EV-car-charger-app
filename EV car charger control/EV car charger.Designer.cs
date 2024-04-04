namespace YourNamespace
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
            this.leftStartButton = new System.Windows.Forms.Button();
            this.rightStartButton = new System.Windows.Forms.Button();
            this.leftStopButton = new System.Windows.Forms.Button();
            this.rightStopButton = new System.Windows.Forms.Button();
            this.leftTimeDropdown = new System.Windows.Forms.ComboBox();
            this.rightTimeDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.leftIndicator1 = new System.Windows.Forms.PictureBox();
            this.leftIndicator2 = new System.Windows.Forms.PictureBox();
            this.leftIndicator3 = new System.Windows.Forms.PictureBox();
            this.rightIndicator3 = new System.Windows.Forms.PictureBox();
            this.rightIndicator2 = new System.Windows.Forms.PictureBox();
            this.rightIndicator1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.leftIndicator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftIndicator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftIndicator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightIndicator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightIndicator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightIndicator1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftStartButton
            // 
            this.leftStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.leftStartButton.Location = new System.Drawing.Point(109, 141);
            this.leftStartButton.Name = "leftStartButton";
            this.leftStartButton.Size = new System.Drawing.Size(121, 40);
            this.leftStartButton.TabIndex = 0;
            this.leftStartButton.Text = "INDÍTÁS";
            this.leftStartButton.UseVisualStyleBackColor = false;
            this.leftStartButton.Click += new System.EventHandler(this.leftStartButton_Click);
            // 
            // rightStartButton
            // 
            this.rightStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rightStartButton.Location = new System.Drawing.Point(414, 141);
            this.rightStartButton.Name = "rightStartButton";
            this.rightStartButton.Size = new System.Drawing.Size(121, 40);
            this.rightStartButton.TabIndex = 1;
            this.rightStartButton.Text = "INDÍTÁS";
            this.rightStartButton.UseVisualStyleBackColor = false;
            this.rightStartButton.Click += new System.EventHandler(this.rightStartButton_Click);
            // 
            // leftStopButton
            // 
            this.leftStopButton.BackColor = System.Drawing.Color.Crimson;
            this.leftStopButton.Location = new System.Drawing.Point(109, 212);
            this.leftStopButton.Name = "leftStopButton";
            this.leftStopButton.Size = new System.Drawing.Size(121, 40);
            this.leftStopButton.TabIndex = 2;
            this.leftStopButton.Text = "LEÁLLÍTÁS";
            this.leftStopButton.UseVisualStyleBackColor = false;
            this.leftStopButton.Click += new System.EventHandler(this.leftStopButton_Click);
            // 
            // rightStopButton
            // 
            this.rightStopButton.BackColor = System.Drawing.Color.Crimson;
            this.rightStopButton.Location = new System.Drawing.Point(414, 212);
            this.rightStopButton.Name = "rightStopButton";
            this.rightStopButton.Size = new System.Drawing.Size(121, 40);
            this.rightStopButton.TabIndex = 3;
            this.rightStopButton.Text = "LEÁLLÍTÁS";
            this.rightStopButton.UseVisualStyleBackColor = false;
            this.rightStopButton.Click += new System.EventHandler(this.rightStopButton_Click);
            // 
            // leftTimeDropdown
            // 
            this.leftTimeDropdown.FormattingEnabled = true;
            this.leftTimeDropdown.Location = new System.Drawing.Point(109, 58);
            this.leftTimeDropdown.Name = "leftTimeDropdown";
            this.leftTimeDropdown.Size = new System.Drawing.Size(121, 21);
            this.leftTimeDropdown.TabIndex = 4;
            // 
            // rightTimeDropdown
            // 
            this.rightTimeDropdown.FormattingEnabled = true;
            this.rightTimeDropdown.Location = new System.Drawing.Point(414, 58);
            this.rightTimeDropdown.Name = "rightTimeDropdown";
            this.rightTimeDropdown.Size = new System.Drawing.Size(121, 21);
            this.rightTimeDropdown.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(125, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "BAL TÖLTŐ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(425, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "JOBB TÖLTŐ";
            // 
            // leftIndicator1
            // 
            this.leftIndicator1.BackColor = System.Drawing.Color.Crimson;
            this.leftIndicator1.Location = new System.Drawing.Point(121, 292);
            this.leftIndicator1.Name = "leftIndicator1";
            this.leftIndicator1.Size = new System.Drawing.Size(18, 20);
            this.leftIndicator1.TabIndex = 8;
            this.leftIndicator1.TabStop = false;
            // 
            // leftIndicator2
            // 
            this.leftIndicator2.BackColor = System.Drawing.Color.Crimson;
            this.leftIndicator2.Location = new System.Drawing.Point(160, 292);
            this.leftIndicator2.Name = "leftIndicator2";
            this.leftIndicator2.Size = new System.Drawing.Size(18, 20);
            this.leftIndicator2.TabIndex = 9;
            this.leftIndicator2.TabStop = false;
            // 
            // leftIndicator3
            // 
            this.leftIndicator3.BackColor = System.Drawing.Color.Crimson;
            this.leftIndicator3.Location = new System.Drawing.Point(196, 292);
            this.leftIndicator3.Name = "leftIndicator3";
            this.leftIndicator3.Size = new System.Drawing.Size(18, 20);
            this.leftIndicator3.TabIndex = 10;
            this.leftIndicator3.TabStop = false;
            // 
            // rightIndicator3
            // 
            this.rightIndicator3.BackColor = System.Drawing.Color.Crimson;
            this.rightIndicator3.Location = new System.Drawing.Point(501, 292);
            this.rightIndicator3.Name = "rightIndicator3";
            this.rightIndicator3.Size = new System.Drawing.Size(18, 20);
            this.rightIndicator3.TabIndex = 13;
            this.rightIndicator3.TabStop = false;
            // 
            // rightIndicator2
            // 
            this.rightIndicator2.BackColor = System.Drawing.Color.Crimson;
            this.rightIndicator2.Location = new System.Drawing.Point(465, 292);
            this.rightIndicator2.Name = "rightIndicator2";
            this.rightIndicator2.Size = new System.Drawing.Size(18, 20);
            this.rightIndicator2.TabIndex = 12;
            this.rightIndicator2.TabStop = false;
            // 
            // rightIndicator1
            // 
            this.rightIndicator1.BackColor = System.Drawing.Color.Crimson;
            this.rightIndicator1.Location = new System.Drawing.Point(426, 292);
            this.rightIndicator1.Name = "rightIndicator1";
            this.rightIndicator1.Size = new System.Drawing.Size(18, 20);
            this.rightIndicator1.TabIndex = 11;
            this.rightIndicator1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
            this.Controls.Add(this.rightIndicator3);
            this.Controls.Add(this.rightIndicator2);
            this.Controls.Add(this.rightIndicator1);
            this.Controls.Add(this.leftIndicator3);
            this.Controls.Add(this.leftIndicator2);
            this.Controls.Add(this.leftIndicator1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightTimeDropdown);
            this.Controls.Add(this.leftTimeDropdown);
            this.Controls.Add(this.rightStopButton);
            this.Controls.Add(this.leftStopButton);
            this.Controls.Add(this.rightStartButton);
            this.Controls.Add(this.leftStartButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "EV car charger control";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftIndicator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftIndicator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftIndicator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightIndicator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightIndicator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightIndicator1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button leftStartButton;
        private System.Windows.Forms.Button rightStartButton;
        private System.Windows.Forms.Button leftStopButton;
        private System.Windows.Forms.Button rightStopButton;
        private System.Windows.Forms.ComboBox leftTimeDropdown;
        private System.Windows.Forms.ComboBox rightTimeDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox leftIndicator1;
        private System.Windows.Forms.PictureBox leftIndicator2;
        private System.Windows.Forms.PictureBox leftIndicator3;
        private System.Windows.Forms.PictureBox rightIndicator3;
        private System.Windows.Forms.PictureBox rightIndicator2;
        private System.Windows.Forms.PictureBox rightIndicator1;
    }
}

