using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Votes { get { return _votes; } }

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            public int CountVotes(Response[] responses)
            {
                int count = 0;
                foreach (Response response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname) { count++; }

                }

                _votes = count;
                return _votes;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {Votes}");
            }
        }
    }
}
