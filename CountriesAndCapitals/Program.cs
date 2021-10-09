using System;
using static System.Console;
using System.Collections.Generic;

namespace CountriesAndCapitals
{
    class Program
    {
        /*static int maxRangeCountry = 14;
        static int maxRangeCapital = 10;*/
        static SortedDictionary<string, string> country_capital = new SortedDictionary<string, string> { { "Австрия", "Вена" } ,
            { "Бельгия", "Брюссель" },
            { "Болгария", "София" },
            { "Ватикан", "Ватикан" },
            { "Великобритания", "Лондон" },
            { "Венгрия", "Будапешт" },
            { "Германия", "Берлин" },
            { "Греция", "Афины" },
            { "Дания", "Копенгаген" },
            { "Исландия", "Рейкьявик" },
            { "Испания", "Мадрид" },
            { "Румыния", "Бухарест" },
            { "Нидерланды", "Амстердам" },
            { "Норвегия", "Осло" },
            { "Украина", "Киев" },
            { "Финляндия", "Хельсинки" },
            { "Франция", "Париж" },
            { "Хорватия", "Загреб" },
            { "Швейцария", "Берн" },
            { "Швеция", "Стокгольм" },
            { "Эстония", "Таллин" },
            { "Ирландия", "Дублин" },
            { "Италия", "Рим" },
            { "Мальта", "Валлетта" }
        };
        static void Main(string[] args)
        {
            SetWindowSize(150, 50);
            DictionaryOperations();
        }

        static void DictionaryOperations()
        {
            while (true)
            {
                ShowMenu();
                /*maxRangeCountry = FindMaxRangeCountry(maxRangeCountry);
                maxRangeCapital = FindMaxRangeCapital(maxRangeCapital);*/
                var key = ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.F1:
                        return;
                    case ConsoleKey.F2:
                        Clear();
                        WriteLine("Вывод списка на экран: ");
                        PrintDictionary(country_capital);
                        ContinueOrWait();
                        break;
                    case ConsoleKey.F3:
                        Clear();
                        WriteLine("Количество заполненных стран: ");
                        WriteLine(country_capital.Count);
                        ContinueOrWait();
                        break;
                    case ConsoleKey.F4:
                        Clear();
                        WriteLine("Поиск по стране: ");
                        CountryFind();
                        ContinueOrWait();
                        break;
                    case ConsoleKey.F5:
                        Clear();
                        WriteLine("Поиск по столице: ");
                        CapitalFind();
                        ContinueOrWait();
                        break;
                    case ConsoleKey.F6:
                        Clear();
                        WriteLine("Добавление столицы: ");
                        AddCapital();
                        break;
                    case ConsoleKey.F7:
                        Clear();
                        WriteLine("Удаление страны: ");
                        DeleteCountry();
                        break;
                }
            }
        }

        static void PrintDictionary(SortedDictionary<string, string> country)
        {
            foreach (KeyValuePair<string, string> kvp in country)
            {
                WriteLine("{0, 20} \t {1, 20}", kvp.Key, kvp.Value);
            }
        }

        static void CountryFind()
        {
            WriteLine("Введите страну: ");
            var country = ReadLine();
            if (country_capital.ContainsKey(country))
            {
                WriteLine("Столица страны {0}: {1}", country, country_capital[country]);
            }
            else
            {
                WriteLine("Такой страны нет в списке");
            }
        }

        static void CapitalFind()
        {
            WriteLine("Введите столицу: ");
            var capital = ReadLine();
            if (country_capital.ContainsValue(capital))
            {
                foreach (string country in country_capital.Keys)
                {
                    if (country_capital[country] == capital)
                    {
                        WriteLine("{0} - столица страны {1}", capital, country);
                    }
                }
            }
            else
            {
                WriteLine("Такой столицы нет среди значений");
            }
        }

        static void AddCapital()
        {
            var capital = "";
            WriteLine("Введите страну, столицу для которой хотите добавить: ");
            var country = ReadLine();
            if (country_capital.ContainsKey(country))
            {
                WriteLine("Такая страна уже добавлена, изменить значение её столицы? ");
                WriteLine("Нажмите Д, чтобы сделать замену, или другую кнопку чтобы продолжить");
                var key = ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.L:
                        WriteLine();
                        WriteLine("Введите столицу для замены: ");
                        capital = ReadLine();
                        country_capital[country] = capital;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                WriteLine("Введите столицу: ");
                capital = ReadLine();
                country_capital.Add(country, capital);
            }
        }

        static void DeleteCountry()
        {
            WriteLine();
            var country = ReadLine();
            country_capital.Remove(country);
        }

        static void ContinueOrWait()
        {
            WriteLine("Нажмите любую клавишу чтобы продолжить");
            var key = ReadKey().Key;
            switch (key)
            {
                default:
                    return;
            }
        }

        static void ShowMenu()
        {
            Clear();
            BackgroundColor = ConsoleColor.DarkBlue ;
            for (int i = 0; i < WindowWidth; i++) { 
                Write(" "); 
            }
            CursorLeft = 0;
            PrintMenuCommand("F1", "Выход");
            PrintMenuCommand("F2", "Вывести список");
            PrintMenuCommand("F3", "Вывести количество");
            PrintMenuCommand("F4", "Поиск по стране");
            PrintMenuCommand("F5", "Поиск по столице");
            PrintMenuCommand("F6", "Добавление столиц");
            PrintMenuCommand("F7", "Удаление стран");
            WriteLine();
            ResetColor();
        }

        /*static int FindMaxRangeCountry(int range) 
        {
            foreach (string country in country_capital.Keys)
            {
                if (range < country.Length)
                {
                    range = country.Length;
                }
            }
            return range;
        }

        static int FindMaxRangeCapital(int range)
        {
            foreach (string capital in country_capital.Values)
            {
                if (range < capital.Length)
                {
                    range = capital.Length;
                }
            }
            return range;
        }*/

        static void PrintMenuCommand(string key, string action)
        {
            ForegroundColor = ConsoleColor.Red;
            Write(key);
            ForegroundColor = ConsoleColor.Green;
            Write(" " + action + " ");
        }
    }
}
