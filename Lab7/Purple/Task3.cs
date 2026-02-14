namespace Lab7.Purple
{
    public class Task3
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _topPlace;
            private int _totalMark;
            private int _markIndex;
            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    var marks = new double[7];
                    for (int i =0;i<7;i++)
                        marks[i] = _marks[i];
                    return marks;
                }
            }
            public int[] Places
            {
                get
                {
                    var places = new int[7];
                    for (int i =0;i<7;i++)
                        places[i] = _places[i];
                    return places;
                }
            }
            public int TopPlace => _places.Min();
            public double TotalMark => _marks.Sum();
            public int Score
            {
                get
                {
                    int sum=0;
                    for (int i =0;i<_places.Length;i++)
                        sum += _places[i];
                    return sum;
                }
            }
            // конструктор
            public Participant (string name,string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _markIndex = 0;
            }
            // методы
            public void Evaluate(double result)
            {
                if (_markIndex>=_marks.Length) return;
                if (result<0 || result>6) return;
                _marks[_markIndex] = result;
                _markIndex++;
            }
            private void Evaluate (double[] marks)
            {
                if (marks== null) return;
                for (int i =0;i<marks.Length;i++)
                    _marks[i] = marks[i];
                _markIndex = 7;
            }
            public  static  void SetPlaces(Participant[] participants)
            {
                if (participants== null) return;

                int cols = participants.Length;
                int rows = participants[0]._marks.Length;
                double[,] matrix = new double[rows,cols];
                for (int i = 0; i < cols; i++)
                    for (int j = 0; j < rows; j++)
                        matrix[j,i] = participants[i]._marks[j];

                for (int i = 0; i <rows; i++)
                {
                    int[] index = new int [cols];
                    for (int j =0;j<cols;j++)
                        index[j] = j;

                    int l =1;
                    while (l < cols)
                    {
                        if (l == 0 || matrix[i,l-1]>=matrix[i,l]) l++;
                        else
                        {
                            (matrix[i,l-1],matrix[i,l]) =(matrix[i,l],matrix[i,l-1]);
                            (index[l-1],index[l]) = (index[l],index[l-1]) ;
                            l--;
                        }
                    }

                    for (int j = 0; j < cols; j++)
                        participants[index[j]]._places[i] = j+1;
                }            
            }
            public static void Sort(Participant[] array)
            {
                Array.Sort(array, CompareParticipants);
            }

            private static int CompareParticipants(Participant a, Participant b)
            {
                int scoreCompare = a.Score.CompareTo(b.Score);
                if (scoreCompare != 0)
                    return scoreCompare;

                int topPlaceCompare = a.TopPlace.CompareTo(b.TopPlace);
                if (topPlaceCompare != 0)
                    return topPlaceCompare;

                return b.TotalMark.CompareTo(a.TotalMark);
            }

            public void Print()
            {
                System.Console.WriteLine("____________Participant____________");
                System.Console.WriteLine($"Name: {_name}; Surname: {_surname}");
                System.Console.WriteLine("Marks: ");
                System.Console.WriteLine(string.Join(" ",_marks));
                System.Console.WriteLine("Places: ");
                System.Console.WriteLine($"{string.Join(" ", _places),5}");
                System.Console.WriteLine($"TopPlace: {_topPlace}; TotalMark: {_totalMark}");
            }
        }
    }
}
