namespace MonostatePattern
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var ceo = new CEO();
            ceo.Name = "John Kowalski";
            ceo.Age = 43;

            var ceo2 = new CEO();

            Console.WriteLine(ceo);
            Console.WriteLine(ceo2);
            ceo2.Age = 50;
            Console.WriteLine(ceo);
        }
    }
}