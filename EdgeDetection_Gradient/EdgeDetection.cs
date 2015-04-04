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
        private Bitmap original;

        public EdgeDetection(Bitmap original)
        {
            this.original = original;
        }

        unsafe
        private Bitmap AnhXam(Bitmap source, OperatorType opType, float threshold)
        {

            source = (Bitmap)source.Clone();
            Bitmap result = new Bitmap(source.Width, source.Height, source.PixelFormat);

            BitmapData s = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
            BitmapData r = result.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);

            stride = s.Stride;

            byte* p1 = (byte*)s.Scan0;
            byte* p2 = (byte*)r.Scan0;

            int[,] Hx, Hy;
            float gx = 0, gy = 0, G;
            Operator.GetOperator(opType, out Hx, out Hy);

            if (opType == OperatorType.Sobel || opType == OperatorType.Prewitt)
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
            else if (opType == OperatorType.Roberts)
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
            else if (opType == OperatorType.LaBan_Kirsh)
            {
                List<int[,]> H = Operator.GetOperatorKrish();
                for (int hang = 1; hang < s.Height - 1; hang++)
                {
                    for (int cot = 1; cot < s.Width - 1; cot++)
                    {
                        G = 0; long t = 0;
                        for (int i = 0; i < H.Count; i++)
                        {
                            t = H[i][0, 0] * p1[Index(hang - 1, cot - 1)] + H[i][0, 1] * p1[Index(hang - 1, cot)] + H[i][0, 2] * p1[Index(hang - 1, cot + 1)]
                                + H[i][1, 0] * p1[Index(hang, cot - 1)] + H[i][1, 1] * p1[Index(hang, cot)] + H[i][1, 2] * p1[Index(hang, cot + 1)]
                                + H[i][2, 0] * p1[Index(hang + 1, cot - 1)] + H[i][2, 1] * p1[Index(hang + 1, cot)] + H[i][2, 2] * p1[Index(hang + 1, cot + 1)];

                            if (Math.Abs(t) > G)
                                G = Math.Abs(t);
                        }
                        byte v = (byte)(G >= threshold ? 255 : 0);

                        p2[Index(hang, cot)] = v;
                        p2[Index(hang, cot) + 1] = v;
                        p2[Index(hang, cot) + 2] = v;
                    }
                }

            }

            source.UnlockBits(s);
            result.UnlockBits(r);
            return result;
        }

        unsafe
     private Bitmap AnhMau(Bitmap source, OperatorType opType, float threshold)
        {

            source = (Bitmap)source.Clone();
            Bitmap result = new Bitmap(source.Width, source.Height, source.PixelFormat);

            BitmapData s = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
            BitmapData r = result.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);

            stride = s.Stride;

            //XamHoa(s);
            //source.UnlockBits(s);
            //result.UnlockBits(r);
            //return AnhXam(source, opType, threshold);

            byte* p1 = (byte*)s.Scan0;
            byte* p2 = (byte*)r.Scan0;

            int[,] Hx, Hy;
            float gx = 0, gy = 0, G;
            byte v = 0;
            Operator.GetOperator(opType, out Hx, out Hy);

            if (opType == OperatorType.Sobel || opType == OperatorType.Prewitt)
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
                            //BGR
                            //Tính gradient cua B
                            gx = p1[Index(hang - 1, cot - 1)] * Hx[0, 0] + p1[Index(hang, cot - 1)] * Hx[1, 0] + p1[Index(hang + 1, cot - 1)] * Hx[2, 0]
                                + p1[Index(hang - 1, cot + 1)] * Hx[0, 2] + p1[Index(hang, cot + 1)] * Hx[1, 2] + p1[Index(hang + 1, cot + 1)] * Hx[2, 2];
                            gy = p1[Index(hang - 1, cot - 1)] * Hy[0, 0] + p1[Index(hang - 1, cot)] * Hy[0, 1] + p1[Index(hang - 1, cot + 1)] * Hy[0, 2]
                               + p1[Index(hang + 1, cot - 1)] * Hy[2, 0] + p1[Index(hang + 1, cot)] * Hy[2, 1] + p1[Index(hang + 1, cot + 1)] * Hy[2, 2];
                            G = Math.Abs(gx) + Math.Abs(gy);
                            v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot)] = v;

                            //Tính gradient cua G
                            gx = p1[Index(hang - 1, cot - 1) + 1] * Hx[0, 0] + p1[Index(hang, cot - 1) + 1] * Hx[1, 0] + p1[Index(hang + 1, cot - 1) + 1] * Hx[2, 0]
                                + p1[Index(hang - 1, cot + 1) + 1] * Hx[0, 2] + p1[Index(hang, cot + 1) + 1] * Hx[1, 2] + p1[Index(hang + 1, cot + 1) + 1] * Hx[2, 2];
                            gy = p1[Index(hang - 1, cot - 1) + 1] * Hy[0, 0] + p1[Index(hang - 1, cot) + 1] * Hy[0, 1] + p1[Index(hang - 1, cot + 1) + 1] * Hy[0, 2]
                               + p1[Index(hang + 1, cot - 1) + 1] * Hy[2, 0] + p1[Index(hang + 1, cot) + 1] * Hy[2, 1] + p1[Index(hang + 1, cot + 1) + 1] * Hy[2, 2];
                            G = Math.Abs(gx) + Math.Abs(gy);
                            v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot) + 1] = v;


                            //Tính gradient cua R
                            gx = p1[Index(hang - 1, cot - 1) + 2] * Hx[0, 0] + p1[Index(hang, cot - 1) + 2] * Hx[1, 0] + p1[Index(hang + 1, cot - 1) + 2] * Hx[2, 0]
                                + p1[Index(hang - 1, cot + 1) + 2] * Hx[0, 2] + p1[Index(hang, cot + 1) + 2] * Hx[1, 2] + p1[Index(hang + 1, cot + 1) + 2] * Hx[2, 2];
                            gy = p1[Index(hang - 1, cot - 1) + 2] * Hy[0, 0] + p1[Index(hang - 1, cot) + 2] * Hy[0, 1] + p1[Index(hang - 1, cot + 1) + 2] * Hy[0, 2]
                               + p1[Index(hang + 1, cot - 1) + 2] * Hy[2, 0] + p1[Index(hang + 1, cot) + 2] * Hy[2, 1] + p1[Index(hang + 1, cot + 1) + 2] * Hy[2, 2];
                            G = Math.Abs(gx) + Math.Abs(gy);
                            v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot) + 2] = v;
                        }

                    }
                }
            }
            else if (opType == OperatorType.Roberts)
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
                            //Tính gradient B
                            gx = p1[Index(hang - 1, cot - 1)] * Hx[0, 0] + p1[Index(hang, cot)] * Hx[1, 1];
                            gy = p1[Index(hang - 1, cot)] * Hy[0, 1] + p1[Index(hang, cot - 1)] * Hy[1, 0];
                            G = Math.Abs(gx) + Math.Abs(gy);
                            v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot)] = v;

                            //Tính gradient G
                            gx = p1[Index(hang - 1, cot - 1) + 1] * Hx[0, 0] + p1[Index(hang, cot) + 1] * Hx[1, 1];
                            gy = p1[Index(hang - 1, cot) + 1] * Hy[0, 1] + p1[Index(hang, cot - 1) + 1] * Hy[1, 0];
                            G = Math.Abs(gx) + Math.Abs(gy);
                            v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot) + 1] = v;


                            //Tính gradient R
                            gx = p1[Index(hang - 1, cot - 1) + 2] * Hx[0, 0] + p1[Index(hang, cot) + 2] * Hx[1, 1];
                            gy = p1[Index(hang - 1, cot) + 2] * Hy[0, 1] + p1[Index(hang, cot - 1) + 2] * Hy[1, 0];
                            G = Math.Abs(gx) + Math.Abs(gy);
                            v = (byte)(G >= threshold ? 255 : 0);
                            p2[Index(hang, cot) + 2] = v;
                        }

                    }
                }
            }
            else if (opType == OperatorType.LaBan_Kirsh)
            {
                List<int[,]> H = Operator.GetOperatorKrish();
                for (int hang = 1; hang < s.Height - 1; hang++)
                {
                    for (int cot = 1; cot < s.Width - 1; cot++)
                    {
                        //B
                        G = 0; long t = 0;
                        for (int i = 0; i < H.Count; i++)
                        {
                            t = H[i][0, 0] * p1[Index(hang - 1, cot - 1)] + H[i][0, 1] * p1[Index(hang - 1, cot)] + H[i][0, 2] * p1[Index(hang - 1, cot + 1)]
                                + H[i][1, 0] * p1[Index(hang, cot - 1)] + H[i][1, 1] * p1[Index(hang, cot)] + H[i][1, 2] * p1[Index(hang, cot + 1)]
                                + H[i][2, 0] * p1[Index(hang + 1, cot - 1)] + H[i][2, 1] * p1[Index(hang + 1, cot)] + H[i][2, 2] * p1[Index(hang + 1, cot + 1)];
                            if (Math.Abs(t) > G)
                                G = Math.Abs(t);
                        }
                        v = (byte)(G >= threshold ? 255 : 0);
                        p2[Index(hang, cot)] = v;

                        //G
                        G = 0; t = 0;
                        for (int i = 0; i < H.Count; i++)
                        {
                            t = H[i][0, 0] * p1[Index(hang - 1, cot - 1) + 1] + H[i][0, 1] * p1[Index(hang - 1, cot) + 1] + H[i][0, 2] * p1[Index(hang - 1, cot + 1) + 1]
                                + H[i][1, 0] * p1[Index(hang, cot - 1) + 1] + H[i][1, 1] * p1[Index(hang, cot) + 1] + H[i][1, 2] * p1[Index(hang, cot + 1) + 1]
                                + H[i][2, 0] * p1[Index(hang + 1, cot - 1) + 1] + H[i][2, 1] * p1[Index(hang + 1, cot) + 1] + H[i][2, 2] * p1[Index(hang + 1, cot + 1) + 1];
                            if (Math.Abs(t) > G)
                                G = Math.Abs(t);
                        }
                        v = (byte)(G >= threshold ? 255 : 0);
                        p2[Index(hang, cot) + 1] = v;

                        //R
                        G = 0; t = 0;
                        for (int i = 0; i < H.Count; i++)
                        {
                            t = H[i][0, 0] * p1[Index(hang - 1, cot - 1) + 2] + H[i][0, 1] * p1[Index(hang - 1, cot) + 2] + H[i][0, 2] * p1[Index(hang - 1, cot + 1) + 2]
                                + H[i][1, 0] * p1[Index(hang, cot - 1) + 2] + H[i][1, 1] * p1[Index(hang, cot) + 2] + H[i][1, 2] * p1[Index(hang, cot + 1) + 2]
                                + H[i][2, 0] * p1[Index(hang + 1, cot - 1) + 2] + H[i][2, 1] * p1[Index(hang + 1, cot) + 2] + H[i][2, 2] * p1[Index(hang + 1, cot + 1) + 2];
                            if (Math.Abs(t) > G)
                                G = Math.Abs(t);
                        }
                        v = (byte)(G >= threshold ? 255 : 0);
                        p2[Index(hang, cot) + 2] = v;
                    }
                }

            }

            source.UnlockBits(s);
            result.UnlockBits(r);
            return result;
        }

        unsafe
        public Bitmap Detect(Bitmap source, ImageType imageType, OperatorType opType, float threshold)
        {

            if (imageType == ImageType.Gray)
                return AnhXam(source, opType, threshold);
            return AnhMau(source, opType, threshold);
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
            byte v = 0;
            int tong = 0;
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
                        tong = p1[Index(hang - 1, cot - 1)] * H[0, 0] + p1[Index(hang - 1, cot)] * H[0, 1] + p1[Index(hang - 1, cot + 1)] * H[0, 2]
                           + p1[Index(hang, cot - 1)] * H[1, 0] + p1[Index(hang, cot)] * H[1, 1] + p1[Index(hang, cot + 1)] * H[1, 2]
                           + p1[Index(hang + 1, cot - 1)] * H[2, 0] + p1[Index(hang + 1, cot)] * H[2, 1] + p1[Index(hang + 1, cot + 1)] * H[2, 2];
                        v = (byte)(tong / m);
                        p2[Index(hang, cot)] = v;


                        tong = p1[Index(hang - 1, cot - 1) + 1] * H[0, 0] + p1[Index(hang - 1, cot) + 1] * H[0, 1] + p1[Index(hang - 1, cot + 1) + 1] * H[0, 2]
                          + p1[Index(hang, cot - 1) + 1] * H[1, 0] + p1[Index(hang, cot) + 1] * H[1, 1] + p1[Index(hang, cot + 1) + 1] * H[1, 2]
                          + p1[Index(hang + 1, cot - 1) + 1] * H[2, 0] + p1[Index(hang + 1, cot) + 1] * H[2, 1] + p1[Index(hang + 1, cot + 1) + 1] * H[2, 2];
                        v = (byte)(tong / m);
                        p2[Index(hang, cot) + 1] = v;

                        tong = p1[Index(hang - 1, cot - 1) + 2] * H[0, 0] + p1[Index(hang - 1, cot) + 2] * H[0, 1] + p1[Index(hang - 1, cot + 1) + 2] * H[0, 2]
                           + p1[Index(hang, cot - 1) + 2] * H[1, 0] + p1[Index(hang, cot) + 2] * H[1, 1] + p1[Index(hang, cot + 1) + 2] * H[1, 2]
                           + p1[Index(hang + 1, cot - 1) + 2] * H[2, 0] + p1[Index(hang + 1, cot) + 2] * H[2, 1] + p1[Index(hang + 1, cot + 1) + 2] * H[2, 2];
                        v = (byte)(tong / m);
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
                        v = (byte)l[l.Count / 2];
                        p2[Index(hang, cot)] = v;

                        List<int> l1 = new List<int>();
                        l1.Add(p1[Index(hang - 1, cot - 1)]+1);
                        l1.Add(p1[Index(hang - 1, cot)]+1);
                        l1.Add(p1[Index(hang - 1, cot + 1)]+1);
                        l1.Add(p1[Index(hang, cot - 1)]+1);
                        l1.Add(p1[Index(hang, cot)]+1);
                        l1.Add(p1[Index(hang, cot + 1)]+1);
                        l1.Add(p1[Index(hang + 1, cot - 1)]+1);
                        l1.Add(p1[Index(hang + 1, cot)]+1);
                        l1.Add(p1[Index(hang + 1, cot + 1)]+1);
                        l1.Sort();
                        v = (byte)l1[l1.Count / 2];
                        p2[Index(hang, cot)+1] = v;

                        List<int> l2 = new List<int>();
                        l2.Add(p1[Index(hang - 1, cot - 1)]+2);
                        l2.Add(p1[Index(hang - 1, cot)]+2);
                        l2.Add(p1[Index(hang - 1, cot + 1)]+2);
                        l2.Add(p1[Index(hang, cot - 1)]+2);
                        l2.Add(p1[Index(hang, cot)]+2);
                        l2.Add(p1[Index(hang, cot + 1)]+2);
                        l2.Add(p1[Index(hang + 1, cot - 1)]+2);
                        l2.Add(p1[Index(hang + 1, cot)]+2);
                        l2.Add(p1[Index(hang + 1, cot + 1)]+2);
                        l2.Sort();
                        v = (byte)l2[l2.Count / 2];
                        p2[Index(hang, cot)+2] = v;
                    }
                }
            }

            source.UnlockBits(bm1);
            result.UnlockBits(bm2);
            return result;
        }
    }
}
