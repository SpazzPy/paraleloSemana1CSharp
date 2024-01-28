using System;
using Tarea1Ejercicio1;

public class task2
{
    public static async void AddRandomPeople(int toAdd = 20, int delay = 1)
    {
        string[] firstNames = new string[25]
        {
            "Adriana", "Adriano", "Agustina", "Agustín", "Alba", 
            "Alberto", "Alejandro", "Alicia", "Alma", "Alonso",
            "Antonio", "Ariadna", "Ariana", "Daniel", "Arturo",
            "Bruno", "Carla", "Carlos", "Carmen", "Celia",
            "Cesar", "Jose", "Sara", "Sofia", "Francisco"
        };
        string[] lastNames = new string[25]
        {
            "Garcia", "Castillo", "Rodriguez", "Martinez", "Sanchez",
            "Ruiz", "Hernandez", "Muñoz", "Navarro", "Torres",
            "Domínguez", "Delgado", "Ramos", "Morales", "Herrera",
            "Campos", "Blanco", "Suárez", "León", "Cabrera",
            "Molina", "Reyes", "Ortega", "Santos", "Castro"
        };
        await changeConsoleTextColor.WriteColoredText("Task 2 - Adding 20 people - Initiated.", ConsoleColor.Yellow);

        await changeConsoleTextColor.WriteColoredText("Task 2 - Deleting all people from database", ConsoleColor.Yellow);
        await DatabaseUtils.DeleteItem();

        Random rnd = new Random();

        for (int i = 0; i < toAdd; i++)
        {
            int age = rnd.Next(1, 100);
            int firstNameIndex = rnd.Next(0, firstNames.Length);
            int lastNameIndex = rnd.Next(0, lastNames.Length);
            string firstName = firstNames[firstNameIndex];
            string lastName = lastNames[lastNameIndex];
            await DatabaseUtils.InsertItem(i, firstName, lastName, age);
            await changeConsoleTextColor.WriteColoredText("Task 2 - Adding First name: " + firstName + ", Last name: " + lastName + ", and Age: " + age, ConsoleColor.Yellow);
            System.Threading.Thread.Sleep(delay);
        }
        DatabaseUtils.ReadAllPeople();
        await changeConsoleTextColor.WriteColoredText("Task 2 - Adding 20 people - Finished", ConsoleColor.Yellow);
    }
}