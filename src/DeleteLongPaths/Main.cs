// Copyright (c) Elías Hernández. All Rights Reserved. Licensed under the MIT License.

using System;
using System.Drawing;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteLongPaths
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        #region Events

        private void AuthorLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/eliashdezr");
        }

        private async void DeleteFolderButton_Click(object sender, EventArgs e)
        {
            var shouldDeleteFolder = ConfirmDeleteAction();

            if (shouldDeleteFolder == false)
            {
                ResetToInitialState();
            }

            await DeleteFolder();                        
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
            var confirmDeleteAction = MessageBox.Show(GlobalResource.Resources.ConfirmDeleteMessage,
                GlobalResource.Resources.ConfirmDeleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return confirmDeleteAction == DialogResult.Yes;
        }

        private void DeleteButtonToggle(bool flag)
        {
            DeleteFolderButton.Enabled = flag;
        }

        private async Task<bool> DeleteFolder()
        {
            ToggleProcessingAnimation(true);
            var taskResult = await RunDeleteScriptAsync();
            ToggleProcessingAnimation(false);
            return taskResult;
        }

        private void ResetToInitialState()
        {
            FolderToDeleteText.Text = null;
            UpdateStatus("Idle...");
            DeleteButtonToggle(false);
        }

        private async Task<bool> RunDeleteScriptAsync()
        {
            // Try to ensure an unique folder name where the files are going to be linked.
            var workingFolderName = Guid.NewGuid().ToString();

            // Parent of the folder we are going to delete.
            var parentFolder = Path.GetFullPath(Path.Combine(FolderToDeleteText.Text, @"..\"));

            // Create the working directory.
            UpdateStatus("Creating working folder...");
            var workingFolderPath = Path.Combine(parentFolder, workingFolderName);
            Directory.CreateDirectory(workingFolderPath);

            // Run the script to mirror the files into the working folder.
            UpdateStatus("Creating mirrors into the working directory, this will take a while...");
            var scriptCreateMirror = string.Format("robocopy {0} {1} /s /mir", workingFolderPath,
                FolderToDeleteText.Text);

            if (await ScriptRunnerAsync(scriptCreateMirror) == false)
            {
                UpdateStatus("Error creating the file/folder mirrors in the working folder.");
                return false;
            }

            // Run the script to delete folders.
            UpdateStatus("Deleting the folder...");
            var scriptDeleteFolder = string.Format("rmdir {0} -Recurse -Force; rmdir {1}", FolderToDeleteText.Text,
                workingFolderPath);

            if (await ScriptRunnerAsync(scriptDeleteFolder) == false)
            {
                UpdateStatus("Error deleting the folder.");
                return false;
            }

            if (Directory.Exists(FolderToDeleteText.Text))
            {
                UpdateStatus("Folder could not be completely deleted, verify is not locked by a process.");
            }
            else
            {
                ResetToInitialState();
                UpdateStatus("Folder succesfully deleted!");
            }

            return true;
        }

        private async Task<bool> ScriptRunnerAsync(string script)
        {
            try
            {
                using (var powershell = PowerShell.Create())
                {
                    powershell.AddScript(script);
                    await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void ToggleProcessingAnimation(bool flag)
        {
            ProcessingAnimation.Visible = flag;
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