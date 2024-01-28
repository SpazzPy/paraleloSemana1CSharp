using System;
using System.Threading.Tasks;

namespace Tarea1Ejercicio1
{
    class Program
    {
        static async Task Main(string[] args)
        {   
            while (true)
            {
                string option = "";
                Console.WriteLine("");
                Console.WriteLine("Menu");
                Console.WriteLine(" 1. Run Tasks");
                Console.WriteLine(" 2. Exit");
                Console.WriteLine("Type your option: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        await runTasks();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine(option + " isn't a valid option.");
                        break;
                }

            }
        }
        
        static async Task runTasks()
        {
            int peopleAmount = 20;
            int dateAmount = 30;

            if (peopleAmount > dateAmount)
            {
                dateAmount = peopleAmount;
            }

            Task t1 = Task.Run(() => task1.FibonacciCount(1000, 350));
            Task t2 = Task.Run(() => task2.AddRandomPeople(peopleAmount, 150));
            Task t3 = Task.Run(() => task3.GenerateDates(dateAmount, 200));
            Task t4 = Task.Run(() => task4.UpdatePersonDOB(peopleAmount, 250));
            Task t5 = Task.Run(() => task5.ReadMemoryRAM(30, 300));

            await Task.WhenAll(t1, t2, t3, t4, t5);
            Console.WriteLine("All tasks finished");
        }
    }
}