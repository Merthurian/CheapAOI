using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Histograms
{
    public struct HistData
    {
        public double[] hist;
        public bool good;
        public string name;
        public Bitmap bitmap;
        public string filename;
    }

    public class Histogram
    {
        public enum Types
        {
            R,
            G,
            B,
            RGB,
            HS
        }

        public static double[] NormalizeData(IEnumerable<double> data, double min, double max)
        {
            double dataMax = data.Max();
            double dataMin = data.Min();
            double range = dataMax - dataMin;

            return data
                .Select(d => (d - dataMin) / range)
                .Select(n => (double)((1 - n) * min + n * max))
                .ToArray();
        }

        public static double[] DoHistogram(Bitmap bitmap, int type)
        {
            double[] hist;
            int total = 0;

            switch (type)
            {
                #region R
                case (int)Types.R:

                    hist = new double[32];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).R;

                            hist[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < hist.Length; i++)
                    {
                        hist[i] = hist[i] / total;
                    }

                    return NormalizeData(hist, 0, 1);
                #endregion

                #region G
                case (int)Types.G:
                    hist = new double[32];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).G;

                            hist[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < hist.Length; i++)
                    {
                        hist[i] = hist[i] / total;
                    }

                    return NormalizeData(hist, 0, 1);
                #endregion

                #region B
                case (int)Types.B:
                    hist = new double[32];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).B;

                            hist[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < hist.Length; i++)
                    {
                        hist[i] = hist[i] / total;
                    }

                    return NormalizeData(hist, 0, 1);
                #endregion

                #region RGB
                case (int)Types.RGB:
                    hist = new double[96];

                    double[] histR = DoHistogram(bitmap, (int)Types.R);
                    double[] histG = DoHistogram(bitmap, (int)Types.B);
                    double[] histB = DoHistogram(bitmap, (int)Types.G);

                    for (int i = 0; i < 32; i++)
                    {
                        hist[i] = histR[i];

                        hist[i + 32] = histG[i];

                        hist[i + 64] = histB[i];
                    }

                    return hist;
                #endregion

                #region HSV
                case (int)Types.HS:

                    hist = new double[37];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).R;

                            hist[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < hist.Length; i++)
                    {
                        hist[i] = hist[i] / total;
                    }

                    return NormalizeData(hist, 0, 1);
                #endregion
                    
                default:
                    return new double[] { 0 };
            }
        }
    }
}
