using System.Drawing;
using System.Reflection.PortableExecutable;

namespace AbstractFactory
{
    // this does not follow OCP from SOLID methods, needs some adjustments to do so
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Drinking tea ... ");
        }
    }
    internal class Coffe : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Drinking coffe ... ");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"{amount} ml :Prepare the tea following the instruction ... ");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"{amount} ml : Prepare the coffe following the instruction ... ");
            return new Coffe();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrinks { Coffe, Tea}

        private Dictionary<AvailableDrinks, IHotDrinkFactory> factories = new Dictionary<AvailableDrinks, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach(AvailableDrinks drink in Enum.GetValues(typeof(AvailableDrinks)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("AbstractFactory."+Enum.GetName(typeof(AvailableDrinks), drink)+"Factory")
                    );
                factories.Add(drink, factory);
            }        
        }

        public IHotDrink MakeDrink(AvailableDrinks drink, int amout)
        {
            return factories[drink].Prepare(amout);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            HotDrinkMachine machine = new HotDrinkMachine();
            var drink1 = machine.MakeDrink(HotDrinkMachine.AvailableDrinks.Tea, 250);
            var drink2 = machine.MakeDrink(HotDrinkMachine.AvailableDrinks.Coffe, 330);
        }        
    }
}