// Copyright (c) Elías Hernández. All Rights Reserved. Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alphaleonis.Win32.Filesystem;
using GlobalResource;

namespace DeleteLongPaths
{
    public partial class Main : Form
    {
        private static Stopwatch StopWatch;
        public Main()
        {
            StopWatch = new Stopwatch();
            InitializeComponent();            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        #region Events

        private void AuthorLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/eliashdezr");
        }

        private async void DeleteFolderButton_Click(object sender, EventArgs e)
        {
            var shouldDeleteFolder = ConfirmDeleteAction();

            if (shouldDeleteFolder == false)
            {
                ResetToInitialState();
            }

            ProcessIsRunning(true);

            await RunDeleteTaskAsync();

            ProcessIsRunning(false);             
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            var result = selectFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateSelectedFolder(selectFolderDialog.SelectedPath);
                DeleteButtonToggle(true);
            }
        }

        #endregion

        #region API

        private bool ConfirmDeleteAction()
        {
            var confirmDeleteAction = MessageBox.Show(Resources.ConfirmDeleteMessage,
                Resources.ConfirmDeleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return confirmDeleteAction == DialogResult.Yes;
        }

        private void DeleteButtonToggle(bool flag)
        {
            DeleteFolderButton.Enabled = flag;
        }

        private void ResetToInitialState()
        {
            this.Text = @"Delete Long Paths";
            FolderToDeleteText.Text = null;
            UpdateStatus("Idle...");
            DeleteButtonToggle(false);
        }

        private async Task<bool> RunDeleteTaskAsync()
        {
            try
            {
                UpdateStatus("Deleting...");

                await Task.Factory.StartNew(path => Directory.Delete(FolderToDeleteText.Text, true, true), string.Empty);

                StopWatch.Stop();

                var timeElapsed = string.Format("{0} minutes {1} seconds", Math.Floor(StopWatch.Elapsed.TotalMinutes),
                    StopWatch.Elapsed.ToString("ss"));

                StopWatch.Reset();

                if (Directory.Exists(FolderToDeleteText.Text))
                {
                    UpdateStatus("Folder could not be completely deleted, verify is not locked by a process.");
                }
                else
                {
                    ResetToInitialState();
                    UpdateStatus(string.Format("Folder succesfully deleted! Took {0}.", timeElapsed));
                }

                return true;
            }
            catch (Exception e)
            {
                UpdateStatus(e.Message);
                return false;
            }
        }

        private void ProcessIsRunning(bool flag)
        {
            if (flag)
            {
                StopWatch.Start();
                this.Text = @"DLP: Working...";
                DeleteFolderButton.Enabled = false;
                SelectFolderButton.Enabled = false;
                ProcessingAnimation.Visible = true;
            }
            else
            {                
                this.Text = @"DLP: Task finished";
                SelectFolderButton.Enabled = true;
                ProcessingAnimation.Visible = false;                
                SystemSounds.Asterisk.Play();                
            }            
        }

        private void UpdateStatus(string statusMessage)
        {
            StatusText.Text = statusMessage;
        }

        private void UpdateSelectedFolder(string folderSelected)
        {
            FolderToDeleteText.Text = folderSelected;
        }

        #endregion                
    }
}