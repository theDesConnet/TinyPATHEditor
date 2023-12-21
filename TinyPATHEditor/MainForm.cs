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
		private string CurrentPath;

		/// <summary>
		/// Get Path from registry
		/// </summary>
		/// <param name="isUserPath">This is user path</param>
		/// <returns>Path</returns>
		private string GetPATH(bool isUserPath)
		{
			return isUserPath ? Registry.CurrentUser.OpenSubKey("Environment").GetValue("Path").ToString() : Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment").GetValue("Path").ToString();
		}

		/// <summary>
		/// Set Path from registry
		/// </summary>
		/// <param name="isUserPath">This is user path</param>
		/// <param name="PATH">Path to set</param>
		private void SetPATH(bool isUserPath, string PATH)
		{
			if (isUserPath) Registry.CurrentUser.CreateSubKey("Environment").SetValue("Path", PATH);
			else Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment").SetValue("Path", PATH);
		}

		/// <summary>
		/// Get Path in array
		/// </summary>
		/// <param name="isUserPath">This is user path</param>
		/// <returns>Array path's</returns>
		private string[] GetPathArray(bool isUserPath)
        {
			List<string> _strList = new List<string>();

			foreach (string s in CurrentPath.Split(';'))
            {
				if (!String.IsNullOrEmpty(s)) _strList.Add(s);
			}

			return _strList.ToArray();
        }

		private string[] GetTableRows()
        {
			List<string> _getPath = new List<string>();
			foreach (DataGridViewRow row in PathTable.Rows)
			{
				if (row.Cells[0].Value != null) _getPath.Add(row.Cells[0].Value.ToString());
			}
			return _getPath.ToArray();
		}

		/// <summary>
		/// Set table path
		/// </summary>
		/// <param name="path">Array path</param>
		public void SetTablePath(string[] path)
        {
			PathTable.Rows.Clear();
			foreach (string row in path)
            {
				PathTable.Rows.Add(row);
            }
        }
			 
		// Form constructor

		public MainForm()
		{
			InitializeComponent();
		}

		// Form load event

		private void MainForm_Load(object sender, EventArgs e)
		{
			CurrentPath = PathBox.Text = GetPATH(UserRadio.Checked);
			SetTablePath(GetPathArray(UserRadio.Checked));
		}

		// Radio boxes events

		private void UserRadio_CheckedChanged(object sender, EventArgs e) { CurrentPath = PathBox.Text = GetPATH(UserRadio.Checked); }

		private void SystemRadio_CheckedChanged(object sender, EventArgs e) { CurrentPath = PathBox.Text = GetPATH(UserRadio.Checked); }

		// Apply changes

		private void ApplyButton_Click(object sender, EventArgs e)
		{
			// Show alert message

			if (MessageBox.Show("Are you sure you want to apply changes?\nThis operation can not be undone!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

			// Write new PATH value

			SetPATH(UserRadio.Checked, CurrentPath);

			// Show message and logout if need

			MessageBox.Show("Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			if (LogoutCheck.Checked) Process.Start("shutdown", "/l");
		}

		// Disable "Apply" button if there is no text in PathBox.
		// Empty PATH value can make the system unusable!!!

		private void PathBox_TextChanged(object sender, EventArgs e)
        {

            ApplyButton.Enabled = (PathBox.Text.Length > 0);
            if (CurrentPath != PathBox.Text) CurrentPath = PathBox.Text;

			if (GetTableRows() != GetPathArray(UserRadio.Checked)) SetTablePath(GetPathArray(UserRadio.Checked));
		}

		// Open project's GitHub repository
        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
			Process.Start("https://github.com/AngelOfV0id/TinyPATHEditor");
        }

        private void PathTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
			PathBox.Text = String.Join(";", GetTableRows());
		}
    }
}
