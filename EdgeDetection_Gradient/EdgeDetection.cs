using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection_Gradient
{
    public class EdgeDetection
    {
        private int stride = 0;
        unsafe
        public Bitmap Detect(Bitmap source, ImageType imageType, OperatorType opType, float threshold)
        {
            source = (Bitmap)source.Clone();
            Bitmap result = new Bitmap(source.Width, source.Height, source.PixelFormat);

            BitmapData s = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
            BitmapData r = result.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
            stride = s.Stride;

            if (imageType == ImageType.Color)
                XamHoa(s);

            byte* p1 = (byte*)s.Scan0;
            byte* p2 = (byte*)r.Scan0;

            int[,] Hx, Hy;
            float gx = 0, gy = 0, G;
            Operator.GetOperator(opType, out Hx, out Hy);

            if (opType != OperatorType.Roberts)
            {
                for (int hang = 0; hang < s.Height; hang++)
                {
                    for (int cot = 0; cot < s.Width; cot++)
                    {
                        if (hang == 0 || hang == s.Height - 1 || cot == 0 || cot == s.Width - 1)
                        {
                            p2[Index(hang, cot)] = 0;
                        }
                        else
                        {
                            //Tính gradient
                            gx = p1[Index(hang - 1, cot - 1)] * Hx[0, 0] + p1[Index(hang, cot - 1)] * Hx[1, 0] + p1[Index(hang + 1, cot - 1)] * Hx[2, 0]
                                + p1[Index(hang - 1, cot + 1)] * Hx[0, 2] + p1[Index(hang, cot + 1)] * Hx[1, 2] + p1[Index(hang + 1, cot + 1)] * Hx[2, 2];
                            gy = p1[Index(hang - 1, cot - 1)] * Hy[0, 0] + p1[Index(hang - 1, cot)] * Hy[0, 1] + p1[Index(hang - 1, cot + 1)] * Hy[0, 2]
                               + p1[Index(hang + 1, cot - 1)] * Hy[2, 0] + p1[Index(hang + 1, cot)] * Hy[2, 1] + p1[Index(hang + 1, cot + 1)] * Hy[2, 2];

                            G = Math.Abs(gx) + Math.Abs(gy);

                            byte v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot)] = v;
                            p2[Index(hang, cot) + 1] = v;
                            p2[Index(hang, cot) + 2] = v;
                        }

                    }
                }
            }
            else
            {
                for (int hang = 0; hang < s.Height; hang++)
                {
                    for (int cot = 0; cot < s.Width; cot++)
                    {
                        if (hang == 0 || hang == s.Height - 1 || cot == 0 || cot == s.Width - 1)
                        {
                            p2[Index(hang, cot)] = 0;
                        }
                        else
                        {
                            //Tính gradient
                            gx = p1[Index(hang - 1, cot - 1)] * Hx[0, 0] + p1[Index(hang, cot)] * Hx[1, 1];

                            gy = p1[Index(hang - 1, cot)] * Hy[0, 1] + p1[Index(hang, cot - 1)] * Hy[1, 0];

                            G = Math.Abs(gx) + Math.Abs(gy);

                            byte v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot)] = v;
                            p2[Index(hang, cot) + 1] = v;
                            p2[Index(hang, cot) + 2] = v;
                        }

                    }
                }
            }

            source.UnlockBits(s);
            result.UnlockBits(r);
            return result;
        }
      
     

        private int Index(int hang, int cot)
        {
            return hang * stride + cot * 3;
        }



        unsafe
        void XamHoa(BitmapData bm)
        {
            byte* p = (byte*)bm.Scan0;
            int offset = bm.Stride - 3 * bm.Width;
            for (int hang = 0; hang < bm.Height; hang++)
            {
                for (int cot = 0; cot < bm.Width; cot++)
                {
                    byte v = (byte)((p[0] + p[1] + p[2]) / 3);
                    p[0] = v;
                    p += 3;
                }
                p += offset;
            }
        }

        unsafe
        public Bitmap LocNhieu(Bitmap source, FilterType type)
        {
           // source = (Bitmap)source.Clone();
            if (type == FilterType.Khong)
                return source;
            Bitmap result = new Bitmap(source.Width, source.Height, source.PixelFormat);

            BitmapData bm1 = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);
            BitmapData bm2 = result.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);

            byte* p1 = (byte*)bm1.Scan0;
            byte* p2 = (byte*)bm2.Scan0;
            stride = bm1.Stride;
            if (type == FilterType.Arithmetic_Mean_Filter)
            {
                //Trung bình
                int[,] H = Operator.GetFilterMatrix(FilterMatrix.H_16);
                int m = 0;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        m += H[i, j];

                for (int hang = 1; hang < bm1.Height - 1; hang++)
                {
                    for (int cot = 1; cot < bm1.Width - 1; cot++)
                    {
                        int tong = p1[Index(hang - 1, cot - 1)] * H[0, 0] + p1[Index(hang - 1, cot)] * H[0, 1] + p1[Index(hang - 1, cot + 1)] * H[0, 2]
                            + p1[Index(hang, cot - 1)] * H[1, 0] + p1[Index(hang, cot)] * H[1, 1] + p1[Index(hang, cot + 1)] * H[1, 2]
                            + p1[Index(hang + 1, cot - 1)] * H[2, 0] + p1[Index(hang + 1, cot)] * H[2, 1] + p1[Index(hang + 1, cot + 1)] * H[2, 2];

                        byte v = (byte)(tong / m);
                        p2[Index(hang, cot)] = v;
                        p2[Index(hang, cot) + 1] = v;
                        p2[Index(hang, cot) + 2] = v;
                    }
                }
            }
            else
            {
                //Trung vị
                for (int hang = 1; hang < bm1.Height - 1; hang++)
                {
                    for (int cot = 1; cot < bm1.Width - 1; cot++)
                    {
                        List<int> l = new List<int>();
                        l.Add(p1[Index(hang - 1, cot - 1)]);
                        l.Add(p1[Index(hang - 1, cot)]);
                        l.Add(p1[Index(hang - 1, cot + 1)]);

                        l.Add(p1[Index(hang, cot - 1)]);
                        l.Add(p1[Index(hang, cot)]);
                        l.Add(p1[Index(hang, cot + 1)]);

                        l.Add(p1[Index(hang + 1, cot - 1)]);
                        l.Add(p1[Index(hang + 1, cot)]);
                        l.Add(p1[Index(hang + 1, cot + 1)]);

                        l.Sort();

                        byte v = (byte) l[l.Count/2];

                        p2[Index(hang, cot)] = v;
                        p2[Index(hang, cot) + 1] = v;
                        p2[Index(hang, cot) + 2] = v;
                    }
                }
            }

            source.UnlockBits(bm1);
            result.UnlockBits(bm2);
            return result;
        }
    }
}
