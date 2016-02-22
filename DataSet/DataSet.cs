using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DataSet
{
    public struct HistData
    {
        public double[] hist;
        public bool good;
        public string name;
        public Bitmap bitmap;
        public string filename;
    }

    public class ImageData
    {
        public enum Types
        {
            R,
            G,
            B,
            RGB,
            HS,
            SI//Sub Image
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

        public static double[] GetData(Bitmap bitmap, int type)
        {
            double[] data;
            int total = 0;

            switch (type)
            {
                #region R
                case (int)Types.R:

                    data = new double[32];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).R;

                            data[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = data[i] / total;
                    }

                    return NormalizeData(data, 0, 1);
                #endregion

                #region G
                case (int)Types.G:
                    data = new double[32];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).G;

                            data[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = data[i] / total;
                    }

                    return NormalizeData(data, 0, 1);
                #endregion

                #region B
                case (int)Types.B:
                    data = new double[32];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).B;

                            data[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = data[i] / total;
                    }

                    return NormalizeData(data, 0, 1);
                #endregion

                #region RGB
                case (int)Types.RGB:
                    data = new double[96];

                    double[] histR = GetData(bitmap, (int)Types.R);
                    double[] histG = GetData(bitmap, (int)Types.B);
                    double[] histB = GetData(bitmap, (int)Types.G);

                    for (int i = 0; i < 32; i++)
                    {
                        data[i] = histR[i];

                        data[i + 32] = histG[i];

                        data[i + 64] = histB[i];
                    }

                    return data;
                #endregion

                #region HSV
                case (int)Types.HS:

                    data = new double[37];

                    total = 0;

                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            var r = Color.FromArgb(pixel.ToArgb()).R;

                            data[r / 8] += 1;
                            total += 1;
                        }
                    }

                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = data[i] / total;
                    }

                    return NormalizeData(data, 0, 1);
                #endregion

                default:
                    return new double[] { 0 };
            }
        }
    }
}
