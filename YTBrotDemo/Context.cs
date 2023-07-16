using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTBrotDemo
{
    internal class Context
    {
        // FIELDS
        private double palScale, offsetA, offsetB, mag, hwidth, hheight;
        private int width, height, maxIt;
        private readonly Color[] palette;
        private readonly Color innerColor;

        // PROPERTIES
        public int Width => width;
        public int Height => height;
        public int HalfWidth => (int)hwidth;
        public int HalfHeight => (int)hheight;
        public int MaxIt => maxIt;

        // CONSTRUCTORS
        public Context(Color[] palette, Color inner)
        {
            this.palette = palette;
            this.innerColor = inner;
        }

        // PUBLIC METHODS
        public void SetValues(double pscale, double offa, double offb, double zoom, int w, int h, int max)
        {
            palScale = pscale;
            offsetA = offa;
            offsetB = offb;
            width = w;
            height = h;
            maxIt = max;
            hheight = h / 2.0;
            hwidth = w / 2.0;
            mag = (h / 3.0) * Math.Pow(2.0, zoom);
        }

        public Color GetColor(double val)
        {
            return val < 0 ? innerColor : palette[(int)(val * palScale) % palette.Length];
        }

        public (double a, double b) Transform(int x, int y)
        {
            return (
                ((x - hwidth) / mag) + offsetA,
                ((y - hheight) / mag) + offsetB
            );
        }

        public Bitmap NewBitmap()
        {
            return new(width, height);
        }
    }
}
