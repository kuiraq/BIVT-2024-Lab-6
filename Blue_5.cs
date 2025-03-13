using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name { get { return _name; } }
            public int Place { get { return _place; } }

            public string Surname { get { return _surname; } }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place > 0) return;
                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Место: {Place}");
            }

        }
        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, copy, _sportsmen.Length);
                    return copy;
                }
            }

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                    int total_points = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        switch (_sportsmen[i].Place)
                        {
                            case 1:
                                total_points += 5;
                                break;
                            case 2:
                                total_points += 4;
                                break;
                            case 3:
                                total_points += 3;
                                break;
                            case 4:
                                total_points += 2;
                                break;
                            case 5:
                                total_points += 1;
                                break;
                            default:
                                break;

                        }
                    }
                    return total_points;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                    int min_place = 18;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place > 0 && _sportsmen[i].Place < min_place)
                        {
                            min_place = _sportsmen[i].Place;
                        }
                    }
                    return min_place;
                }
            }

            public Team (string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
            }

                
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _sportsmen.Length == 0) return;
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    if (_sportsmen[i].Name == null)
                    {
                        _sportsmen[i] = sportsman;
                        break;
                    }

                }

            }
            public void Add(Sportsman[] sportsmanchik)
            {
                if (sportsmanchik == null || sportsmanchik.Length == 0) return;
                if (_sportsmen == null || _sportsmen.Length == 0) return;
                foreach (var sportsman in sportsmanchik)
                {
                    Add(sportsman);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore || (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace))
                        {
                            var temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }

            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}, Их балл: {SummaryScore}, Лучшее место: {TopPlace}");
            }
        }

        
    }
}
