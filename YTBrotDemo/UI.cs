using System.Drawing;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;

namespace YTBrotDemo
{
    public partial class UI : Form
    {
        private readonly Context context = new(CreatePalette(), Color.Black);
        private Task? previewTask = null;
        private CancellationTokenSource? tokenSource = null;
        private readonly Brush zoomGuideRectangleBrush = new SolidBrush(Color.FromArgb(50, 255, 255, 255));
        private readonly Pen zoomGuideBlackBorderPen = new(Color.Black);
        private readonly Pen zoomGuideWhiteBorderPen = new(Color.White);
        private double zoomAdjust = 1;

        private int MaxIterations
        {
            get => (int)MaxIterationsControl.Value;
            set => MaxIterationsControl.SafeSet(value);
        }
        private int Threads
        {
            get => (int)ThreadsControl.Value;
            set => ThreadsControl.SafeSet(value);
        }
        private double ViewOffsetA
        {
            get => (double)ViewOffsetAControl.Value;
            set => ViewOffsetAControl.SafeSet((decimal)value);
        }
        private double ViewOffsetB
        {
            get => (double)ViewOffsetBControl.Value;
            set => ViewOffsetBControl.SafeSet((decimal)value);
        }
        private double PaletteScale
        {
            get => (double)PaletteScaleControl.Value;
            set => PaletteScaleControl.SafeSet((decimal)value);
        }
        private double Zoom
        {
            get => (double)ZoomControl.Value;
            set => ZoomControl.SafeSet((decimal)value);
        }

        public UI()
        {
            InitializeComponent();
            ShowPreview();
        }

        private static Color[] CreatePalette()
        {
            // black -> yellow -> red -> magenta -> blue -> cyan -> black
            //
            //  black    0,  0,  0  ->  254,254,  0   yellow    r=i, g=i, b=0
            // yellow  255,255,  0  ->  255,  1,  0   red       r=m, g=d, b=0
            //    red  255,  0,  0  ->  255,  0,254   magenta   r=m, g=0, b=i
            //magenta  255,  0,255  ->    1,  0,255   blue      r=d, g=0, b=m
            //   blue    0,  0,255  ->    0,254,266   cyan      r=0, g=i, b=m
            //   cyan    0,255,255  ->    0,  1,  1   black     r=0, g=d, b=d            

            var incr = Enumerable.Range(0, 255);
            var decr = Enumerable.Range(1, 255).Reverse();
            var all0 = Enumerable.Repeat(0, 255);
            var all255 = Enumerable.Repeat(255, 255);
            var redRange = incr.Concat(all255).Concat(all255).Concat(decr).Concat(all0).Concat(all0);
            var greenRange = incr.Concat(decr).Concat(all0).Concat(all0).Concat(incr).Concat(decr);
            var blueRange = all0.Concat(all0).Concat(incr).Concat(all255).Concat(all255).Concat(decr);
            return
                redRange
                .Zip(greenRange, (r, g) => (r, g))
                .Zip(blueRange, (rg, b) => (rg.r, rg.g, b))
                .Select(rgb => Color.FromArgb(rgb.r, rgb.g, rgb.b))
                .ToArray();
        }

        private void Busy(bool busy)
        {
            PreviewControl.Enabled = !busy;
            RenderButton.Enabled = !busy;
            AbortButton.Enabled = busy;
        }

        private async Task RenderSet()
        {
            Busy(true);
            SetContext();
            using (tokenSource = new())
            {
                using var renderTask = Mandelbrot.Render(context, Threads, tokenSource.Token);
                PreviewControl.SetBackgroundBitmap(await renderTask);
                Busy(false);
            }
        }

        private void ShowPreview()
        {
            using (previewTask)
            {
                previewTask = RenderSet();
            }
        }

        private void ClearZoomGuide()
        {
            PreviewControl.SetForegroundBitmap(null);
            zoomAdjust = 1;
        }

        private void SetContext()
        {
            context.SetValues(PaletteScale, ViewOffsetA, ViewOffsetB, Zoom, PreviewControl.Width, PreviewControl.Height, MaxIterations);
        }

        private void RenderButton_Click(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            tokenSource?.SafeCancel();
        }

        private void PreviewControl_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                default: return;
                case MouseButtons.Left:
                    Zoom += zoomAdjust;
                    break;
                case MouseButtons.Right:
                    Zoom--;
                    break;
            }
            var (a, b) = context.Transform(e.X, e.Y);
            ViewOffsetA = a;
            ViewOffsetB = b;
            ClearZoomGuide();
            ShowPreview();
        }

        private void PreviewControl_MouseLeave(object sender, EventArgs e)
        {
            ClearZoomGuide();
        }

        private void DrawZoomGuide(int x, int y)
        {
            Bitmap bm = context.NewBitmap();
            using Graphics g = Graphics.FromImage(bm);
            double zoomAdjustFactor = Math.Pow(2.0, zoomAdjust);
            int zoomWidth = (int)(context.Width / zoomAdjustFactor);
            int zoomHeight = (int)(context.Height / zoomAdjustFactor);
            int topLeftX = x - zoomWidth / 2;
            int topLeftY = y - zoomHeight / 2;
            g.FillRectangle(zoomGuideRectangleBrush, topLeftX, topLeftY, zoomWidth, zoomHeight);
            g.DrawRectangle(zoomGuideBlackBorderPen, topLeftX, topLeftY, zoomWidth, zoomHeight);
            g.DrawRectangle(zoomGuideWhiteBorderPen, topLeftX + 1, topLeftY + 1, zoomWidth - 2, zoomHeight - 2);
            PreviewControl.SetForegroundBitmap(bm);
        }

        private void PreviewControl_MouseMove(object sender, MouseEventArgs e)
        {
            DrawZoomGuide(e.X, e.Y);
        }

        private void PreviewControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            if(PreviewControl.Image != null)
            {
                zoomAdjust += e.Delta / (SystemInformation.MouseWheelScrollDelta * 10.0);
                DrawZoomGuide(e.X, e.Y);
            }
        }

        private void PreviewControl_SizeChanged(object sender, EventArgs e)
        {
            SetContext();
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            PreviewControl.MouseWheel += PreviewControl_MouseWheel;
        }
    }
}