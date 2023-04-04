using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskSpaceAnalyzer
{
    public partial class SelectForm : Form
    {
        private readonly MainWindow mainWindow;
        private readonly Color wrongPathColor = Color.Red;
        private readonly Color correctPathColor = Color.Black;

        private bool altPressed = false;
        public SelectForm(MainWindow mainWindow)
        {
            InitializeComponent();
            InitDisks();
            this.mainWindow = mainWindow;
        }

        public static string BetterSizeDisplay(long n)
        {
            double size = n;
            int b = 1024;
            string s = " B";
            if (size > b)
            {
                size /= b;
                s = " kB";
                if (size > b)
                {
                    size /= b;
                    s = " MB";
                    if (size > b)
                    {
                        size /= b;
                        s = " GB";
                    }
                }
            }
            return Math.Round(size, 1) + s;
        }

        private void InitDisks()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string totalSizeString = BetterSizeDisplay(drive.TotalSize);
                string freeSpaceString = BetterSizeDisplay(drive.TotalFreeSpace);
                double usedPercentage = (double)(drive.TotalSize - drive.AvailableFreeSpace) / drive.TotalSize * 100;
                string usedPercentageString = Math.Round(usedPercentage, 2).ToString() + '%';

                string progressBarKey = "PB";
                ListViewItem listViewItem = new();
                listViewItem.SubItems[0].Text = drive.Name;
                listViewItem.SubItems.Add(totalSizeString);
                listViewItem.SubItems.Add(freeSpaceString);
                listViewItem.SubItems.Add("");
                listViewItem.SubItems.Add(usedPercentageString);
                listViewItem.SubItems.Add(progressBarKey);
                listView.Items.Add(listViewItem);

                _ = listViewItem.Bounds;

                ProgressBar progressBar = new();
                progressBar.Bounds = listViewItem.SubItems[3].Bounds;
                progressBar.Minimum = 0;
                progressBar.Maximum = 10000;
                progressBar.Value = (int)Math.Round(usedPercentage * 100);
                progressBar.Name = progressBarKey;
                listView.Controls.Add(progressBar);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
            if (folderRadioButton.Checked)
                mainWindow.PrintTreeView(pathTextBox.Text);
            else if (allDrivesRadioButton.Checked)
                mainWindow.InitTreeView();
            else if (individualDriveRadioButton.Checked)
            {
                mainWindow.ClearTreeView();
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    string driveName = item.SubItems[0].Text;
                    mainWindow.AddDriveToTreeView(driveName);
                }
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowComboBox()
        {
            pathComboBox.Items.Clear();
            try
            {
                foreach (string dir in Directory.GetDirectories(pathTextBox.Text))
                    pathComboBox.Items.Add(dir);
            }
            catch (UnauthorizedAccessException) { }
            pathComboBox.DroppedDown = pathComboBox.Items.Count > 0;
            Cursor.Current = Cursors.Default;
        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(pathTextBox.Text))
            {
                pathTextBox.ForeColor = correctPathColor;
                ShowComboBox();
            }
            else
            {
                pathComboBox.DroppedDown = false;
                pathTextBox.ForeColor = wrongPathColor;
            }
        }

        private void pathComboBox_DropDownClosed(object sender, EventArgs e)
        {
            string path = (string)pathComboBox.SelectedItem;
            if(path is not null && Directory.Exists(pathTextBox.Text))
                pathTextBox.Text = path;
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked)
            {
                if (button != allDrivesRadioButton)
                    allDrivesRadioButton.Checked = false;
                if (button != individualDriveRadioButton)
                    individualDriveRadioButton.Checked = false;
                if (button != folderRadioButton)
                    folderRadioButton.Checked = false;
            }
        }
    }
}
