namespace P01_StudentSystem.App
{
    using System;
    using System.Text;
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Seed;


    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (var context = new StudentSystemContext())
            {
               DatabaseInitializer.InitialSeed(context);  
            }
        }

    }
}
