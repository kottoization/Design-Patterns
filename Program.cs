using CompositePattern1;
using System;

namespace OrganisationStucture_CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Folder f1 = new Folder("Folder 1");

            Email e1_1 = new Email("test@mail.com", "receive@mail.com", "title1", "test test test 1111");
            f1.AddChild(e1_1);

            Folder f11 = new Folder("Software Development Department");
            f1.AddChild(f11);

            Email e11_1 = new Email("test2@mail.com", "receive2@mail.com", "title2", "test test test 222222");
            f11.AddChild(e11_1);

            Folder f111 = new Folder("Programming Languages");
            f11.AddChild(f111);

            Email e111_1 = new Email("test3@mail.com", "receive3@mail.com", "title3", "test test test 333333");
            f111.AddChild(e111_1);

            Email e111_2 = new Email("test4@mail.com", "receive4@mail.com", "title4", "test test test 444444");
            f111.AddChild(e111_2);

            Folder f112 = new Folder("Testing Department");
            f11.AddChild(f112);

            Console.WriteLine(f1.PrintStructure());
            Console.WriteLine("");
            
            Console.WriteLine("The sum of emails for: {0} are: {1}", f1.name, f1.GetNumberOfEmails());
                        
            Console.WriteLine("The sum of emails for: {0} are: {1}", f11.name, f1.GetNumberOfEmails());
                        
            Console.WriteLine("The sum of emails for: {0} are: {1}", f111.name, f1.GetNumberOfEmails());
                        
            Console.WriteLine("The sum of emails for: {0} are: {1}", f112.name, f1.GetNumberOfEmails());

           

            Console.ReadKey();
        }
    }
}
