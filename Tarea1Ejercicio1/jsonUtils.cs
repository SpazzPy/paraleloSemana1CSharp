using System;
using System.IO;
using Newtonsoft.Json;

namespace Tarea1Ejercicio1
{
    public class JsonUtils
    {
        private static string path = "C:\\Users\\frann\\OneDrive\\Desktop\\Paralelo\\Tarea 1\\Ejercicio 1\\Tarea1Ejercicio1\\Tarea1Ejercicio1\\dates.json";
        public static void InsertDatesJson(int id, string date)
        {
            lock (path)
            {
                List<dynamic> dates;
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    dates = JsonConvert.DeserializeObject<List<dynamic>>(json) ?? new List<dynamic>();
                }
                else
                {
                    dates = new List<dynamic>();
                }

                var dateObject = new { ID = id, Date = date };
                dates.Add(dateObject);

                string newJson = JsonConvert.SerializeObject(dates, Formatting.Indented);
                File.WriteAllText(path, newJson);
            }
        }

        public static string ReadDatesJson(int? id = null)
        {
            if (File.Exists(path))
            {
                lock (path)
                {
                    string json = File.ReadAllText(path);
                    var dates = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    if (id.HasValue)
                    {
                        if (dates == null)
                        {
                            return "";
                        }
                        var date = dates.FirstOrDefault(d => d.ID == id.Value);
                        if (date != null)
                        {
                            return date.Date;
                        }
                    }
                    else
                    {
                        changeConsoleTextColor.WriteColoredText("Task 3 - Dates in the Json File:", ConsoleColor.Cyan);
                        bool printHeader = true;
                        foreach (var date in dates)
                        {
                            if (printHeader)
                            {
                                string header = String.Format("{0,-5} {1,-20}", "ID", "Date");
                                changeConsoleTextColor.WriteColoredText(header, ConsoleColor.Cyan);
                                printHeader = false;
                            }
                            string content = String.Format("{0,-5} {1,-20}", date.ID, date.Date);
                            changeConsoleTextColor.WriteColoredText(content, ConsoleColor.Cyan);

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(path + " does not exist.");
            }
            return "";
        }

        public static void DeleteDatesJson()
        {
            lock (path)
            {
                File.WriteAllText(path, System.String.Empty);
            }
        }
    }
}