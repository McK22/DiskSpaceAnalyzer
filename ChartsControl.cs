using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskSpaceAnalyzer
{
    public partial class ChartsControl : UserControl
    {
        private const int BAR_CHART_STEPS = 10;
        private const int MAX_ELEMENTS_COUNT = 10;

        private readonly string barChartString = "Bar chart";
        private readonly string logBarChartString = "Log bar chart";
        private readonly string pieChartString = "Pie chart";

        private Bitmap? quantityChartBitmap;
        private Bitmap? sizeChartBitmap;

        private Dictionary<string, (int quantity, long size)>? fileTypes = null;

        public Dictionary<string, (int quantity, long size)>? FileTypes { set => fileTypes = value; }

        public ChartsControl()
        {
            InitializeComponent();
            InitComboBox();
            InitBitmaps();

        }

        private void InitComboBox()
        {
            chartTypeComboBox.Items.Add(barChartString);
            chartTypeComboBox.Items.Add(logBarChartString);
            chartTypeComboBox.Items.Add(pieChartString);
        }

        private void InitBitmaps()
        {
            quantityChartBitmap = new Bitmap(quantityChartPictureBox.Width, quantityChartPictureBox.Height);
            quantityChartPictureBox.Image = quantityChartBitmap;

            sizeChartBitmap = new Bitmap(sizeChartPictureBox.Width, sizeChartPictureBox.Height);
            sizeChartPictureBox.Image = sizeChartBitmap;
        }

        public void SetFileTypesDictionary(Dictionary<string, (int quantity, long size)> fileTypes)
        {
            this.fileTypes = fileTypes;
        }

        public void Draw()
        {
            if (fileTypes is null || fileTypes.Count == 0 || chartTypeComboBox.SelectedItem is null)
                return;

            var corrected = CorrectDictionaryElements(fileTypes);

            List<(string key, long value)> quantities = new();
            List<(string key, long value)> sizes = new();
            foreach (var element in corrected)
            {
                quantities.Add((element.key, element.quantity));
                sizes.Add((element.key, element.size));
            }

            if (chartTypeComboBox.SelectedItem.ToString() == barChartString)
            {
                DrawBarChart(quantityChartBitmap!, quantities);
                DrawBarChart(sizeChartBitmap!, sizes);
            }
            else if (chartTypeComboBox.SelectedItem.ToString() == logBarChartString)
            {
                DrawBarChart(quantityChartBitmap!, quantities, true);
                DrawBarChart(sizeChartBitmap!, sizes, true);
            }
            else
            {
                DrawPieChart(quantityChartBitmap!, quantities);
                DrawPieChart(sizeChartBitmap!, sizes);
            }

            quantityChartPictureBox!.Refresh();
            sizeChartPictureBox!.Refresh();
        }

        private List<(string key, int quantity, long size)> CorrectDictionaryElements(Dictionary<string, (int quantity, long size)> fileTypes)
        {
            List<(string key, int quantity, long size)> sorted = new();
            foreach (var element in fileTypes)
                sorted.Add((element.Key, element.Value.quantity, element.Value.size));

            sorted.Sort((e1, e2) => e1.quantity == e2.quantity ? 0 : e1.quantity < e2.quantity ? 1 : -1);

            List<(string key, int quantity, long size)> result = new();
            if (fileTypes.Count <= MAX_ELEMENTS_COUNT)
            {
                foreach (var element in fileTypes)
                    result.Add((element.Key, element.Value.quantity, element.Value.size));
                return result;
            }

            for (int i = 0; i < MAX_ELEMENTS_COUNT - 1; i++)
            {
                var element = sorted.ElementAt(i);
                result.Add((element.key, element.quantity, element.size));
            }

            (int quantity, long size) others = (0, 0);
            for (int i = MAX_ELEMENTS_COUNT - 1; i < fileTypes.Count; i++)
            {
                var element = sorted.ElementAt(i);
                others.quantity += element.quantity;
                others.size += element.size;
            }

            result.Add(("Others", others.quantity, others.size));
            return result;
        }

        private void DrawPieChart(Bitmap bitmap, List<(string key, long value)> elements)
        {
            const int chartRightMargin = 80;
            const int fullAngle = 360;
            const int legendLeftMargin = 10;
            const int legendRectWidth = 20;
            const int legendRectHeight = 15;

            int radius = bitmap.Width - chartRightMargin;
            Rectangle chartRectangle = new Rectangle(0, 0, radius, radius);

            using Graphics graphics = Graphics.FromImage(bitmap);
            SolidBrush brush = new(Color.LightBlue);
            Pen pen = new(Color.Black, 1);
            Font font = new("Arial", 8);

            graphics.Clear(Color.White);

            long total = elements.Sum(e => e.value);
            int lastAngle = 0;
            int angleStep = fullAngle / elements.Count;
            int i = 0;
            int legendY = 0;
            foreach (var element in elements)
            {
                brush.Color = ColorFromHSV(i++ * angleStep, 1, 1);

                //draw pie
                int sweep = (int)(Math.Ceiling((double)element.value / total * fullAngle));
                graphics.FillPie(brush, chartRectangle, lastAngle, sweep);
                graphics.DrawPie(pen, chartRectangle, lastAngle, sweep);
                lastAngle += sweep;

                //draw legend node
                graphics.FillRectangle(brush, chartRectangle.Right + legendLeftMargin, legendY, legendRectWidth, legendRectHeight);
                graphics.DrawRectangle(pen, chartRectangle.Right + legendLeftMargin, legendY, legendRectWidth, legendRectHeight);
                graphics.DrawString(element.key, font, Brushes.Black, chartRectangle.Right + legendLeftMargin + legendRectWidth + 2, legendY);
                legendY += 2 * legendRectHeight;
            }
        }

        private void DrawBarChart(Bitmap bitmap, List<(string key, long value)> elements, bool logarithmic = false)
        {
            const int leftMargin = 70;
            const int bottomMargin = 50;
            const int highestLineY = 10;

            Rectangle backgroundRect = new Rectangle(leftMargin, 0, bitmap.Width - leftMargin - 20, bitmap.Height - bottomMargin - 20);

            SolidBrush brush = new(Color.LightGray);
            Pen pen = new(Color.Black, 1);
            Font font = new("Arial", 8);
            using Graphics graphics = Graphics.FromImage(bitmap);

            //draw background
            graphics.Clear(Color.White);
            graphics.FillRectangle(brush, backgroundRect);

            //draw horizontal lines
            long[] scale;
            if (logarithmic)
                scale = GetLogarithmicScale(elements.Max(e => e.value));
            else
                scale = GetLinearScale(elements.Max(e => e.value));
            int highestLineHeight = backgroundRect.Height - highestLineY;
            foreach (long value in scale)
            {
                int height;
                if (!logarithmic)
                    height = (int)((double)value / scale.Last() * highestLineHeight);
                else if (value == 0)
                    height = 0;
                else
                    height = (int)(Math.Log(value, scale.Last()) * highestLineHeight);
                graphics.DrawLine(pen, backgroundRect.Left, backgroundRect.Bottom - height, backgroundRect.Right, backgroundRect.Bottom - height);

                string text;
                if (bitmap == sizeChartBitmap)
                    text = SelectForm.BetterSizeDisplay(value);
                else
                    text = value.ToString();
                int labelLeft = backgroundRect.Left - (int)graphics.MeasureString(text, font).Width;
                int labelTop = backgroundRect.Bottom - height - font.Height / 2;
                graphics.DrawString(text, font, Brushes.Black, labelLeft, labelTop);
            }

            //draw bars
            int barWidth = backgroundRect.Width / (2 * elements.Count);
            int x = backgroundRect.Left + barWidth / 2;
            int i = 0;
            const int fullAngle = 360;
            int angleStep = fullAngle / elements.Count;
            foreach ((string key, long value) in elements)
            {
                int height;
                if (logarithmic)
                    height = (int)(Math.Log(value, scale.Last()) * highestLineHeight);
                else
                    height = (int)((double)value / scale.Last() * highestLineHeight);

                brush.Color = ColorFromHSV(i++ * angleStep, 1, 1);

                graphics.FillRectangle(brush, x, backgroundRect.Bottom - height, barWidth, height);
                graphics.DrawRectangle(pen, x, backgroundRect.Bottom - height, barWidth, height);

                int labelLeft = x + barWidth / 2 - (int)(graphics.MeasureString(key, font).Width / 2);
                int labelTop = backgroundRect.Bottom;
                graphics.DrawString(key, font, Brushes.Black, labelLeft, labelTop);

                x += barWidth * 2;
            }
        }

        private long GetMaxLine(long max)
        {
            int digits = CountDigits(max);
            long maxLine = (long)Math.Pow(10, digits - 1) * ((long)(max / Math.Pow(10, digits - 1)) + 1);
            if (digits == 1)
                maxLine = 10;
            return maxLine;
        }

        private long[] GetLogarithmicScale(long max)
        {
            long maxLine = GetMaxLine(max);
            long[] scale = new long[BAR_CHART_STEPS + 1];
            for (int i = 1; i < scale.Length; i++)
                scale[i] = (long)Math.Pow(maxLine, (double)i / 10);
            scale[0] = 0;
            return scale;
        }

        private long[] GetLinearScale(long max)
        {
            long maxLine = GetMaxLine(max);
            long step = maxLine / BAR_CHART_STEPS;
            long[] scale = new long[BAR_CHART_STEPS + 1];
            for (int i = 0; i < scale.Length; i++)
                scale[i] = step * i;
            return scale;
        }

        private int CountDigits(long n)
        {
            int result = 0;
            while (n > 0)
            {
                result++;
                n /= 10;
            }
            return result;
        }

        private void ChartsControl_Resize(object sender, EventArgs e)
        {
            InitBitmaps();
            Draw();
        }

        //https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void chartTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
