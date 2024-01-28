using System;

public class task5
{
    public static async void ReadMemoryRAM(int amount = 20, int delay = 1)
    {
        /*
         * 1mb = 1024 kb
         * 1kb = 1024 bytes
         
         */

        await changeConsoleTextColor.WriteColoredText("Task 5 - Read Memory RAM - Initiated.", ConsoleColor.Red);
        for (int i = 0; i < amount; i++)
        {
            long memoryInBytes = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            double memoryInMB = memoryInBytes / 1024.0 / 1024.0;
            await changeConsoleTextColor.WriteColoredText("Task 5 - Read Memory RAM for this console app: " + memoryInMB + " MB", ConsoleColor.Red);
            System.Threading.Thread.Sleep(delay);
        }
        await changeConsoleTextColor.WriteColoredText("Task 5 - Read Memory RAM - Finished", ConsoleColor.Red);
    }
}
