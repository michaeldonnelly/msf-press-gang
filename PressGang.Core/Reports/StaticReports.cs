using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public static class StaticReports
    {
        public static List<Character> Prerequisites(PressGangContext context, Character character)
        {
            List<Character> dependsOn = new();
            foreach (Prerequisite prerequisite in character.Prerequisites)
            {
                dependsOn.Add(prerequisite.DependsOn);
            }
            return dependsOn;
        }
    }
}
