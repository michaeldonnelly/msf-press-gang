using System;
using System.Collections.Generic;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class Format
    {
        public static void AddListToQueue(List<IPressGangRecord> list, ref Queue<string> queue, bool sort = false, bool bullets = false)
        {
            List<string> stringList = new();
            foreach (var entry in list)
            {
                stringList.Add(entry.Name);
            }
            AddListToQueue(stringList, ref queue, sort, bullets);
        }

        public static void AddListToQueue(List<string> list, ref Queue<string> queue, bool sort = false, bool bullets = false)
        {
            if (sort)
            {
                list.Sort();
            }
            foreach (string entry in list)
            {
                string line = entry;
                if (bullets)
                {
                    line = " - " + line;
                }
                queue.Enqueue(line);
            }
        }

        public static Dictionary<int, IGoal> GoalListToDictionary(List<IGoal> list)
        {
            Dictionary<int, IGoal> dictionary = new();
            foreach (IGoal entry in list)
            {
                dictionary.Add(entry.Priority, entry);
            }
            return dictionary;
        }
    }
}
