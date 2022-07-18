namespace Client.View
{
    partial class SettingsForm
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
            this.HPLabel = new System.Windows.Forms.Label();
            this.HPCount = new System.Windows.Forms.Label();
            this.HPAddButton = new System.Windows.Forms.Button();
            this.DamageAddButton = new System.Windows.Forms.Button();
            this.DamageCount = new System.Windows.Forms.Label();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.SpeedAddButton = new System.Windows.Forms.Button();
            this.SpeedCount = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HPLabel
            // 
            this.HPLabel.AutoSize = true;
            this.HPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HPLabel.Location = new System.Drawing.Point(12, 21);
            this.HPLabel.Name = "HPLabel";
            this.HPLabel.Size = new System.Drawing.Size(61, 37);
            this.HPLabel.TabIndex = 0;
            this.HPLabel.Text = "HP";
            // 
            // HPCount
            // 
            this.HPCount.AutoSize = true;
            this.HPCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HPCount.Location = new System.Drawing.Point(179, 26);
            this.HPCount.Name = "HPCount";
            this.HPCount.Size = new System.Drawing.Size(24, 25);
            this.HPCount.TabIndex = 1;
            this.HPCount.Text = "1";
            // 
            // HPAddButton
            // 
            this.HPAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HPAddButton.Location = new System.Drawing.Point(207, 23);
            this.HPAddButton.Name = "HPAddButton";
            this.HPAddButton.Size = new System.Drawing.Size(31, 31);
            this.HPAddButton.TabIndex = 2;
            this.HPAddButton.Text = "+";
            this.HPAddButton.UseVisualStyleBackColor = true;
            this.HPAddButton.Click += new System.EventHandler(this.HPAddButton_Click);
            // 
            // DamageAddButton
            // 
            this.DamageAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DamageAddButton.Location = new System.Drawing.Point(207, 88);
            this.DamageAddButton.Name = "DamageAddButton";
            this.DamageAddButton.Size = new System.Drawing.Size(31, 31);
            this.DamageAddButton.TabIndex = 5;
            this.DamageAddButton.Text = "+";
            this.DamageAddButton.UseVisualStyleBackColor = true;
            this.DamageAddButton.Click += new System.EventHandler(this.DamageAddButton_Click);
            // 
            // DamageCount
            // 
            this.DamageCount.AutoSize = true;
            this.DamageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DamageCount.Location = new System.Drawing.Point(179, 91);
            this.DamageCount.Name = "DamageCount";
            this.DamageCount.Size = new System.Drawing.Size(24, 25);
            this.DamageCount.TabIndex = 4;
            this.DamageCount.Text = "1";
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DamageLabel.Location = new System.Drawing.Point(12, 86);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(138, 37);
            this.DamageLabel.TabIndex = 3;
            this.DamageLabel.Text = "Damage";
            // 
            // SpeedAddButton
            // 
            this.SpeedAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedAddButton.Location = new System.Drawing.Point(207, 151);
            this.SpeedAddButton.Name = "SpeedAddButton";
            this.SpeedAddButton.Size = new System.Drawing.Size(31, 31);
            this.SpeedAddButton.TabIndex = 8;
            this.SpeedAddButton.Text = "+";
            this.SpeedAddButton.UseVisualStyleBackColor = true;
            this.SpeedAddButton.Click += new System.EventHandler(this.SpeedAddButton_Click);
            // 
            // SpeedCount
            // 
            this.SpeedCount.AutoSize = true;
            this.SpeedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedCount.Location = new System.Drawing.Point(179, 154);
            this.SpeedCount.Name = "SpeedCount";
            this.SpeedCount.Size = new System.Drawing.Size(24, 25);
            this.SpeedCount.TabIndex = 7;
            this.SpeedCount.Text = "1";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpeedLabel.Location = new System.Drawing.Point(12, 149);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(108, 37);
            this.SpeedLabel.TabIndex = 6;
            this.SpeedLabel.Text = "Speed";
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SaveButton.Location = new System.Drawing.Point(19, 202);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(219, 50);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 264);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SpeedAddButton);
            this.Controls.Add(this.SpeedCount);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.DamageAddButton);
            this.Controls.Add(this.DamageCount);
            this.Controls.Add(this.DamageLabel);
            this.Controls.Add(this.HPAddButton);
            this.Controls.Add(this.HPCount);
            this.Controls.Add(this.HPLabel);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HPLabel;
        private System.Windows.Forms.Button HPAddButton;
        private System.Windows.Forms.Button DamageAddButton;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.Button SpeedAddButton;
        private System.Windows.Forms.Label SpeedLabel;
        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Label HPCount;
        public System.Windows.Forms.Label DamageCount;
        public System.Windows.Forms.Label SpeedCount;
    }
}