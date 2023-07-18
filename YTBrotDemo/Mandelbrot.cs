using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YTBrotDemo
{
    internal static class Mandelbrot
    {
        private const decimal TWO = 2, FOUR = 4;

        private static double Iterate((double a, double b) c, int maxIt)
        {
            (double a, double b) z = (0, 0), zs = (0, 0);
            double oldm = 0, m;
            for (int it = 0; it < maxIt; it++)
            {
                z.b = 2.0 * z.a * z.b;
                z.a = zs.a - zs.b;
                z.a += c.a;
                z.b += c.b;
                zs.a = z.a * z.a;
                zs.b = z.b * z.b;
                m = zs.a + zs.b;
                if (m >= 4.0)
                    return it + ((4.0 - oldm) / (m - oldm));
                oldm = m;
            }
            return -1;
        }

        private static double IterateHP((decimal a, decimal b) c, int maxIt)
        {
            (decimal a, decimal b) z = (0, 0), zs = (0, 0);
            decimal oldm = 0, m;
            for (int it = 0; it < maxIt; it++)
            {
                z.b = TWO * z.a * z.b;
                z.a = zs.a - zs.b;
                z.a += c.a;
                z.b += c.b;
                zs.a = z.a * z.a;
                zs.b = z.b * z.b;
                m = zs.a + zs.b;
                if (m >= FOUR)
                    return (double)(it + ((FOUR - oldm) / (m - oldm)));
                oldm = m;
            }
            return -1;
        }

        public static async Task<Bitmap> Render(Context con, int threads, CancellationToken token)
        {
            Func<int, int, int, double> iterator = con.HiPrecision ?
                (int x, int y, int max) => IterateHP(con.TransformHP(x, y), max) :
                (int x, int y, int max) => Iterate(con.Transform(x, y), max);
            Bitmap bm = con.NewBitmap();
            using Graphics g = Graphics.FromImage(bm);
            var tasks = Enumerable
                .Range(0, threads)
                .Select(tn => Task<Bitmap>.Run(() => Partial(threads, tn, con, iterator, token), token))
                .ToArray();
            foreach(var task in tasks)
            {
                using (task)
                {
                    using Bitmap pbm = await task;
                    g.DrawImage(pbm, Point.Empty);
                }
            }           
            return bm;
        }

        private static Bitmap Partial(int threads, int tn, Context con, Func<int, int, int, double> Iterator, CancellationToken token)
        {
            Bitmap bm = con.NewBitmap();
            for (int y = tn; y < con.Height && !token.IsCancellationRequested; y += threads)
            {
                for (int x = 0; x < con.Width; x++)
                {
                    double it = Iterator(x, y, con.MaxIt);
                    bm.SetPixel(x, y, con.GetColor(it));
                }
            }
            return bm;
        }

    }
}
