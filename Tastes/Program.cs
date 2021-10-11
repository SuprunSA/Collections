using System;
using static System.Console;
using System.Collections.Generic;

namespace Tastes
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            Tasks4();
        }

        static void Tasks4()
        {
            var list = ReadInput();
            FindWhatLikeAll(list);
            var set = WhatLikeAtLeastOne(list);
            WhatLikeOnlyOne(list);
            HowManyUsersLike(list, set);
        }

        static List<List<string>> ReadInput()
        {
            var list = new List<List<string>>();
            while (true)
            {
                var separator = ", ";
                WriteLine("Введите любимки для пользователя {0}: ", count + 1);
                var input = new List<string>(ReadLine().Split(separator));
                if (input.Count == 1 && input[0] == "")
                {
                    break;
                }
                for (int i = 0; i < input.Count; i++)
                {
                    input[i].Replace(" ", "");
                }
                list.Add(input);
                count++;
            }
            return list;
        }

        static void FindWhatLikeAll(List<List<string>> list)
        {
            var allLike = new SortedSet<string>();
            var contain = true;
            for (int i = 0; i < list.Count; i++)
            {
                foreach (string taste in list[i])
                {
                    if (allLike.Contains(taste))
                    {
                        continue;
                    }
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (!list[j].Contains(taste))
                        {
                            contain = false;
                            break;
                        }
                    }
                    if (contain)
                    {
                        allLike.Add(taste);
                    }
                    contain = true;
                }
            }
            if (allLike.Count != 0)
            {
                WriteLine("Всем нравится: ");
                foreach (string taste in allLike)
                {
                    Write("{0} ", taste);
                }

            }
            else
            {
                WriteLine("Того, что нравится всем, нет");
            }
            WriteLine();
        }

        static void WhatLikeOnlyOne(List<List<string>> list)
        {
            var onlyOneLike = new List<SortedSet<string>>();
            for (int i = 0; i < list.Count; i++)
            {
                onlyOneLike.Add(new SortedSet<string>());
            }
            var contain = false;
            for (int i = 0; i < list.Count; i++)
            {
                foreach(string taste in list[i])
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Contains(taste) && i != j)
                        {
                            contain = true;
                            break;
                        }
                    }
                    if (!contain)
                    {
                        onlyOneLike[i].Add(taste);
                    }
                    contain = false;
                }
                WriteLine("Только пользователю №{0} нравится :", i + 1);
                foreach (string taste in onlyOneLike[i])
                {
                    Write("{0} ", taste);
                }
                WriteLine();
            }
        }

        static SortedSet<string> WhatLikeAtLeastOne(List<List<string>> list)
        {
            var atLeastOneLike = new SortedSet<string>();
            for (int i = 0; i < list.Count; i++)
            {
                foreach (string taste in list[i])
                {
                    atLeastOneLike.Add(taste);
                }
            }
            WriteLine("Хотя бы одному нравится: ");
            foreach (string taste in atLeastOneLike)
            {
                Write("{0} ", taste);
            }
            WriteLine();
            return atLeastOneLike;
        }

        static void HowManyUsersLike(List<List<string>> list, SortedSet<string> set)
        {
            var count = 0;
            foreach (string taste in set)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Contains(taste))
                    {
                        count++;
                    }
                }
                WriteLine("Количество пользователей, которым нравится {0}: {1}", taste, count);
                count = 0;
            }
            WriteLine();
        }
    }
}
