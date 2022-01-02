using System;
using System.Collections.Generic;

namespace PressGang.Core.Reports
{
    public static class Format
    {
        public static void AddListToQueue(List<IPressGangRecord> list, ref Queue<string> queue, bool sortFirst = false)
        {
            List<string> stringList = new();
            foreach (var entry in list)
            {
                stringList.Add(entry.Name);
            }
            AddListToQueue(stringList, ref queue, sortFirst);
        }

        public static void AddListToQueue(List<string> list, ref Queue<string> queue, bool sortFirst = false)
        {
            if (sortFirst)
            {
                list.Sort();
            }
            foreach (string entry in list)
            {
                queue.Enqueue(entry);
            }
        }
    }
}
