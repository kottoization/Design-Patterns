using System.Drawing;
using System.Xml.Serialization;
using System.Linq;
using NUnit.Framework;
using System.ComponentModel;

namespace SingletonPattern
{
    public class Program
    {
        public interface IDatabase
        {
            int GetPopulation(string name);
        }

        public class SingletonDatabase : IDatabase
        {
            private Dictionary<string, int> capitals;
            private static int instanceCount;
            public static int Count => instanceCount;

            public SingletonDatabase()
            {
                instanceCount++;
                Console.WriteLine("Initializing database...");
                capitals = new Dictionary<string, int>();
                string[] lines = File.ReadAllLines(Path.Combine(new FileInfo(typeof(IDatabase).Assembly
                    .Location).DirectoryName, "capitals.txt"
                    /*@"..\..\..\capitals.txt"*/));

                for (int i = 0; i < lines.Length; i += 2)
                {
                    string capital = lines[i];
                    int population = int.Parse(lines[i + 1]);
                    capitals[capital] = population;
                }
            }

            public int GetPopulation(string name)
            {
                return capitals[name];
            }

            private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(
                () => new SingletonDatabase()
                );
            public static SingletonDatabase Instance => instance.Value;
        }


        public class SingletonTests
        {
            //    [Test]
            //    public void IsSingleton()
            //    {
            //        var db1 = SingletonDatabase.Instance;
            //        var db2 = SingletonDatabase.Instance;

            //        Assert.AreSame(db1, db2);                                
            //        Assert.AreEqual(1, SingletonDatabase.Count);
            //    }

            public static bool IsSingleton()
            {
                var db1 = SingletonDatabase.Instance;
                Console.WriteLine(" 1st instance has been created!");
                Console.WriteLine(" 2nd instance has been created!");
                var db2 = SingletonDatabase.Instance;

                if (db1 != db2)
                {
                    return false;
                }

                if (SingletonDatabase.Count != 1)
                {
                    return false;
                }

                return true;
            }


        }

        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Nairobi";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
            Console.WriteLine("======TEST======");
            if (SingletonTests.IsSingleton())
                Console.WriteLine("Test did pass");
            else
                Console.WriteLine("test did not pass");
        }
    }
}