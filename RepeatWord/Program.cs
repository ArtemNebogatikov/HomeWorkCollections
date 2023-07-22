using System.IO;

namespace RepeatWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(GetSolutionRoot(), "text1.txt");
            string str;
            using (StreamReader sr = File.OpenText(path))
            {
                str = sr.ReadToEnd();
                var noPunctuationText = new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
                var strWord = noPunctuationText.Split();
                List<string> words = new List<string>(strWord);
                List<string> wordWithoutSpace = new List<string>(strWord);
                foreach (var word in words)
                {
                    if (word == "")
                    {
                        wordWithoutSpace.Remove(word);
                    }
                }
                var set = new HashSet<string>();
                var wordsRepeat = new Dictionary<string, int>();
                int count = 1;
                foreach (var item in wordWithoutSpace)
                {
                    if (!set.Add(item))
                    {
                        if (!wordsRepeat.ContainsKey(item))
                        {
                            wordsRepeat.Add(item, count + 1);
                        }
                        else
                        {
                            wordsRepeat[item]++;
                        }
                    }
                }
                foreach (var word in wordsRepeat)
                {
                    if(word.Value > 10) 
                    {
                        Console.WriteLine(word.Key + " " + word.Value);
                    }
                }
                
                           
            }
            Console.ReadKey();
            static string GetSolutionRoot()
            {
                var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
                var fullname = Directory.GetParent(dir).FullName;
                var projectRoot = fullname.Substring(0, fullname.Length - 4);
                return projectRoot;
            }
        }
    }
}