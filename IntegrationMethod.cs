using System;
using System.Collections.Generic;


namespace NumIntegration
{
    class IntegrationMethod
    {
        public List<Point> points = new List<Point>();

        int n;
        public double a, b, h;
        public double maxFirstD, maxSecondD, maxFourthD, maxSixthD;

        public double resLeftRecSimple,   resLeftRec,   errLeftRecSimple,   errLeftRec;
        public double resRightRecSimple,  resRightRec,  errRightRecSimple,  errRightRec;
        public double resMiddleRecSimple, resMiddleRec, errMiddleRecSimple, errMiddleRec;
        public double resTrapeziumSimple, resTrapezium, errTrapeziumSimple, errTrapezium;
        public double resSimpsonSimple,   resSimpson,   errSimpsonSimple,   errSimpson;
        public double resGaussSimple,     resGauss,     errGaussSimple,     errGauss;

        public IntegrationMethod()
        {
            n = 8;
            a = 0;
            b = 0.5;
            h = (b - a) / n;

            for (int i = 0; i <= n; i++)
            {
                double x = a + i * h;
                double y = Math.Round(InFunction(x), 4);
                points.Add(new Point(x, y));
            } 
        }

        double InFunction(double x)
        {
            return Math.Tan(Math.Pow(x, 3.0));
        }

        double FirstDerivative(double x)
        {
            /* ... */;
            return 0.0;
        }

        void MaxFirstDerivative()
        {
            /* ... */;
        }

        double SecondDerivative(double x)
        {
            /* ... */;
            return 0.0;
        }

        void MaxSecondDerivative()
        {
            /* ... */;
        }

        double FourthDerivative(double x)
        {
            /* ... */;
            return 0.0;
        }

        void MaxFourthDerivative()
        {
            /* ... */;
        }

        double SixthDerivative(double x)
        {
            /* ... */;
            return 0.0;
        }

        void MaxSixthDerivative()
        {
            /* ... */;
        }

        // --- left ----
        void LeftRectangleSimple()
        {
            resLeftRecSimple = InFunction(a) * (b - a);
        }

        void LeftRectangleMethod()
        {
            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                resLeftRec += InFunction(x);
            }
            resLeftRec *= h;
        }

        void ErrLeftRectangleSimple()
        {
            errLeftRecSimple = (maxFirstD * (b - a) * (b - a)) / 2.0;
        }

        void ErrLeftRectangle()
        {
            errLeftRec = (maxFirstD * (b - a) * h) / 2.0;
        }

        // --- right ----
        void RightRectangleSimple()
        {
            resRightRecSimple = InFunction(b) * (b - a);
        }

        void RightRectangleMethod()
        {
            for (int i = 1; i <= n; i++)
            {
                double x = a + i * h;
                resRightRec += InFunction(x);
            }
            resRightRec *= h;
        }

        void ErrRightRectangleSimple()
        {
            errRightRecSimple = (maxFirstD * Math.Pow((b - a), 2.0)) / 2.0;
        }

        void ErrRightRectangle()
        {
            errRightRec = (maxFirstD * (b - a) * h) / 2.0;
        }

        // --- midle ----
        void MiddleRectangleSimple()
        {
            resMiddleRecSimple = InFunction((a + b) / 2.0) * (b - a);
        }

        void MiddleRectangleMethod()
        {
            for (int i = 1; i <= n; i++)
            {
                double x = a + i * h - h/2.0;
                resMiddleRec += InFunction(x);
            }
            resMiddleRec *= h;
        }

        void ErrMiddleRectangleSimple()
        {
            errMiddleRecSimple = (maxSecondD * Math.Pow((b - a), 3.0)) / 24.0;
        }

        void ErrMiddleRectangle()
        {
            errMiddleRec = (maxSecondD * (b - a) * Math.Pow(h, 2.0)) / 24.0;
        }

        // --- trapezium ----
        void TrapeziumSimple()
        {
            resTrapeziumSimple += ((InFunction(a) + InFunction(b)) / 2.0) * (b - a);
        }
        void TrapeziumMethod()
        {
            resTrapezium = (InFunction(a) + InFunction(b)) / 2.0;
            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                resTrapezium += InFunction(x);
            }
            resTrapezium *= h;
        }

        void ErrTrapeziumSimple()
        {
            errTrapeziumSimple = -( (maxSecondD * Math.Pow((b-a), 3.0)) / 12.0);
        }

        void ErrTrapezium()
        {
            errTrapezium = -(maxSecondD * (b - a) * h * h) / 12.0;
        }

        // --- Simpson ----
        void SimpsonSimple()
        {
            double tmp = InFunction(a) + 4.0 * InFunction((a + b) / 2.0) + InFunction(b);
            resSimpsonSimple = ((b - a) / 6.0) * tmp;
        }

        void SimpsonMethod()
        {
            double sumEven = 0; //чет
            double sumOdd = 0;  //нечет

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                if (i % 2 == 0) sumEven += InFunction(x);
                else             sumOdd += InFunction(x);
            }
            resSimpson = (h / 3.0) * (InFunction(a) + 2 * sumEven + 4 * sumOdd + InFunction(b));
        }

        void ErrSimpsonSimple()
        {
            errSimpsonSimple = Math.Abs((Math.Pow((b - a), 5.0) * maxFourthD) / 2880.0);
        }

        void ErrSimpson()
        {
            errSimpson =  Math.Abs( ((b - a) * Math.Pow(h, 4.0) * maxFourthD) / 2880.0 );
        }

        // --- Gauss ----
        double GaussSimple(double a, double b)
        {
            double A = (b - a) / 2.0;
            double B = InFunction((a + b) / 2.0 - (b - a) / (2.0 * Math.Sqrt(3.0)));
            double C = InFunction((a + b) / 2.0 + (b - a) / (2.0 * Math.Sqrt(3.0)));

            double res = A * (B + C);
            return res;
        }

        void CalcGaussSimple()
        {
            for (int i = 0; i < n; ++i)
            {
                resGaussSimple += GaussSimple(a + i * (b - a) / n, a + (i + 1) * (b - a) / n);
            }
        }

        void ErrorGaussSimple()
        {
            double A = (b - a) / (2.5 * Math.Sqrt(2));
            double B = Math.Pow( (b - a) / (2*3.0), 2.0* 2);

            errGaussSimple = Math.Abs(A * B * maxFourthD);
        }

        double GaussMethod(double a, double b)
        {
            int    cnt = 3;
            double r   = (b - a) / 2.0;
            double s   = (a + b) / 2.0;
            double res = 0;

            double[] xi = { -0.774596669241483,
                             0.0,
                             0.774596669241483   };

            double[] wi = {  0.555555555555556,
                             0.888888888888889, 
                             0.555555555555556   };

            for (int i = 0; i < cnt; i++)
            {
                res += wi[i] * InFunction(r * xi[i] + s);
            }
            return res * r;
        }

        void CalcGaussMethod()
        {
            for (int i = 0; i < n; ++i)
            {
                resGauss += GaussMethod(a + i * (b - a) / n, a + (i + 1) * (b - a) / n);
            }
        }

        void ErrorGaussMethod()
        {
            double A = (b - a) / (2.5 * Math.Sqrt(3));
            double B = Math.Pow((b - a) / (3 * 3.0), 2.0 * 3);

            errGauss = Math.Abs(A * B * maxSixthD);
        }

        //////////////////////////////////////////////////////////
        public void CalcIntegrals()
        {
            /* ... */;
        }
    }
}
