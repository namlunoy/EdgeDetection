using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection_Gradient
{
    public enum ImageType
    { Gray, Color }
    public enum OperatorType
    { Roberts, Sobel, Prewitt,LaBan_Kirsh }

    public enum FilterType
    { Khong, Arithmetic_Mean_Filter, Meadian_Filter }

    public enum FilterMatrix
    { H_9, H_10, H_16 }

    public static class Operator
    {
        public static void GetOperator(OperatorType type, out int[,] Hx, out int[,] Hy)
        {
            Hx = Hy = null;
            switch (type)
            {

                case OperatorType.Roberts:
                    // Hx : 1  0
                    //      0 -1
                    //----------
                    // Hy : 0  1 
                    //     -1  0
                    Hx = new int[2, 2];
                    Hy = new int[2, 2];
                    //Hx:
                    Hx[0, 0] = 1; Hx[0, 1] = 0;
                    Hx[1, 0] = 0; Hx[1, 1] = -1;
                    //Hy:
                    Hy[0, 0] = 0; Hy[0, 1] = 1;
                    Hy[1, 0] = -1; Hy[1, 1] = 0;
                    break;

                case OperatorType.Sobel:
                    // Hx : -1  0  1
                    //      -2  0  2
                    //      -1  0  1
                    //----------
                    // Hy : -1  -2  -1
                    //       0   0   0
                    //       1   2   1
                    Hx = new int[3, 3];
                    Hy = new int[3, 3];
                    //Hx:
                    Hx[0, 0] = -1; Hx[0, 1] = 0; Hx[0, 2] = 1;
                    Hx[1, 0] = -2; Hx[1, 1] = 0; Hx[1, 2] = 2;
                    Hx[2, 0] = -1; Hx[2, 1] = 0; Hx[2, 2] = 1;
                    //Hy:
                    Hy[0, 0] = -1; Hy[0, 1] = -2; Hy[0, 2] = -1;
                    Hy[1, 0] = 0; Hy[1, 1] = 0; Hy[1, 2] = 0;
                    Hy[2, 0] = 1; Hy[2, 1] = 2; Hy[2, 2] = 1;
                    break;

                case OperatorType.Prewitt:
                    // Hx : -1  0  1
                    //      -1  0  1
                    //      -1  0  1
                    //----------
                    // Hy : -1  -1  -1
                    //       0   0   0
                    //       1   1   1
                    Hx = new int[3, 3];
                    Hy = new int[3, 3];
                    //Hx:
                    Hx[0, 0] = -1; Hx[0, 1] = 0; Hx[0, 2] = 1;
                    Hx[1, 0] = -1; Hx[1, 1] = 0; Hx[1, 2] = 1;
                    Hx[2, 0] = -1; Hx[2, 1] = 0; Hx[2, 2] = 1;
                    //Hy:
                    Hy[0, 0] = -1; Hy[0, 1] = -1; Hy[0, 2] = -1;
                    Hy[1, 0] = 0; Hy[1, 1] = 0; Hy[1, 2] = 0;
                    Hy[2, 0] = 1; Hy[2, 1] = 1; Hy[2, 2] = 1;
                    break;
                default:
                    break;
            }
        }

        public static int[,] GetFilterMatrix(FilterMatrix type)
        {
            int[,] H = new int[3, 3];
            switch (type)
            {
                case FilterMatrix.H_9:
                    H[0, 0] = 1; H[0, 1] = 1; H[0, 2] = 1;
                    H[1, 0] = 1; H[1, 1] = 1; H[1, 2] = 1;
                    H[2, 0] = 1; H[2, 1] = 1; H[2, 2] = 1;
                    break;
                case FilterMatrix.H_10:
                    H[0, 0] = 1; H[0, 1] = 1; H[0, 2] = 1;
                    H[1, 0] = 1; H[1, 1] = 2; H[1, 2] = 1;
                    H[2, 0] = 1; H[2, 1] = 1; H[2, 2] = 1;
                    break;
                case FilterMatrix.H_16:
                    H[0, 0] = 1; H[0, 1] = 2; H[0, 2] = 1;
                    H[1, 0] = 2; H[1, 1] = 4; H[1, 2] = 2;
                    H[2, 0] = 1; H[2, 1] = 2; H[2, 2] = 1;
                    break;
                default:
                    break;
            }
            return H;
        }
    }
}
