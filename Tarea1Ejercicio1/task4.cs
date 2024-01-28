using System;
using Tarea1Ejercicio1;

public class task4
{
    public static async void UpdatePersonDOB(int maxPeople = 20, int delay = 1)
    {
        await changeConsoleTextColor.WriteColoredText("Task 4 - Update Person DOB - Initiated.", ConsoleColor.Magenta);

        int currentID = 0;
        int currentAttempt = 0;
        int maxAttempts = 50;
        int waitTime = 100;

        while (currentAttempt < maxAttempts && currentID < maxPeople)
        {
            string date = JsonUtils.ReadDatesJson(currentID);
            if (date == "")
            {
                await changeConsoleTextColor.WriteColoredText("Task 4 - Update Person DOB - Date empty, trying again in " + waitTime + " milliseconds. Attempt number " + (currentAttempt + 1), ConsoleColor.Magenta);
                System.Threading.Thread.Sleep(waitTime);
                currentAttempt++;
                continue;
            }

            Person? p = DatabaseUtils.ReadPerson(currentID);
            if (p == null)
            {
                await changeConsoleTextColor.WriteColoredText("Task 4 - Update Person DOB - Person not found, trying again in " + waitTime + " milliseconds. Attempt number " + (currentAttempt + 1), ConsoleColor.Magenta);
                System.Threading.Thread.Sleep(waitTime);
                currentAttempt++;
                continue;
            }

            await DatabaseUtils.UpdateDOB(currentID, date);
            currentID++;
            System.Threading.Thread.Sleep(delay);
        }
        await changeConsoleTextColor.WriteColoredText("Task 4 - Update Person DOB - Finished", ConsoleColor.Magenta);
    }
}