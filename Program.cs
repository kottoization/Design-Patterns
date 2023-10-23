namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment comment1 = new Comment("To jest przykładowy komentarz z pomidorem.");
            Comment comment2 = new Comment("Dziś zjadam pomidory i ogórki.");
            Comment comment3 = new Comment("Przykladowy komentarz bez zabronionego slowa.");
            Comment comment4 = new Comment("pomidorbezspacji");

            Console.WriteLine("Komentarz 1 przed moderacja: " + comment1.GetContent());
            Console.WriteLine("Komentarz 2 przed moderacja: " + comment2.GetContent());
            Console.WriteLine("Komentarz 3 przed moderacja: " + comment3.GetContent());
            Console.WriteLine("Komentarz 4 przed moderacja: " + comment4.GetContent());

            Forum forum1 = new Forum();

            ICommand command1 = new RemoveWordCommand(comment1, "pomidor", forum1);
            ICommand command2 = new RemoveWordCommand(comment2, "pomidor", forum1);
            ICommand command3 = new RemoveWordCommand(comment3, "pomidor", forum1);
            ICommand command4 = new RemoveWordCommand(comment4, "pomidor", forum1);

            Moderator moderator = new Moderator();

            moderator.AddCommand(command1);
            moderator.AddCommand(command2);
            moderator.AddCommand(command3);
            moderator.AddCommand(command4);

            moderator.ProcessCommands();

            Console.WriteLine("=============================");
            forum1.printAcceptedComments();

            Console.ReadKey();
        }
    }
}