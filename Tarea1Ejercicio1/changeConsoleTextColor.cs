using System;

public class changeConsoleTextColor
{
    public static async Task WriteColoredText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        await Console.Out.WriteLineAsync(text);
        Console.ResetColor();
    }
}
