using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть текст:");
        string input = Console.ReadLine();

        // 🔥 Регулярний вираз для емодзі + спецсимволів
        string pattern =
            @"[\u2600-\u26FF" +        // ☀★✈♻
            @"\u2700-\u27BF" +         // ✂✈✉✔
            @"\u1F300-\u1F5FF" +       // 🌐🌙🔥
            @"\u1F600-\u1F64F" +       // 😀😁🤣
            @"\u1F680-\u1F6FF" +       // 🚀🚗🚲
            @"\u1F700-\u1F77F" +       // алхімічні
            @"\u1F900-\u1F9FF" +       // 🤖🧠🧩
            @"\u1FA70-\u1FAFF" +       // 🪐🪁🪀
            @"\p{So}]+|[#©®™]";         // спецсимволи ©®™#

        MatchCollection matches = Regex.Matches(input, pattern);

        Console.WriteLine("\nЗнайдені емодзі та спецсимволи:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }

        Console.WriteLine($"\nВсього знайдено: {matches.Count}");
    }
}
