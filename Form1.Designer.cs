namespace DiskSpaceAnalyzer
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            splitContainer = new SplitContainer();
            treeView = new TreeView();
            selectButton = new Button();
            tabControl = new TabControl();
            detailsPage = new TabPage();
            detailsValueListBox = new ListBox();
            detailsNameListBox = new ListBox();
            chartsTabPage = new TabPage();
            statusStrip = new StatusStrip();
            dirIterationProgressBar = new ToolStripProgressBar();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            tabControl.SuspendLayout();
            detailsPage.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 3, 0, 3);
            menuStrip.Size = new Size(914, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectToolStripMenuItem, cancelToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            selectToolStripMenuItem.Size = new Size(186, 26);
            selectToolStripMenuItem.Text = "&Select";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Enabled = false;
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            cancelToolStripMenuItem.Size = new Size(186, 26);
            cancelToolStripMenuItem.Text = "&Cancel";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(186, 26);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(133, 26);
            aboutToolStripMenuItem.Text = "&About";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 30);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(treeView);
            splitContainer.Panel1.Controls.Add(selectButton);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(tabControl);
            splitContainer.Size = new Size(914, 570);
            splitContainer.SplitterDistance = 281;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 1;
            // 
            // treeView
            // 
            treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView.Location = new Point(3, 43);
            treeView.Margin = new Padding(3, 4, 3, 4);
            treeView.Name = "treeView";
            treeView.Size = new Size(274, 493);
            treeView.TabIndex = 1;
            treeView.AfterExpand += treeView_AfterExpand;
            treeView.AfterSelect += treeView_AfterSelect;
            // 
            // selectButton
            // 
            selectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectButton.Location = new Point(192, 4);
            selectButton.Margin = new Padding(3, 4, 3, 4);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(86, 31);
            selectButton.TabIndex = 0;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += Select;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(detailsPage);
            tabControl.Controls.Add(chartsTabPage);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(611, 535);
            tabControl.TabIndex = 0;
            // 
            // detailsPage
            // 
            detailsPage.BackColor = SystemColors.Window;
            detailsPage.Controls.Add(detailsValueListBox);
            detailsPage.Controls.Add(detailsNameListBox);
            detailsPage.Location = new Point(4, 29);
            detailsPage.Name = "detailsPage";
            detailsPage.Padding = new Padding(3);
            detailsPage.Size = new Size(603, 502);
            detailsPage.TabIndex = 0;
            detailsPage.Text = "Details";
            // 
            // detailsValueListBox
            // 
            detailsValueListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            detailsValueListBox.BorderStyle = BorderStyle.None;
            detailsValueListBox.FormattingEnabled = true;
            detailsValueListBox.ItemHeight = 20;
            detailsValueListBox.Location = new Point(179, 20);
            detailsValueListBox.Name = "detailsValueListBox";
            detailsValueListBox.Size = new Size(352, 460);
            detailsValueListBox.TabIndex = 2;
            // 
            // detailsNameListBox
            // 
            detailsNameListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            detailsNameListBox.BorderStyle = BorderStyle.None;
            detailsNameListBox.FormattingEnabled = true;
            detailsNameListBox.ItemHeight = 20;
            detailsNameListBox.Location = new Point(0, 20);
            detailsNameListBox.Name = "detailsNameListBox";
            detailsNameListBox.Size = new Size(182, 460);
            detailsNameListBox.TabIndex = 1;
            // 
            // chartsTabPage
            // 
            chartsTabPage.Location = new Point(4, 29);
            chartsTabPage.Name = "chartsTabPage";
            chartsTabPage.Padding = new Padding(3);
            chartsTabPage.Size = new Size(603, 502);
            chartsTabPage.TabIndex = 1;
            chartsTabPage.Text = "Charts";
            chartsTabPage.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { dirIterationProgressBar });
            statusStrip.Location = new Point(0, 573);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(914, 27);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // dirIterationProgressBar
            // 
            dirIterationProgressBar.Name = "dirIterationProgressBar";
            dirIterationProgressBar.Size = new Size(101, 19);
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(statusStrip);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 582);
            Name = "MainWindow";
            Text = "Disk Space Analyzer";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            detailsPage.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private SplitContainer splitContainer;
        private TreeView treeView;
        private Button selectButton;
        private StatusStrip statusStrip;
        private TabControl tabControl;
        private TabPage detailsPage;
        private TabPage chartsTabPage;
        private ListBox detailsNameListBox;
        private ListBox detailsValueListBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ToolStripProgressBar dirIterationProgressBar;
    }
}