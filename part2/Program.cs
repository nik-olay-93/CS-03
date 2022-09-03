namespace lab03.part2
{
    public class Program
    {
        public class Car : IEquatable<Car>
        {
            string name, engine;
            int maxSpeed;

            public string Name { get { return name; } }
            public int MaxSpeed { get { return maxSpeed; } }
            public string Engine { get { return engine; } }

            public Car(string name, string engine, int maxSpeed)
            {
                this.name = name;
                this.engine = engine;
                this.maxSpeed = maxSpeed;
            }

            public bool Equals(Car? other)
            {
                if (other == null) return false;
                return this.name == other.name && this.engine == other.engine && this.maxSpeed == other.maxSpeed;
            }

            public override string ToString()
            {
                return name;
            }
        }

        public class CarsCatalog
        {
            List<Car> cars;

            public string this[int key]
            {
                get { return $"{cars[key].Name}, {cars[key].Engine}"; }
            }

            public CarsCatalog()
            {
                cars = new();
            }

            public void Add(Car c)
            {
                cars.Add(c);
            }
        }

        static void Main()
        {
            Car c1 = new("Dodge", "V8", 12);
            Car c2 = new("Dodge", "V8", 12);

            CarsCatalog carsCatalog = new();

            Console.WriteLine($"c1 == c2 ?: {c1 == c2}");

            carsCatalog.Add(c1);
            carsCatalog.Add(c2);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Car #{i}: {carsCatalog[i]}");
            }
        }
    }
}