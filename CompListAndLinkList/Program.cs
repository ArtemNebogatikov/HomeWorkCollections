using System.Diagnostics;

namespace CompListAndLinkList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(GetSolutionRoot(), "text1.txt");
            string str;
            var list = new List<string>();
            using (StreamReader sr = File.OpenText(path))
            {
                str = sr.ReadToEnd();
                var stopWatch = Stopwatch.StartNew();
                list.Add(str);
                var timeFromList = stopWatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Время List<T>: {timeFromList.ToString()}");

                var linkedList = new LinkedList<string>();
                stopWatch.Restart();
                linkedList.AddLast(str);
                var timeFromLinkList = stopWatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Время LinkedList<T>: {timeFromLinkList.ToString()}");

                char[] arr = str.ToCharArray();
                var listChar = new List<char>();
                stopWatch.Restart();
                foreach (char c in arr)
                {
                    listChar.Add(c);
                }
                var listTimeChar = stopWatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Время добавления массива char в List<T>: {listTimeChar}");
                var linkChar = new LinkedList<char>();
                stopWatch.Restart();
                foreach(char c in arr)
                {
                    linkChar.AddLast(c);
                }
                var linkTime = stopWatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Время добавления массива char в LinkedList<T>: {linkTime}");
            }
            Console.ReadLine();
        }
        static string GetSolutionRoot()
        {
            var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var fullname = Directory.GetParent(dir).FullName;
            var projectRoot = fullname.Substring(0, fullname.Length - 4);
            return projectRoot;
        }
    }
}