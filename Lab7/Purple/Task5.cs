using System.Runtime;
using System.Xml.Linq;

namespace Lab7.Purple
{
    public class Task5
    {
        public struct Response
        {
            private string? _animal;
            private string? _characterTrait;
            private string? _concept;

            public string? Animal => _animal;
            public string? CharacterTrait => _characterTrait;
            public string? Concept => _concept;

            public Response 
                (
                    string? animal,
                    string? characterTrait,
                    string? concept
                )
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null) return 0;
                int count = 0;
                if (questionNumber == 1)
                {
                    var answer = _animal;
                    foreach (var response in responses)
                        if (response._animal == answer)
                            count++;
                }
                if (questionNumber == 2)
                {
                    var answer = _characterTrait;
                    foreach (var response in responses)
                        if (response._characterTrait == answer)
                            count++;
                }
                if (questionNumber == 3)
                {
                    var answer = _concept;
                    foreach (var response in responses)
                        if (response._concept == answer)
                            count++;
                }
                return count;
            }
            public void Print()
            {
                System.Console.WriteLine("_________Response___________");
                System.Console.WriteLine($"Animal: {_animal}");
                System.Console.WriteLine($"CharacterTrait: {_characterTrait}");
                System.Console.WriteLine($"Concept: {_concept}");
            }
            private void AddAnimal(string animal) => _animal = animal;
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses
            {
                get
                {
                    var responses = new Response[_responses.Length];
                    for (int i =0;i<_responses.Length;i++)
                        responses[i] = _responses[i];
                    return responses;
                }
            }

            public Research (string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null) return;
                Array.Resize(ref _responses,_responses.Length+1);
                var response = new Response(answers[0],answers[1],answers[2]);
                _responses[^1] = response;
            }

            
            public  string[]  GetTopResponses(int question)
            {
                if (question < 1 || question > 3) return new string[0];              
                
                int count =0;
                int len = _responses.Length;
                var all = new string[0];

                if (question == 1)
                {
                    for (int i = 0; i < len; i++)
                    {
                        var value = _responses[i].Animal;
                        if (!string.IsNullOrEmpty(value))
                            count++;
                    }
                    Array.Resize(ref all,count);
                    count = 0;
                    for (int i = 0; i < len; i++)
                    {
                        var value = _responses[i].Animal;
                        if (!string.IsNullOrEmpty(value))
                            all[count++] = value;
                    }

                }

                else if (question == 2)
                {
                    for (int i = 0; i < len; i++)
                    {
                        var value = _responses[i].CharacterTrait;
                        if (!string.IsNullOrEmpty(value))
                           count++;
                    }
                    Array.Resize(ref all,count);
                    count = 0;
                    for (int i = 0; i < len; i++)
                    {
                        var value = _responses[i].CharacterTrait;
                        if (!string.IsNullOrEmpty(value))
                            all[count++] = value;
                    }
                }

                else 
                {
                    for (int i = 0; i < len; i++)
                    {
                        var value = _responses[i].Concept;
                        if (!string.IsNullOrEmpty(value))
                            count++;
                    }
                    Array.Resize(ref all,count);
                    count = 0;
                    for (int i = 0; i < len; i++)
                    {
                        var value = _responses[i].Concept;
                        if (!string.IsNullOrEmpty(value))
                            all[count++] = value;
                    }
                }

                var uniqe = all.Distinct().ToArray();
                var countUnique =new int[uniqe.Length];
                for (int i = 0;i<uniqe.Length;i++)
                    countUnique[i] = all.Where(a => a == uniqe[i]).Count();
                
                int l = 1;
                while (l < uniqe.Length)
                {
                    if (l==0 || countUnique[l-1]>=countUnique[l]) l++;
                    else
                    {
                        (countUnique[l-1],countUnique[l])=(countUnique[l],countUnique[l-1]);
                        (uniqe[l-1],uniqe[l])=(uniqe[l],uniqe[l-1]);
                        l--;
                    }
                }
                
                if (uniqe.Length<5) return uniqe;
                else
                {
                    var answer = new string[5];
                    for (int i = 0;i<5;i++)
                        answer[i] = uniqe[i];
                    return answer;
                }
            }

            public void Print()
            {
                System.Console.WriteLine("___________Research__________");
                System.Console.WriteLine($"Name: {_name}");
                for (int i = 0; i < _responses.Length; i++)
                    System.Console.WriteLine($"Response{i}: {_responses[i].Animal}; {_responses[i].CharacterTrait}; {_responses[i].Concept};");
                
            }
        }
    }
}
