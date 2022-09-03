namespace lab03.part1
{
    public class Vector
    {
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator *(Vector v, double d)
        {
            return new Vector(v.x * d, v.y * d, v.z * d);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        public static bool operator <(Vector v1, Vector v2)
        {
            return v1.Length < v2.Length;
        }

        public static bool operator >(Vector v1, Vector v2)
        {
            return v1.Length > v2.Length;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.Length == v2.Length;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return v1.Length != v2.Length;
        }

        double x, y, z;

        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }
        public double Length { get { return Math.Sqrt(x * x + y * y + z * z); } }
        public string Info
        { get { return $"({x}, {y}, {z})"; } }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public class Program
    {
        static void Main()
        {
            Vector v1 = new(2, 3, 4);
            Vector v2 = new(5, 1, 3);
            Console.WriteLine($"v1: {v1.Info}");
            Console.WriteLine($"v2: {v2.Info}");

            Console.WriteLine($"v1 + v2: {(v1 + v2).Info}");

            double d = 0.5;
            Console.WriteLine($"v1 * {d}: {(v1 * d).Info}");
            Console.WriteLine($"v2 * {d}: {(v2 * d).Info}");

            Console.WriteLine($"v1 * v2: {v1 * v2}");

            Console.WriteLine($"v1 > v2 ?: {v1 > v2}");
            Console.WriteLine($"v1 < v2 ?: {v1 < v2}");
            Console.WriteLine($"v1 == v2 ?: {v1 == v2}");
            Console.WriteLine($"v1 != v2 ?: {v1 != v2}");
        }
    }
}