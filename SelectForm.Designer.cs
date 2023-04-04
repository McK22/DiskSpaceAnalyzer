namespace DiskSpaceAnalyzer
{
    partial class SelectForm
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
            listView = new ListView();
            nameHeader = new ColumnHeader();
            totalHeader = new ColumnHeader();
            freeHeader = new ColumnHeader();
            usedTotalProgressBar = new ColumnHeader();
            usedTotalHeader = new ColumnHeader();
            cancelButton = new Button();
            okButton = new Button();
            pathTextBox = new TextBox();
            browseButton = new Button();
            pathComboBox = new ComboBox();
            allDrivesRadioButton = new RadioButton();
            individualDriveRadioButton = new RadioButton();
            folderRadioButton = new RadioButton();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { nameHeader, totalHeader, freeHeader, usedTotalProgressBar, usedTotalHeader });
            listView.FullRowSelect = true;
            listView.Location = new Point(14, 83);
            listView.Margin = new Padding(3, 4, 3, 4);
            listView.Name = "listView";
            listView.Size = new Size(525, 128);
            listView.TabIndex = 3;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // nameHeader
            // 
            nameHeader.Text = "Name";
            // 
            // totalHeader
            // 
            totalHeader.Text = "Total";
            totalHeader.Width = 80;
            // 
            // freeHeader
            // 
            freeHeader.Text = "Free";
            freeHeader.Width = 80;
            // 
            // usedTotalProgressBar
            // 
            usedTotalProgressBar.Text = "Used/Total";
            usedTotalProgressBar.Width = 100;
            // 
            // usedTotalHeader
            // 
            usedTotalHeader.Text = "Used/Total";
            usedTotalHeader.Width = 100;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(447, 300);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(86, 31);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Location = new Point(354, 300);
            okButton.Margin = new Padding(3, 4, 3, 4);
            okButton.Name = "okButton";
            okButton.Size = new Size(86, 31);
            okButton.TabIndex = 5;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += CloseWindow;
            // 
            // pathTextBox
            // 
            pathTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pathTextBox.Location = new Point(14, 253);
            pathTextBox.Margin = new Padding(3, 4, 3, 4);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(426, 27);
            pathTextBox.TabIndex = 6;
            pathTextBox.TextChanged += pathTextBox_TextChanged;
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            browseButton.Location = new Point(447, 253);
            browseButton.Margin = new Padding(3, 4, 3, 4);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(86, 31);
            browseButton.TabIndex = 7;
            browseButton.Text = "...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // pathComboBox
            // 
            pathComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pathComboBox.FormattingEnabled = true;
            pathComboBox.Location = new Point(14, 252);
            pathComboBox.Name = "pathComboBox";
            pathComboBox.Size = new Size(426, 28);
            pathComboBox.TabIndex = 8;
            pathComboBox.Visible = false;
            pathComboBox.DropDownClosed += pathComboBox_DropDownClosed;
            // 
            // allDrivesRadioButton
            // 
            allDrivesRadioButton.AutoSize = true;
            allDrivesRadioButton.Checked = true;
            allDrivesRadioButton.Location = new Point(14, 12);
            allDrivesRadioButton.Name = "allDrivesRadioButton";
            allDrivesRadioButton.Size = new Size(132, 24);
            allDrivesRadioButton.TabIndex = 9;
            allDrivesRadioButton.TabStop = true;
            allDrivesRadioButton.Text = "&All Local Drives";
            allDrivesRadioButton.UseVisualStyleBackColor = true;
            allDrivesRadioButton.CheckedChanged += CheckChanged;
            // 
            // individualDriveRadioButton
            // 
            individualDriveRadioButton.AutoSize = true;
            individualDriveRadioButton.Location = new Point(14, 52);
            individualDriveRadioButton.Name = "individualDriveRadioButton";
            individualDriveRadioButton.Size = new Size(140, 24);
            individualDriveRadioButton.TabIndex = 10;
            individualDriveRadioButton.Text = "&Individual Drives";
            individualDriveRadioButton.UseVisualStyleBackColor = true;
            individualDriveRadioButton.CheckedChanged += CheckChanged;
            // 
            // folderRadioButton
            // 
            folderRadioButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            folderRadioButton.AutoSize = true;
            folderRadioButton.Location = new Point(14, 218);
            folderRadioButton.Name = "folderRadioButton";
            folderRadioButton.Size = new Size(86, 24);
            folderRadioButton.TabIndex = 11;
            folderRadioButton.Text = "A &Folder";
            folderRadioButton.UseVisualStyleBackColor = true;
            folderRadioButton.CheckedChanged += CheckChanged;
            // 
            // SelectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 348);
            Controls.Add(folderRadioButton);
            Controls.Add(individualDriveRadioButton);
            Controls.Add(allDrivesRadioButton);
            Controls.Add(browseButton);
            Controls.Add(pathTextBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(listView);
            Controls.Add(pathComboBox);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(569, 384);
            Name = "SelectForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView listView;
        private ColumnHeader nameHeader;
        private ColumnHeader totalHeader;
        private ColumnHeader freeHeader;
        private ColumnHeader usedTotalProgressBar;
        private Button cancelButton;
        private Button okButton;
        private TextBox pathTextBox;
        private Button browseButton;
        private ColumnHeader usedTotalHeader;
        private ComboBox pathComboBox;
        private RadioButton allDrivesRadioButton;
        private RadioButton individualDriveRadioButton;
        private RadioButton folderRadioButton;
    }
}