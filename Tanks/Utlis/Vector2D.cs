namespace Tanks.Utlis
{
    internal class Vector2D
    {
        public double X { get; }
        public double Y { get; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2D Shift(double dx, double dy)
        {
            return new Vector2D(X + dx, Y + dy);
        }
    }
}