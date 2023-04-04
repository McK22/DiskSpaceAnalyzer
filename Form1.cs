using System.ComponentModel;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace DiskSpaceAnalyzer
{
    public partial class MainWindow : Form
    {
        private const int MIN_FILE_COUNT_TO_GROUP = 4;
        private const int PROGRESS_BAR_MAX = 10000;
        private readonly string filesNodeName = "<files>";
        private readonly ChartsControl chartsControl = new();
        private readonly Dictionary<string, (int quantity, long size)> fileTypes = new();

        public MainWindow()
        {
            InitializeComponent();
            InitTreeView();
            InitDetailsNameBox();
            InitProgressBar();
            InitChartsControl();
        }

        private void InitChartsControl()
        {
            //    chartsControl.BackColor = Color.Green;
            chartsControl.Dock = DockStyle.Fill;
            chartsTabPage.Controls.Add(chartsControl);
        }

        private void InitProgressBar()
        {
            dirIterationProgressBar.Visible = false;
            dirIterationProgressBar.Minimum = 0;
            dirIterationProgressBar.Maximum = PROGRESS_BAR_MAX;
        }

        public void InitTreeView()
        {
            treeView.Nodes.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
                AddDriveToTreeView(drive);
        }

        private void InitDetailsNameBox()
        {
            detailsNameListBox.Items.Add("Full path:");
            detailsNameListBox.Items.Add("Size:");
            detailsNameListBox.Items.Add("Items:");
            detailsNameListBox.Items.Add("Files:");
            detailsNameListBox.Items.Add("Subdirs:");
            detailsNameListBox.Items.Add("Last change:");
        }

        public void AddDriveToTreeView(DriveInfo drive)
        {
            List<TreeNode> children = new()
            {
                new TreeNode(drive.RootDirectory.Name)
            };
            TreeNode treeNode = new TreeNode(drive.Name, children.ToArray());
            treeNode.Name = drive.Name;
            treeView.Nodes.Add(treeNode);
        }

        public void AddDriveToTreeView(string drive)
        {
            List<TreeNode> children = new()
            {
                new TreeNode("")
            };
            TreeNode treeNode = new TreeNode(drive, children.ToArray());
            treeNode.Name = drive;
            treeView.Nodes.Add(treeNode);
        }

        private void Select(object sender, EventArgs e)
        {
            SelectForm dialog = new SelectForm(this);
            dialog.ShowDialog();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Select(sender, e);
        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == filesNodeName)
                return;

            string path = e.Node.Name;

            e.Node.Nodes.Clear();
            foreach (string dir in Directory.GetDirectories(path))
            {
                List<TreeNode> children = new();
                try
                {
                    if (Directory.GetDirectories(dir).Length + Directory.GetFiles(dir).Length > 0)
                    {
                        children.Add(new TreeNode(""));
                    }
                    TreeNode node = new TreeNode(dir, children.ToArray());
                    node.Text = dir.Substring(dir.LastIndexOf('\\') + 1);
                    node.Name = dir;
                    e.Node.Nodes.Add(node);
                }
                catch (UnauthorizedAccessException) { }
            }

            //display files
            List<TreeNode> files = new();
            foreach (string file in Directory.GetFiles(path))
            {
                string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                files.Add(new TreeNode(fileName));
            }
            if (files.Count >= MIN_FILE_COUNT_TO_GROUP)
                e.Node.Nodes.Add(new TreeNode(filesNodeName, files.ToArray()));
            else
                files.ForEach(f => e.Node.Nodes.Add(f));
        }

        public void ClearTreeView()
        {
            treeView.Nodes.Clear();
        }

        public void PrintTreeView(string dir)
        {
            treeView.Nodes.Clear();
            if (!Directory.Exists(dir))
                return;

            List<TreeNode> children = new();
            if (Directory.GetDirectories(dir).Length > 0)
            {
                children.Add(new TreeNode(""));
            }
            TreeNode node = new TreeNode(dir, children.ToArray());
            if (dir.Last() == '\\')
                dir = dir.Substring(0, dir.Length - 1);
            node.Text = dir.Substring(dir.LastIndexOf('\\') + 1);
            node.Name = dir;
            treeView.Nodes.Add(node);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
            else
                backgroundWorker.RunWorkerAsync(e.Node!.Name);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (e.Argument is string path)
            {
                Invoke(new Action(() =>
                {
                    detailsValueListBox.Items.Clear();
                    dirIterationProgressBar.Value = 0;
                    dirIterationProgressBar.Visible = true;
                    cancelToolStripMenuItem.Enabled = true;
                }));
                DirectoryInfo directoryInfo = new(path);


                Task<(int files, int subDirs, long size)> task = Task.Run(() =>
                {
                    fileTypes.Clear();
                    return IterateDir(path, 1);
                });

                task.Wait();

                int files, subDirs;
                long size;
                if (backgroundWorker.CancellationPending)
                {
                    Invoke(new Action(() =>
                    {
                        dirIterationProgressBar.Visible = false;
                        cancelToolStripMenuItem.Enabled = false;
                    }));
                    return;
                }
                else
                    (files, subDirs, size) = task.Result;

                //print details
                Invoke(new Action(() =>
                {
                    detailsValueListBox.Items.Add(path); // full path
                    detailsValueListBox.Items.Add(SelectForm.BetterSizeDisplay(size));
                    detailsValueListBox.Items.Add(files + subDirs); // items
                    detailsValueListBox.Items.Add(files);
                    detailsValueListBox.Items.Add(subDirs);
                    detailsValueListBox.Items.Add(directoryInfo.LastWriteTime);
                    dirIterationProgressBar.Visible = false;
                    cancelToolStripMenuItem.Enabled = false;
                    chartsControl.FileTypes = fileTypes;
                    chartsControl.Draw();
                }));
            }
        }

        private (int files, int subDirs, long size) IterateDir(string path, double coef)
        {
            int files = 0;
            int subDirs = 0;
            long size = 0;
            foreach (string file in Directory.GetFiles(path))
            {
                if (backgroundWorker.CancellationPending)
                    break;

                files++;
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;

                //add to dictionary
                string extension = fileInfo.Extension;
                if (fileTypes.ContainsKey(extension))
                    fileTypes[extension] = (fileTypes[extension].quantity + 1, fileTypes[extension].size + fileInfo.Length);
                else
                    fileTypes.Add(extension, (1, fileInfo.Length));
            }
            int directSubDirs = Directory.GetDirectories(path).Length;
            foreach (string dir in Directory.GetDirectories(path))
            {
                if (backgroundWorker.CancellationPending)
                    break;

                subDirs++;
                try
                {
                    var subDirResult = IterateDir(dir, coef / directSubDirs);
                    files += subDirResult.files;
                    subDirs += subDirResult.subDirs;
                    size += subDirResult.size;
                }
                catch (UnauthorizedAccessException) { }
            }

            int addedBySubdirs;
            if (subDirs == 0)
                addedBySubdirs = 0;
            else
                addedBySubdirs = (int)(coef / directSubDirs * PROGRESS_BAR_MAX) * directSubDirs;

            int toAdd = (int)(coef * PROGRESS_BAR_MAX);
            Invoke(new Action(() =>
            {
                dirIterationProgressBar.Value += toAdd - addedBySubdirs;
            }));
            return (files, subDirs, size);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }
    }
}