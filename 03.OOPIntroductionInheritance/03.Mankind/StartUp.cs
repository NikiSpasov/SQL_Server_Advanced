using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            string[] studentInput = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);

            string[] workerInput = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Worker worker = new Worker(workerInput[0], workerInput[1],
                decimal.Parse(workerInput[2]), double.Parse(workerInput[3]));
            Console.WriteLine(student.ToString());
            Console.WriteLine(worker);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
}

