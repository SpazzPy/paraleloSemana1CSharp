using System;
using System.Data.SQLite;
using System.Globalization;

namespace Tarea1Ejercicio1
{
    public class DatabaseUtils
    {
        private static string connectionString = "Data Source=C:\\Users\\frann\\OneDrive\\Desktop\\Paralelo\\Tarea 1\\Ejercicio 1\\Tarea1Ejercicio1\\DB\\simpledb.db;Version=3;";

        public static async Task InsertItem(int id, string firstName, string lastName, int age)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SQLiteCommand(
                    "INSERT INTO people (id, firstName, lastName, age, dob) VALUES (@id, @firstName, @lastName, @age, @dob)", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@dob", "");
                await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task ReadAllPeople()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SQLiteCommand(
                    "SELECT * FROM people", connection);

                using (var reader = command.ExecuteReader())
                {
                    bool printHeader = true;
                    while (reader.Read())
                    {
                        if (printHeader)
                        {
                            changeConsoleTextColor.WriteColoredText("Task 2 - People in the DataBase:", ConsoleColor.Yellow);
                            
                            string header = String.Format("{0,-5} {1,-20} {2,-20} {3,5} {4, 20}", "ID", "First Name", "Last Name", "Age", "DOB");
                            changeConsoleTextColor.WriteColoredText(header, ConsoleColor.Yellow);
                            printHeader = false;
                        }
                        string r = String.Format("{0,-5} {1,-20} {2,-20} {3,5} {4, 20}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
                        changeConsoleTextColor.WriteColoredText(r, ConsoleColor.Yellow);
                    }
                }
            }
        }
        // get the person by id
        public static Person ReadPerson(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                                       "SELECT * FROM people WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Person
                        {
                            ID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Age = reader.GetInt32(3),
                            DOB = reader.GetString(4)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static async Task UpdateDOB(int id, string dob)
        {
            DateTime birthDate = DateTime.ParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SQLiteCommand(
                    "UPDATE people SET age = @age, dob = @dob WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@dob", dob);
                await command.ExecuteNonQueryAsync();
            }
            changeConsoleTextColor.WriteColoredText("Task 4 - Updated Person " + id + " with date " + dob + " and age " + age, ConsoleColor.Magenta);
        }

        public static async Task DeleteItem()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SQLiteCommand(
                    "DELETE FROM people", connection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

public class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string DOB { get; set; }
}