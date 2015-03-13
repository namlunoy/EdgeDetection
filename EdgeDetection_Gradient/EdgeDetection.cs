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
        public Bitmap Detect(Bitmap source, ImageType imageType, OperatorType opType, float threshold)
        {
            Bitmap result = null;
            switch (imageType)
            {
                case ImageType.Gray:
                    result = Detect_GrayImage(source, opType, threshold);
                    break;
                case ImageType.Color:
                    result = Detect_ColorImage(source, opType, threshold);
                    break;
                default:
                    break;
            }
            return result;
        }
        unsafe
        private Bitmap Detect_GrayImage(Bitmap source, OperatorType opType, float threshold)
        {
            source = (Bitmap)source.Clone();
            Bitmap result = new Bitmap(source.Width, source.Height, source.PixelFormat);

            BitmapData s = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);
            BitmapData r = result.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);
            stride = s.Stride;

            byte* p1 = (byte*)s.Scan0;
            byte* p2 = (byte*)r.Scan0;

            int[,] Hx, Hy;
            float gx = 0, gy = 0, G;
            Operator.GetOperator(opType, out Hx, out Hy);

            if(opType != OperatorType.Roberts)
            {
                for (int hang = 0; hang < s.Height; hang++)
                {
                    for (int cot = 0; cot < s.Width; cot++)
                    {
                        if (hang == 0 || hang == s.Height - 1 || cot == 0 || cot == s.Width)
                        {
                            p2[Index(hang, cot)] = 0;
                        }
                        else
                        {
                            //Tính gradient
                            gx = p1[Index(hang - 1, cot - 1)] * Hx[0, 0] + p1[Index(hang - 1, cot)] * Hx[1, 0] + p1[Index(hang - 1, cot + 1)] * Hx[2, 0]
                                + p1[Index(hang + 1, cot - 1)] * Hx[0, 2] + p1[Index(hang + 1, cot)] * Hx[1, 2] + p1[Index(hang + 1, cot + 1)] * Hx[2, 2];
                            gy = p1[Index(hang - 1, cot - 1)] * Hy[0, 0] + p1[Index(hang, cot - 1)] * Hy[0, 1] + p1[Index(hang + 1, cot - 1)] * Hy[0, 2]
                               + p1[Index(hang - 1, cot + 1)] * Hy[2, 0] + p1[Index(hang, cot + 1)] * Hy[2, 1] + p1[Index(hang + 1, cot + 1)] * Hy[2, 2];

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
        private Bitmap Detect_ColorImage(Bitmap source, OperatorType opType, float threshold)
        {
            source = (Bitmap)source.Clone();
            Bitmap result = new Bitmap(source);

            return null;
        }
    }
}
