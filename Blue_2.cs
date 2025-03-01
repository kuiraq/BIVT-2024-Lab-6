﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;

            public string Name { get { return _name; } }
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) != _marks.GetLength(1)) return default(int[,]);
                    int[,] marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, marks, _marks.GetLength(0));
                    return marks;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            total += _marks[i, j];
                        }
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[,]
                {
                    {0,0,0,0,0 },
                    {0,0,0,0,0 }
                };

            }

            public void Jump(int[] result)
            {

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    if (_marks[i, 0] == 0)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            _marks[i, j] = result[j];
                        }
                        break;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (a,b) => b.TotalScore.CompareTo(a.TotalScore));
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {TotalScore}");
            }


        }
    }
}
