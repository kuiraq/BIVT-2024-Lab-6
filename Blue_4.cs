﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name { get { return _name; } }
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return default(int[]);
                    int[] scores = new int[_scores.Length];
                    Array.Copy(_scores, scores, scores.Length);
                    return scores;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        total += _scores[i];
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (_scores == null || _scores.Length==0)
                {
                    _scores = new int[1] {result};
                }
                else
                {
                    Array.Resize(ref _scores, _scores.Length + 1);
                    _scores[_scores.Length - 1] = result;
                }
                
            }

            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
            }

        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int index;

            public string Name { get { return _name; } }
            public Team[] Teams
            {
                get
                {
                    Team[] teams = new Team[_teams.Length];
                    Array.Copy(_teams, teams, teams.Length);
                    return teams;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                index = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null || _teams.Length == 0) return;
                if (index >= _teams.Length) return;
                _teams[index] = team;
                index++;
            }
            public void Add(Team[] teamss)
            {
                if (teamss == null || _teams.Length == 0) return;
                foreach (var team in teamss)
                {
                    Add(team);  
                }
            }
            public  void Sort()
            {
                _teams = _teams.OrderByDescending(t => t.TotalScore).ToArray();
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                if (size <= 0) return default(Group);
                Group finalists = new Group("Финалисты");


                int half_size = size / 2;
                int i = 0, j = 0;
                while (i < half_size && j < half_size)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        finalists.Add(group1.Teams[i]);
                        i++;
                    }
                    else
                    {
                        finalists.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while (i < half_size)
                {
                    finalists.Add(group1.Teams[i]);
                    i++;
                }
                while (j < half_size)
                {
                    finalists.Add(group2.Teams[j]);
                    j++;
                }

                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                foreach (var team in _teams)
                {
                    team.Print();
                }
            }

        }
    }
}
