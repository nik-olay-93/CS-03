namespace lab03.part3
{
    public abstract class Currency
    {
        public abstract int Value { get; }
    }

    public class CurrencyUSD : Currency
    {
        int value;

        public override int Value { get { return value; } }

        public CurrencyUSD(int value)
        {
            this.value = value;
        }

        public static implicit operator CurrencyEUR(CurrencyUSD usd) => new(usd.value * CurrencyEUR.ExchangeRate);
        public static implicit operator CurrencyRUB(CurrencyUSD usd) => new(usd.value * CurrencyRUB.ExchangeRate);

        public static implicit operator CurrencyUSD(CurrencyEUR eur) => new(eur.Value / CurrencyEUR.ExchangeRate);
        public static implicit operator CurrencyUSD(CurrencyRUB rub) => new(rub.Value / CurrencyEUR.ExchangeRate);
    }
    public class CurrencyEUR : Currency
    {
        public static int ExchangeRate { get; set; }

        int value;

        public override int Value { get { return value; } }

        public CurrencyEUR(int value)
        {
            this.value = value;
        }

        public static explicit operator CurrencyEUR(CurrencyRUB rub)
        {
            return (CurrencyUSD)rub;
        }
    }

    public class CurrencyRUB : Currency
    {
        public static int ExchangeRate { get; set; }

        int value;

        public override int Value { get { return value; } }

        public CurrencyRUB(int value)
        {
            this.value = value;
        }

        public static explicit operator CurrencyRUB(CurrencyEUR eur)
        {
            return (CurrencyUSD)eur;
        }
    }


    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Exchange rates");

            Console.WriteLine("USD -> RUB: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            CurrencyRUB.ExchangeRate = int.Parse(input);

            Console.WriteLine("USD -> EUR: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            CurrencyEUR.ExchangeRate = int.Parse(input);

            CurrencyUSD usd = new(100);
            Console.WriteLine($"{usd.Value} USD is {((CurrencyRUB)usd).Value} RUB");
            Console.WriteLine($"{usd.Value} USD is {((CurrencyEUR)usd).Value} EUR");
        }
    }
}