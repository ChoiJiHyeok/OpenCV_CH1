using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCV_basic
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mat src = Cv2.ImRead(@"C:\Users\user\Desktop\image\img_2.png");

            Mat gray = new Mat();
            Mat hist = new Mat();
            Mat result = Mat.Ones(new OpenCvSharp.Size(256, src.Height), MatType.CV_8UC1); // Width : 256 , Height : height of src , bit - depth : 8bit, channels : 1
            Mat dst = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY); // src & gray를 BGR 컬러를 gray 변경
            Cv2.CalcHist(new Mat[] { gray }, new int[] { 0 }, null, hist, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                Cv2.Line(result, new OpenCvSharp.Point(i, src.Height), new OpenCvSharp.Point(i, src.Height - hist.Get<float>(i)), Scalar.White);

            }

            Cv2.HConcat(new Mat[] { gray, result }, dst); // HConcat : : 두개의 이미지를 가로로 붙여 리턴 . Vconcat : 두개의 이미지를 세로로 붙여 리턴(세로로 붙이기떄문에 두 이미지의 width가 일치해야 되는듯) 
            Cv2.ImShow("dst", dst); // dst 객체 show 
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
        //public double DistanceTo(OpenCvSharp.Point point, OpenCvSharp.Point otherPoint) // 두 점 사이의 거리 
        //{
        //    int dx = point.X - otherPoint.X;
        //    int dy = point.Y - otherPoint.Y;
        //    return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)); // Math.Sqrt() : 지정된 숫자의 제곱근을 반환, Math.Pow(double x, double y) : 지정된 숫자의 거듭 제곱근을 반환
        //}
        //public int Dotproduct(OpenCvSharp.Point point1, OpenCvSharp.Point point2) // x끼리 곱하고 y끼리 곱하고 더한값 리턴
        //{
        //    int dx = point1.X * point2.X;
        //    int dy = point1.Y * point2.Y;
        //    return dx + dy;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0); // 4개의 요소를 지니는  double  구조체
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);
            Console.WriteLine(vector1.Item0.ToString()); ; // vector1 의 아이템 0번째 
            Console.WriteLine(vector1[1].ToString()); ; // vector1의 1번째 인덱스  
            Console.WriteLine(vector1.Equals(vector2).ToString());// Object.Equals 두 개체의 인스턴스가 같은지 확인한다 return : boolean

            Vec3d Vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d pt1 = new Vec3d(1.0, 2.0, 3.0);
            Point3d pt2 = Vector; // shallow copy

            Console.WriteLine(pt1);
            Console.WriteLine(pt2);
            Console.WriteLine(pt1.X);

            OpenCvSharp.Point p1 = new OpenCvSharp.Point(1, 2);
            OpenCvSharp.Point p2 = new OpenCvSharp.Point(3, 2);

            Console.WriteLine(p1.DistanceTo(p2));
            Console.WriteLine(p1.DotProduct(p2));
            Console.WriteLine(p1.CrossProduct(p2));

            Console.WriteLine(p1 + p2);
            Console.WriteLine(p1 - p2);
            Console.WriteLine((p1 == p2));
            Console.WriteLine(p1 * 0.5);

            //Scalar
            Scalar scalar1 = new Scalar(255, 127);
            /// Scalar
            /// 스칼라 구조체에서 지원하는 연산
            ///  

            Scalar scalar2 = Scalar.Yellow;  // Yellow 값을 할당
            Scalar scalar3 = Scalar.All(99); // 모든 값을 할당

            Console.WriteLine(scalar1.ToString());
            Console.WriteLine(scalar2.ToString());
            Console.WriteLine(scalar3.ToString());


        }
    }
}
