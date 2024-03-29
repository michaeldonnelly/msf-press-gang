﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public List<Character> Characters()
        {
            Dictionary<Character, int> characterGoals = BaseList();
            SortedDictionary<int, List<Character>> priorities = InvertCharacterGoals(characterGoals);
            List<Character> cl = DictToList<Character>(priorities);
            return cl;
        }

        public List<Character> CharactersWithPrerequisites()
        {
            Dictionary<Character, int> characterGoals = DerivePriorities();
            SortedDictionary<int, List<Character>> priorities = InvertCharacterGoals(characterGoals);
            List<Character> cl = DictToList<Character>(priorities);
            return cl;
        }

        public Queue<string> Farm()
        {
            Queue<string> farmGuide = new();
            farmGuide.Enqueue("Priority  Character             Location");
            farmGuide.Enqueue("--------  --------------------  --------------------");

            SortedDictionary<int, List<YellowStarGoal>> goals = Goals();
            foreach(KeyValuePair<int, List<YellowStarGoal>> kvp in goals)
            {
                int priority = kvp.Key;
                foreach(YellowStarGoal yellowStarGoal in kvp.Value)
                {
                    Character character = yellowStarGoal.Character;
                    Resource shard = character.Shard;
                    foreach (Opportunity opportunity in shard.Opportunities)
                    {
                        Location location = opportunity.Location;
                        string line = String.Format("{0,8}  {1,-20}  {2,-20}",
                            priority,
                            character.Name,
                            location.ToString());
                        farmGuide.Enqueue(line);
                    }
                }               
            }
            return farmGuide;
        }

        private SortedDictionary<int, List<YellowStarGoal>> Goals()
        {
            SortedDictionary<int, List<YellowStarGoal>> yellowStarGoals = new();
            foreach (YellowStarGoal yellowStarGoal in User.YellowStarGoals)
            {
                int priority = yellowStarGoal.Priority;
                if (yellowStarGoals.ContainsKey(priority))
                {
                    yellowStarGoals[priority].Add(yellowStarGoal);
                }
                else
                {
                    List<YellowStarGoal> l = new();
                    l.Add(yellowStarGoal);
                    yellowStarGoals.Add(priority, l);
                }

            }
            return yellowStarGoals;
        }

        public YellowStarGoal Add(Character character, int priority)
        {
            Dictionary<Character, int> characterGoals = BaseList();
            YellowStarGoal yellowStarGoal;
            if (characterGoals.ContainsKey(character))
            {
                yellowStarGoal = User.YellowStarGoals.Where(g => g.Character == character).First();
                if (yellowStarGoal.Priority != priority)
                {
                    yellowStarGoal.Priority = priority;
                }
            }
            else
            {
                yellowStarGoal = new(User, character, priority);
                _pressGangContext.Add(yellowStarGoal);
            }
            _pressGangContext.SaveChanges();
            return yellowStarGoal;
        }

        private List<T> DictToList<T>(SortedDictionary<int, List<T>> d)
        {

            List<T> l = new List<T>();
            foreach (KeyValuePair<int, List<T>> kvp in d)
            {
                foreach (T entry in kvp.Value)
                {
                    l.Add(entry);
                }
            }
            return l;
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
            foreach (YellowStarGoal yellowStarGoal in User.YellowStarGoals)
            {

                    characterGoals.Add(yellowStarGoal.Character, yellowStarGoal.Priority);
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
            foreach (PrerequisiteCharacter prerequisite in character.PrerequisiteCharacters)
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
            // TODO: use StaticReports.Prerequisites
            foreach (PrerequisiteCharacter prerequisite in character.PrerequisiteCharacters)
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
