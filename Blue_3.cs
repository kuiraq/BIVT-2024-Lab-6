using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _minutes;
            private int total;

            public string Name { get { return _name; } }
            public string Surname {  get { return _surname; } }
            public int[] PenaltyTimes
            {
                get
                {
                    if (_minutes == null) return null;
                    if (_minutes.Length == 0) return null;
                    int[] minutes = new int[_minutes.Length];
                    Array.Copy(_minutes, minutes, minutes.Length);
                    return minutes;
                }
            }
            public int TotalTime
            { 
                get
                {
                    if (_minutes == null || _minutes.Length == 0) return 0;
                    int total = 0;
                    for (int i = 0; i < _minutes.Length; i++)
                    {
                        total += _minutes[i];
                    }
                    return total;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_minutes == null || _minutes.Length == 0) return false;
                    foreach (int i in _minutes)
                    {
                        if (i == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _minutes = new int[0];
                total = 0;
                
            }

            public void PlayMatch(int time)
            {
                
                Array.Resize(ref _minutes, _minutes.Length + 1);
                _minutes[_minutes.Length-1] = time;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                Array.Sort(array, (a,b) => a.TotalTime.CompareTo(b.TotalTime));

            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {TotalTime}, Is expelled: {IsExpelled}");
            }

        }
        
    }
}
