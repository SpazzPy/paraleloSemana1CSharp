using System;
using Tarea1Ejercicio1;

public class task3
{
    public static async void GenerateDates(int maxDates = 20, int delay = 1)
    {
        await changeConsoleTextColor.WriteColoredText("Task 3 - Generating Dates - Initiated.", ConsoleColor.Cyan);
        DateTime startDate = new DateTime(1990, 1, 1);
        DateTime endDate = DateTime.Now;

        Random random = new Random();

        await changeConsoleTextColor.WriteColoredText("Task 3 - Deleting all dates from json file", ConsoleColor.Cyan);
        JsonUtils.DeleteDatesJson();

        for (int i = 0; i < maxDates; i++)
        {
            // the random date must be from 1990-01-01 to 2030-01-01
            int range = (endDate - startDate).Days;
            string date = startDate.AddDays(random.Next(range)).ToString("yyyy-MM-dd");
            await changeConsoleTextColor.WriteColoredText("Task 3 - Date: " + date, ConsoleColor.Cyan);
            JsonUtils.InsertDatesJson(i, date);
            System.Threading.Thread.Sleep(delay);
        }

        JsonUtils.ReadDatesJson();

        await changeConsoleTextColor.WriteColoredText("Task 3 - Generating Dates - Finished", ConsoleColor.Cyan);
    }
}