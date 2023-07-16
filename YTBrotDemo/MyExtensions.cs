using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTBrotDemo
{
    internal static class MyExtensions
    {
        public static void SafeSet(this NumericUpDown nud, decimal value)
        {
            nud.Value = value.Clamp(nud.Minimum, nud.Maximum);
        }

        public static decimal Clamp(this decimal value, decimal min, decimal max)
        {
            return Math.Min(Math.Max(min, value), max);
        }

        public static void SafeCancel(this CancellationTokenSource cts)
        {
            try { cts.Cancel(); } catch (ObjectDisposedException) { }
        }

        public static void SetBackgroundBitmap(this Control control, Bitmap? bm)
        {
            using (control.BackgroundImage)
            {
                control.BackgroundImage = bm;
            }
        }
        public static void SetForegroundBitmap(this PictureBox control, Bitmap? bm)
        {
            using (control.Image)
            {
                control.Image = bm;
            }
        }



    }
}
