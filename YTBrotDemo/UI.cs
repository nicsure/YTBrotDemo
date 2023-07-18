using System.Drawing;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace YTBrotDemo
{
    public partial class UI : Form
    {
        // FIELDS
        private readonly Context context = new(CreatePalette(), Color.Black);
        private Task? previewTask = null;
        private CancellationTokenSource? tokenSource = null;
        private double zoomAdjust = 1;
        private readonly ZoomGuide zoomGuide = new();

        // STATIC FIELDS
        private static readonly double zoomStepFactor = SystemInformation.MouseWheelScrollDelta * 10.0;

        // PROPERTIES
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
        private decimal ViewOffsetA
        {
            get => ViewOffsetAControl.Value;
            set => ViewOffsetAControl.SafeSet(value);
        }
        private decimal ViewOffsetB
        {
            get => ViewOffsetBControl.Value;
            set => ViewOffsetBControl.SafeSet(value);
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

        // CONSTRUCTORS
        public UI()
        {
            InitializeComponent();
            ShowPreview();
        }

        // STATIC METHODS
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

        // UI MANIPULATION
        private void Busy(bool busy)
        {
            PreviewControl.Enabled = !busy;
            RenderButton.Enabled = !busy;
            AbortButton.Enabled = busy;
        }

        private void DrawZoomGuide(double delta, int x, int y)
        {
            zoomAdjust += delta;
            zoomGuide.Update(x, y, Math.Pow(2.0, zoomAdjust));
            zoomGuide.Visible = true;
        }

        private void ClearZoomGuide()
        {
            zoomGuide.Visible = false;
            zoomAdjust = 1;
        }

        // OPERATION
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

        private void SetContext()
        {
            context.SetValues(PaletteScale, ViewOffsetA, ViewOffsetB, Zoom, PreviewControl.Width, PreviewControl.Height, MaxIterations);
        }

        private void Magnify(double zoomDelta, int x, int y)
        {
            Zoom += zoomDelta;
            var (a, b) = context.TransformHP(x, y);
            ViewOffsetA = a;
            ViewOffsetB = b;
            ClearZoomGuide();
            ShowPreview();
        }

        // EVENTS (Buttons)
        private void RenderButton_Click(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            tokenSource?.SafeCancel();
        }

        // EVENTS (Preview Window)
        private void PreviewControl_MouseClick(object sender, MouseEventArgs e)
        {
            double zoomDelta;
            switch (e.Button)
            {
                default: return;
                case MouseButtons.Left:
                    zoomDelta = zoomAdjust;
                    break;
                case MouseButtons.Right:
                    zoomDelta = -1;
                    break;
            }
            Magnify(zoomDelta, e.X, e.Y);
        }

        private void PreviewControl_MouseLeave(object sender, EventArgs e)
        {
            ClearZoomGuide();
        }

        private void PreviewControl_MouseMove(object sender, MouseEventArgs e)
        {
            DrawZoomGuide(0, e.X, e.Y);
        }

        private void PreviewControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            DrawZoomGuide(e.Delta / zoomStepFactor, e.X, e.Y);
        }

        private void PreviewControl_SizeChanged(object sender, EventArgs e)
        {
            SetContext();
            PreviewControl.SetForegroundBitmap(context.NewBitmap());
        }

        //EVENTS (UI)
        private void UI_KeyDown(object sender, KeyEventArgs e)
        {
            if (zoomGuide.Visible)
            {
                e.Handled = true;
                double delta;
                switch (e.KeyCode)
                {
                    default: return;
                    case Keys.Up:
                        delta = 0.1;
                        break;
                    case Keys.Down:
                        delta = -0.1;
                        break;
                    case Keys.Enter:
                        Magnify(zoomAdjust, zoomGuide.Left, zoomGuide.Top);
                        return;
                }
                DrawZoomGuide(delta, zoomGuide.Left, zoomGuide.Top);
            }
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            PreviewPanel.Controls.Add(zoomGuide);
            zoomGuide.Visible = false;
            PreviewControl.MouseWheel += PreviewControl_MouseWheel;
        }


    }
}