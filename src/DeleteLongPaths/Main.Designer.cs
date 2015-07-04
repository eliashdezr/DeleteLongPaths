using System.Windows.Forms;

namespace DeleteLongPaths
{
    partial class Main
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
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.Label();
            this.FolderToDeleteLabel = new System.Windows.Forms.Label();
            this.FolderToDeleteText = new System.Windows.Forms.Label();
            this.selectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DeleteFolderButton = new System.Windows.Forms.Button();
            this.ProcessingAnimation = new System.Windows.Forms.PictureBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectFolderButton.Location = new System.Drawing.Point(18, 12);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(138, 23);
            this.SelectFolderButton.TabIndex = 0;
            this.SelectFolderButton.Text = "Select folder to delete";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(15, 40);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(47, 13);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Status:";
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Location = new System.Drawing.Point(59, 40);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(33, 13);
            this.StatusText.TabIndex = 2;
            this.StatusText.Text = "Idle...";
            // 
            // FolderToDeleteLabel
            // 
            this.FolderToDeleteLabel.AutoSize = true;
            this.FolderToDeleteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderToDeleteLabel.Location = new System.Drawing.Point(15, 62);
            this.FolderToDeleteLabel.Name = "FolderToDeleteLabel";
            this.FolderToDeleteLabel.Size = new System.Drawing.Size(100, 13);
            this.FolderToDeleteLabel.TabIndex = 3;
            this.FolderToDeleteLabel.Text = "Folder to delete:";
            // 
            // FolderToDeleteText
            // 
            this.FolderToDeleteText.Location = new System.Drawing.Point(15, 75);
            this.FolderToDeleteText.Name = "FolderToDeleteText";
            this.FolderToDeleteText.Size = new System.Drawing.Size(380, 44);
            this.FolderToDeleteText.TabIndex = 4;
            // 
            // DeleteFolderButton
            // 
            this.DeleteFolderButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteFolderButton.Enabled = false;
            this.DeleteFolderButton.Location = new System.Drawing.Point(180, 12);
            this.DeleteFolderButton.Name = "DeleteFolderButton";
            this.DeleteFolderButton.Size = new System.Drawing.Size(138, 23);
            this.DeleteFolderButton.TabIndex = 5;
            this.DeleteFolderButton.Text = "Delete folder";
            this.DeleteFolderButton.UseVisualStyleBackColor = true;
            this.DeleteFolderButton.Click += new System.EventHandler(this.DeleteFolderButton_Click);
            // 
            // ProcessingAnimation
            // 
            this.ProcessingAnimation.Image = global::GlobalResource.Resources.ProcessingImage;
            this.ProcessingAnimation.InitialImage = null;
            this.ProcessingAnimation.Location = new System.Drawing.Point(402, 41);
            this.ProcessingAnimation.Name = "ProcessingAnimation";
            this.ProcessingAnimation.Size = new System.Drawing.Size(21, 13);
            this.ProcessingAnimation.TabIndex = 6;
            this.ProcessingAnimation.TabStop = false;
            this.ProcessingAnimation.Visible = false;
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AuthorLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorLabel.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.AuthorLabel.Location = new System.Drawing.Point(339, 17);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(84, 14);
            this.AuthorLabel.TabIndex = 7;
            this.AuthorLabel.Text = "@eliashdezr";
            this.AuthorLabel.Click += new System.EventHandler(this.AuthorLabel_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 126);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.ProcessingAnimation);
            this.Controls.Add(this.DeleteFolderButton);
            this.Controls.Add(this.FolderToDeleteText);
            this.Controls.Add(this.FolderToDeleteLabel);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.SelectFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Long Paths";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Label FolderToDeleteLabel;
        private System.Windows.Forms.Label FolderToDeleteText;
        private System.Windows.Forms.FolderBrowserDialog selectFolderDialog;
        private System.Windows.Forms.Button DeleteFolderButton;
        private System.Windows.Forms.PictureBox ProcessingAnimation;
        private Label AuthorLabel;
    }
}

