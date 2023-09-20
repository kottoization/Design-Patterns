using System.Collections.Concurrent;
internal static class Program
{
    static BlockingCollection<int> upToTenMessages =
        new BlockingCollection<int>(new ConcurrentBag<int>(), 10);

    static CancellationTokenSource cts = new CancellationTokenSource();

    static Random random = new Random();
    static void ProduceAndConsume()
    {
        var producer = Task.Factory.StartNew(RunProducer);
        var consumer = Task.Factory.StartNew(RunConsumer);

        try
        {
            Task.WaitAll(new[] { producer, consumer }, cts.Token);
        }
        catch (AggregateException ae)
        {
            ae.Handle(e => true);
        }
    }

    static void Main() {
        Task.Factory.StartNew(ProduceAndConsume, cts.Token);

        Console.ReadKey();
        cts.Cancel();
    }


    private static void RunConsumer()
    {
        foreach (var item in upToTenMessages.GetConsumingEnumerable())
        {
            cts.Token.ThrowIfCancellationRequested();
            Console.WriteLine($"-{item}\t");
            Thread.Sleep(2000);
        }
    }

    private static void RunProducer()
    {
        while (true)
        {
            cts.Token.ThrowIfCancellationRequested();
            int i = random.Next(100);
            upToTenMessages.Add(i);
            // Thread is blocked here if there is no space for a new element in BlockingCollection
            Console.WriteLine($"+{i}\t");
            Thread.Sleep(100);
        }
    }
}
