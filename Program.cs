using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
   
    public abstract class Subject
    {
   
        protected List<IObserver> _observerList = new List<IObserver>();

   
        public void Attach(IObserver observer)
        {
            if (!this._observerList.Contains(observer))
                this._observerList.Add(observer);
        }

   
        public void Detach(IObserver observer)
        {
            if (this._observerList.Contains(observer))
                this._observerList.Remove(observer);
        }

   
        protected abstract void Notify();
    }

    public interface IObserver
    {
        // PULL version
        void Update(Subject subject);

        // PUSH version
        //void Update(string director, string title, MovieStatus status);
    }

    public class Option : Subject, IObserver
    {
        private Stock stock;
        private string name;
        private double price;

        public Stock Stock { get => stock; set => stock = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public Option(Stock stock, string name, double price)
        {
            this.Stock = stock;
            this.Name = name;
            this.Price = price;
        }

        public void Update(Subject subject)
        {
            if (!(subject is Stock))
                return;

            Stock stock = subject as Stock;
            this.Price = stock.Price * 0.1;
            this.Notify();

        }

        protected override void Notify()
        {
            foreach (var observer in this._observerList)
                observer.Update(this);
        }
    }

    public class Stock : Subject
    {
        private string name;
        private double price;

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set
            {
                price = value;
                Notify();
            }
        }

        public Stock(string name, double price)
        {
            this.name = name;
            this.price = price;            
        }

        protected override void Notify()
        {
            foreach (var observer in this._observerList)
                observer.Update(this);
        }
    }

    public class Investor : IObserver
    {
        private string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Subject subject)
        {            
            if (subject is Stock)
            {
                var s = subject as Stock;
                Console.WriteLine("-------------");
                Console.WriteLine("Powiadomienie dla inwestora: {0}", this.name);
                Console.WriteLine("Cena akcji {0} zmieni³a siê i wynosi {1} $.", s.Name, s.Price);
            }
            else if (subject is Option)
            {
                var s = subject as Option;
                Console.WriteLine("-------------");
                Console.WriteLine("Powiadomienie dla inwestora: {0}", this.name);
                Console.WriteLine("Cena opcji {0} zmieni³a siê i wynosi {1} $.", s.Name, s.Price);
            }
            else
            {
                return;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stock appleStock = new Stock("Apple akcja", 200.00);
            Option appleOption = new Option(appleStock, "Apple opcja", 20.00);

            Investor investor1 = new Investor("Jan Kowalski");
            Investor investor2 = new Investor("Anna Nowak");

            appleStock.Attach(investor1);
            appleStock.Attach(investor2);
            appleStock.Attach(appleOption);
            appleOption.Attach(investor1);
            appleOption.Attach(investor2);
            
            appleStock.Price = 210.00;
            
            appleStock.Detach(investor1);
            appleOption.Detach(investor1);
            
            appleStock.Price = 220.00;
            appleOption.Price = 22.00;

            Console.ReadKey();
        }
    }
}
