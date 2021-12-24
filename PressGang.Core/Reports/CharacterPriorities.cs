using System;
using System.Collections.Generic;
using PressGang.Core.DatabaseContext;
using PressGang.Core.StaticModels;
using PressGang.Core.UserModels;

namespace PressGang.Core.Reports
{
    public class CharacterPriorities
    {
        private readonly PressGangContext _pressGangContext;

        public CharacterPriorities(PressGangContext context, User user)
        {
            _pressGangContext = context;
            User = user;
        }

        public User User { get; set; }

        public List<Character> CharactersWithPrerequisites()
        {
            Dictionary<Character, int> characterGoals = DerivePriorities();
            SortedDictionary<int, List<Character>> priorities = InvertCharacterGoals(characterGoals);
            List<Character> cwp = new();
            foreach (KeyValuePair<int, List<Character>> kvp in priorities)
            {
                foreach(Character character in kvp.Value)
                {
                    cwp.Add(character);
                }
            }
            return cwp;
        }


        private SortedDictionary<int, List<Character>> InvertCharacterGoals(Dictionary<Character, int> characterGoals)
        {
            SortedDictionary<int, List<Character>> priorities = new();
            foreach (KeyValuePair<Character, int> kvp in characterGoals)
            {
                Character character = kvp.Key;
                int priority = kvp.Value;
                if (priorities.ContainsKey(priority))
                {
                    priorities[priority].Add(character);
                }
                else
                {
                    List<Character> characters = new();
                    characters.Add(character);
                    priorities.Add(priority, characters);
                }
            }
            return priorities;
        }

        private Dictionary<Character, int> DerivePriorities()
        {
            int priorCount = 0;
            Dictionary<Character, int> characterGoals = BaseList();
            while (characterGoals.Count > priorCount)
            {
                priorCount = characterGoals.Count;
                CalculateDependencies(ref characterGoals);
            }
            return characterGoals;
        }

        private Dictionary<Character, int> BaseList()
        {
            Dictionary<Character, int> characterGoals = new();
            foreach (Goal goal in User.Goals)
            {
                if (goal.GoalType == GoalType.YellowStarRank)
                {
                    characterGoals.Add(goal.Character, goal.Priority);
                }
            }
            return characterGoals;
        }

        private void CalculateDependencies(ref Dictionary<Character, int> characterGoals)
        {
            Dictionary<Character, int> originalGoals = new(characterGoals);
            foreach (KeyValuePair<Character, int> kvp in originalGoals)
            {
                Character character = kvp.Key;
                int priority = kvp.Value;
                if (!FivePrereqsInList(character, priority, characterGoals))
                {
                    AddPrereqsToList(character, priority, ref characterGoals);
                }
            }
        }

        private bool FivePrereqsInList(Character character, int priority, Dictionary<Character, int> characterGoals)
        {
            int prereqsInList = 0;
            foreach (Prerequisite prerequisite in character.Prerequisites)
            {
                Character dependsOn = prerequisite.DependsOn;
                if (characterGoals.ContainsKey(dependsOn))
                {
                    if (characterGoals[dependsOn] <= priority)
                    {
                        prereqsInList += 1;
                    }
                }
            }
            return prereqsInList >= 5;
        }

        private void AddPrereqsToList(Character character, int priority, ref Dictionary<Character, int> characterGoals)
        {
            foreach (Prerequisite prerequisite in character.Prerequisites)
            {
                Character dependsOn = prerequisite.DependsOn;
                if (characterGoals.ContainsKey(dependsOn))
                {
                    if (priority < characterGoals[dependsOn])
                    {
                        characterGoals[dependsOn] = priority;
                    }
                }
                else
                {
                    characterGoals.Add(dependsOn, priority);
                }
            }
        }

    }
}
