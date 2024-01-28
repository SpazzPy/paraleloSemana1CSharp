using System;

public class task1
{
    public static async void FibonacciCount(int maxNumber = 1000000, int delay = 1)
    {
        await changeConsoleTextColor.WriteColoredText("Task 1 - Fibonacci Sequence - Initiated.", ConsoleColor.Green);   
        int n1 = 0, n2 = 1, n3 = 0;
        System.Threading.Thread.Sleep(delay);
        await changeConsoleTextColor.WriteColoredText("Task 1 - Fibonacci Sequence: " + n1, ConsoleColor.Green);
        System.Threading.Thread.Sleep(delay);
        await changeConsoleTextColor.WriteColoredText("Task 1 - Fibonacci Sequence: " + n2, ConsoleColor.Green);

        while (n3 < maxNumber)
        {
            System.Threading.Thread.Sleep(delay);
            n3 = n1 + n2;
            if (n3 > maxNumber)
            {
                break;
            }
            await changeConsoleTextColor.WriteColoredText("Task 1 - Fibonacci Sequence: " + n3, ConsoleColor.Green);
            n1 = n2;
            n2 = n3;
                
        }
        await changeConsoleTextColor.WriteColoredText("Task 1 - Fibonacci Sequence - Finished", ConsoleColor.Green);
    }
}