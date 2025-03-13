using System;
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
            private int total;

            public string Name { get { return _name; } }
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) != 2 || _marks.GetLength(1) != 5) return null;
                    int[,] marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            marks[i, j] = _marks[i, j];
                        }
                    }
                    return marks;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return 0;
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
                _marks = new int[2, 5];
                total = 0;
            }

            public void Jump(int[] result)
            {
                if (result == null || _marks == null ) return;
                for (int i = 0; i < 2; i++)
                {
                    bool isEmpty = true;

                    for (int j = 0; j < 5; j++)
                    {
                        if (_marks[i, j] != 0)
                        {
                            isEmpty = false;
                            break;
                        }
                    }
                    if (isEmpty)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            _marks[i,j] = result[j];
                        }
                        break;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (a,b) => b.TotalScore.CompareTo(a.TotalScore));
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {TotalScore}");
            }


        }
    }
}
