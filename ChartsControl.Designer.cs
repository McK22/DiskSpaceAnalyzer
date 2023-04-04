namespace DiskSpaceAnalyzer
{
    partial class ChartsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chartTypeLabel = new Label();
            chartTypeComboBox = new ComboBox();
            tableLayout = new TableLayoutPanel();
            quantityChartPictureBox = new PictureBox();
            sizeChartPictureBox = new PictureBox();
            tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quantityChartPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sizeChartPictureBox).BeginInit();
            SuspendLayout();
            // 
            // chartTypeLabel
            // 
            chartTypeLabel.AutoSize = true;
            chartTypeLabel.Location = new Point(0, 13);
            chartTypeLabel.Name = "chartTypeLabel";
            chartTypeLabel.Size = new Size(80, 20);
            chartTypeLabel.TabIndex = 0;
            chartTypeLabel.Text = "Chart type:";
            // 
            // chartTypeComboBox
            // 
            chartTypeComboBox.FormattingEnabled = true;
            chartTypeComboBox.Location = new Point(86, 13);
            chartTypeComboBox.Name = "chartTypeComboBox";
            chartTypeComboBox.Size = new Size(151, 28);
            chartTypeComboBox.TabIndex = 1;
            chartTypeComboBox.SelectionChangeCommitted += chartTypeComboBox_SelectionChangeCommitted;
            // 
            // tableLayout
            // 
            tableLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.Controls.Add(quantityChartPictureBox, 0, 0);
            tableLayout.Controls.Add(sizeChartPictureBox, 1, 0);
            tableLayout.Location = new Point(0, 47);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 1;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.Size = new Size(643, 488);
            tableLayout.TabIndex = 2;
            // 
            // quantityChartPictureBox
            // 
            quantityChartPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quantityChartPictureBox.Location = new Point(3, 3);
            quantityChartPictureBox.Name = "quantityChartPictureBox";
            quantityChartPictureBox.Size = new Size(315, 482);
            quantityChartPictureBox.TabIndex = 0;
            quantityChartPictureBox.TabStop = false;
            // 
            // sizeChartPictureBox
            // 
            sizeChartPictureBox.Dock = DockStyle.Fill;
            sizeChartPictureBox.Location = new Point(324, 3);
            sizeChartPictureBox.Name = "sizeChartPictureBox";
            sizeChartPictureBox.Size = new Size(316, 482);
            sizeChartPictureBox.TabIndex = 1;
            sizeChartPictureBox.TabStop = false;
            // 
            // ChartsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(tableLayout);
            Controls.Add(chartTypeComboBox);
            Controls.Add(chartTypeLabel);
            Name = "ChartsControl";
            Size = new Size(643, 535);
            Resize += ChartsControl_Resize;
            tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)quantityChartPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)sizeChartPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label chartTypeLabel;
        private ComboBox chartTypeComboBox;
        private TableLayoutPanel tableLayout;
        private PictureBox quantityChartPictureBox;
        private PictureBox sizeChartPictureBox;
    }
}
