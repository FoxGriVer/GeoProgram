using Labs.MapObjects.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.MapObjects.Shapes
{
    public class GeoRect
    {
        public GeoRect(double xmax, double xmin, double ymin, double ymax)
        {
            Xmin=xmin;
            Xmax=xmax;
            Ymin=ymin;
            Ymax=ymax;
        }

        public double Xmin, Ymin, Xmax, Ymax;

        public bool isCucumber
        {
            get 
            {
                if (Xmax != 0 || Xmin != 0 || Ymin != 0 || Ymax != 0)
                    return (true);
                else return (false);
            }
        }

        public static GeoRect Union(GeoRect A, GeoRect B)
        {
            if (!A.isCucumber)
            {
                return B;
            }
            if (!B.isCucumber)
            {
                return A;
            }
            GeoRect result = new GeoRect(Math.Min(A.Xmax, B.Xmax),
                                         Math.Max(A.Xmin, B.Xmin),
                                         Math.Min(A.Ymin, B.Ymin),
                                         Math.Max(A.Ymax, B.Ymax));
            return result;
        }

        public static bool isIntersect(GeoRect A, GeoRect B)
        {
            //yay!
            if ((B.Xmax >= A.Xmax && B.Xmax <= A.Xmin && B.Ymax <= A.Ymax && B.Ymax >= A.Ymin) ||
                (B.Xmin >= A.Xmax && B.Xmin <= A.Xmin && B.Ymin <= A.Ymax && B.Ymin >= A.Ymin) ||
                (B.Xmax >= A.Xmax && B.Xmax <= A.Xmin && B.Ymin <= A.Ymax && B.Ymin >= A.Ymin) ||
                (B.Xmin >= A.Xmax && B.Xmin <= A.Xmin && B.Ymax <= A.Ymax && B.Ymax >= A.Ymin)
                ) return true;

            if ((A.Xmax >= B.Xmax && A.Xmax <= B.Xmin && A.Ymax <= B.Ymax && A.Ymax >= B.Ymin) ||
                (A.Xmin >= B.Xmax && A.Xmin <= B.Xmin && A.Ymin <= B.Ymax && A.Ymin >= B.Ymin) ||
                (A.Xmax >= B.Xmax && A.Xmax <= B.Xmin && A.Ymin <= B.Ymax && A.Ymin >= B.Ymin) ||
                (A.Xmin >= B.Xmax && A.Xmin <= B.Xmin && A.Ymax <= B.Ymax && A.Ymax >= B.Ymin)
                ) return true;

            return false;
        }

        public static bool IsCrosLines(GeoPoint b1, GeoPoint e1, GeoPoint b2, GeoPoint e2)
        {
            double ax1 = b1.x;
            double ay1 = b1.y;
            double ax2 = e1.x;
            double ay2 = e1.y;
            double bx1 = b2.x;
            double by1 = b2.y;
            double bx2 = e2.x;
            double by2 = e2.y;
            double v1=(bx2-bx1)*(ay1-by1)-(by2-by1)*(ax1-bx1);
            double v2=(bx2-bx1)*(ay2-by1)-(by2-by1)*(ax2-bx1);
            double v3=(ax2-ax1)*(by1-ay1)-(ay2-ay1)*(bx1-ax1);
            double v4=(ax2-ax1)*(by2-ay1)-(ay2-ay1)*(bx2-ax1);
            return ((v1*v2<=0) && (v3*v4<=0));
        }


    }
}
