namespace NumIntegration
{
    class Point
    {
        double x;
        double y;

        Point()
        {
            this.x = 0.0;
            this.y = 0.0;
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double  GetX()
        {
            return this.x;
        }

        public double GetY()
        {
            return this.y;
        }
    }
}
