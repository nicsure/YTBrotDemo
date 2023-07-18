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
        private decimal offsetA, offsetB, magHP;
        private double palScale, mag, hwidth, hheight, offsetAD, offsetBD, zoom;
        private int width, height, maxIt;
        private readonly Color[] palette;
        private readonly Color innerColor;
        

        // PROPERTIES
        public int Width => width;
        public int Height => height;
        public int HalfWidth => (int)hwidth;
        public int HalfHeight => (int)hheight;
        public int MaxIt => maxIt;
        public bool HiPrecision => zoom > 45;

        // CONSTRUCTORS
        public Context(Color[] palette, Color inner)
        {
            this.palette = palette;
            this.innerColor = inner;
        }

        // PUBLIC METHODS
        public void SetValues(double pscale, decimal offa, decimal offb, double zoom, int w, int h, int max)
        {
            palScale = pscale;
            offsetA = offa;
            offsetB = offb;
            offsetAD = (double)offa;
            offsetBD = (double)offb;
            this.zoom = zoom;
            width = w;
            height = h;
            maxIt = max;
            hheight = h / 2.0;
            hwidth = w / 2.0;
            mag = (h / 3.0) * Math.Pow(2.0, zoom);
            magHP = Convert.ToDecimal(mag);
        }

        public Color GetColor(double val)
        {
            return val < 0 ? innerColor : palette[(int)(val * palScale) % palette.Length];
        }

        public (double a, double b) Transform(int x, int y)
        {
            return (
                ((x - hwidth) / mag) + offsetAD,
                ((y - hheight) / mag) + offsetBD
            );
        }

        public (decimal a, decimal b) TransformHP(int x, int y)
        {
            return (
                ((decimal)(x - hwidth) / magHP) + offsetA,
                ((decimal)(y - hheight) / magHP) + offsetB
            );
        }

        public Bitmap NewBitmap()
        {
            return new(width, height);
        }
    }
}
