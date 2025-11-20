using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введіть текст для аналізу:");
        
        string input = Console.ReadLine();

        if (input == null)
        {
            Console.WriteLine("Помилка: Ви не ввели текст.");
            return;
        }

        // 🔥 Коректний патерн для emoji та спецсимволів (з сурогатними парами)
        string pattern = GetEmojiPattern();

        try
        {
            List<string> found = SearchMatches(input, pattern);

            if (found.Count == 0)
            {
                Console.WriteLine("\nУ тексті не знайдено емодзі чи спеціальних символів.");
            }
            else
            {
                Console.WriteLine("\nЗнайдені емодзі та спеціальні символи:");
                foreach (var item in found)
                    Console.WriteLine(item);

                Console.WriteLine($"\nВсього знайдено: {found.Count}");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Помилка у регулярному виразі:");
            Console.WriteLine(ex.Message);
        }
    }

    // ========================
    //     Метод пошуку
    // ========================
    static List<string> SearchMatches(string text, string pattern)
    {
        List<string> list = new();

        var matches = Regex.Matches(text, pattern, RegexOptions.Compiled);
        foreach (Match m in matches)
            list.Add(m.Value);

        return list;
    }

    // ========================
    //   Коректний emoji regex
    // ========================
    static string GetEmojiPattern()
    {
        // Використовуємо \UXXXXXXXX — вірний формат для C# Unicode escape.
        return
            @"([" +
            @"\u2600-\u26FF" +          // класичні символи
            @"\u2700-\u27BF" +          // стрілки, ✂ ✈ ✔
            @"]|" +
            @"[\U0001F300-\U0001F5FF]|" +   // 🌐 🌙 🌀
            @"[\U0001F600-\U0001F64F]|" +   // 😀😁🤣
            @"[\U0001F680-\U0001F6FF]|" +   // 🚀 🚗
            @"[\U0001F700-\U0001F77F]|" +   // алхімічні
            @"[\U0001F900-\U0001F9FF]|" +   // 🤖🧠🧩
            @"[\U0001FA70-\U0001FAFF]|" +   //🪐🪁🪀
            @"[©®™#])";                     // спецсимволи
    }
}
