namespace AsynchronousInitializationPattern
{

    public interface IAsyncInit
    {
        Task InitTask { get; }
    }

    public class MyClass : IAsyncInit
    {
        public MyClass()
        {
            InitTask = InitAsync();
        }
        public Task InitTask { get; }

        private async Task InitAsync()
        {
            await Task.Delay(1000);
        }
    }

    public class MyOtherClass : IAsyncInit
    {
        private readonly MyClass myClass;

       
        public MyOtherClass(MyClass passedMyClass)
        {   
            this.myClass = passedMyClass;
            InitTask = InitAsync();
        }
        public Task InitTask { get; }

        private async Task InitAsync()
        {
            if (this.myClass is IAsyncInit ai)
                await ai.InitTask;
            await Task.Delay(1000);
        }
    }
    public class Program
    {
        static async void Main(string[] args)
        {
            var myClass = new MyClass();
            var oc = new MyOtherClass(myClass);
            await oc.InitTask;
        }
    }
}