namespace TinyPATHEditor
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
            this.SystemRadio = new System.Windows.Forms.RadioButton();
            this.UserRadio = new System.Windows.Forms.RadioButton();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.LogoutCheck = new System.Windows.Forms.CheckBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SystemRadio
            // 
            this.SystemRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SystemRadio.Location = new System.Drawing.Point(145, 12);
            this.SystemRadio.Name = "SystemRadio";
            this.SystemRadio.Size = new System.Drawing.Size(187, 24);
            this.SystemRadio.TabIndex = 0;
            this.SystemRadio.Text = "System";
            this.SystemRadio.UseVisualStyleBackColor = true;
            this.SystemRadio.CheckedChanged += new System.EventHandler(this.SystemRadio_CheckedChanged);
            // 
            // UserRadio
            // 
            this.UserRadio.Checked = true;
            this.UserRadio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UserRadio.Location = new System.Drawing.Point(12, 12);
            this.UserRadio.Name = "UserRadio";
            this.UserRadio.Size = new System.Drawing.Size(127, 24);
            this.UserRadio.TabIndex = 1;
            this.UserRadio.TabStop = true;
            this.UserRadio.Text = "Current user only";
            this.UserRadio.UseVisualStyleBackColor = true;
            this.UserRadio.CheckedChanged += new System.EventHandler(this.UserRadio_CheckedChanged);
            // 
            // PathBox
            // 
            this.PathBox.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PathBox.Location = new System.Drawing.Point(12, 70);
            this.PathBox.Multiline = true;
            this.PathBox.Name = "PathBox";
            this.PathBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PathBox.Size = new System.Drawing.Size(320, 129);
            this.PathBox.TabIndex = 2;
            this.PathBox.TextChanged += new System.EventHandler(this.PathBox_TextChanged);
            // 
            // LogoutCheck
            // 
            this.LogoutCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LogoutCheck.Location = new System.Drawing.Point(12, 42);
            this.LogoutCheck.Name = "LogoutCheck";
            this.LogoutCheck.Size = new System.Drawing.Size(320, 22);
            this.LogoutCheck.TabIndex = 5;
            this.LogoutCheck.Text = "Logout after applying (recommended)";
            this.LogoutCheck.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ApplyButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyButton.Location = new System.Drawing.Point(257, 41);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 6;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 211);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.LogoutCheck);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.UserRadio);
            this.Controls.Add(this.SystemRadio);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiny PATH Editor";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton SystemRadio;
		private System.Windows.Forms.RadioButton UserRadio;
		private System.Windows.Forms.TextBox PathBox;
		private System.Windows.Forms.CheckBox LogoutCheck;
		private System.Windows.Forms.Button ApplyButton;
	}
}