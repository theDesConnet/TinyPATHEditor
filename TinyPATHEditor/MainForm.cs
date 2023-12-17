using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace TinyPATHEditor
{
	public partial class MainForm : Form
	{
		// Get current user PATH value

		private string GetUserPATH()
		{
			return Registry.CurrentUser.OpenSubKey("Environment").GetValue("Path").ToString();
		}

		// Get system PATH value

		private string GetSystemPATH()
		{
			return Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment").GetValue("Path").ToString();
		}

		// Set current user PATH value

		private void SetUserPATH(string UserPATH)
		{
			Registry.CurrentUser.CreateSubKey("Environment").SetValue("Path", UserPATH);
		}

		// Set system PATH value

		private void SetSystemPATH(string SystemPATH)
		{
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment").SetValue("Path", SystemPATH);
		}

		// Form constructor

		public MainForm()
		{
			InitializeComponent();
		}

		// Form load event

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (UserRadio.Checked) PathBox.Text = GetUserPATH();
			if (SystemRadio.Checked) PathBox.Text = GetSystemPATH();
		}

		// Radio boxes events

		private void UserRadio_CheckedChanged(object sender, EventArgs e) { if (UserRadio.Checked) PathBox.Text = GetUserPATH(); }

		private void SystemRadio_CheckedChanged(object sender, EventArgs e) { if (SystemRadio.Checked) PathBox.Text = GetSystemPATH(); }

		// Apply changes

		private void ApplyButton_Click(object sender, EventArgs e)
		{
			// Show alert message

			if (MessageBox.Show("Are you sure you want to apply changes?\nThis operation can not be undone!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

			// Write new PATH value

			if (UserRadio.Checked) SetUserPATH(PathBox.Text);
			if (SystemRadio.Checked) SetSystemPATH(PathBox.Text);

			// Show message and logout if need

			MessageBox.Show("Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			if (LogoutCheck.Checked) Process.Start("shutdown", "/l");
		}

		// Disable "Apply" button if there is no text in PathBox.
		// Empty PATH value can make the system unusable!!!

		private void PathBox_TextChanged(object sender, EventArgs e)
		{
			ApplyButton.Enabled = (PathBox.Text.Length > 0);
		}

		// Open project's GitHub repository
        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
			Process.Start("https://github.com/AngelOfV0id/TinyPATHEditor");
        }
    }
}
