using System.IO.Compression;

namespace YTBrotDemo
{
    public partial class UI : Form
    {
        private readonly Context context = new(CreatePalette(), Color.Black);
        private Task? previewTask = null;
        private CancellationTokenSource? cts = null;

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

        private void SetContext()
        {
            context.SetValues(PaletteScale, ViewOffsetA, ViewOffsetB, Zoom, PreviewControl.Width, PreviewControl.Height, MaxIterations);
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
            using (cts = new())
            {
                PreviewControl.BackgroundImage = await Mandelbrot.Render(context, Threads, cts.Token);
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

        private void RenderButton_Click(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            cts?.SafeCancel();
        }

        private void PreviewControl_MouseClick(object sender, MouseEventArgs e)
        {
            SetContext();
            switch(e.Button) 
            {
                default:
                    return;
                case MouseButtons.Left:
                    Zoom++;
                    break;
                case MouseButtons.Right:
                    Zoom--;
                    break;
            }
            var (a, b) = context.Transform(e.X, e.Y);
            ViewOffsetA = a;
            ViewOffsetB = b;
            ShowPreview();
        }
    }
}