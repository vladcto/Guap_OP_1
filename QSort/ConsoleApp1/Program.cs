using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<int> a = new List<int> { 1, 2, 3 };
        ArraySegment<int> b = new ArraySegment<int>(a.ToArray(), 1, 1);
        IList<int> words1 = b;
        words1[0] = 3;
        string inpPath = @"D:\Projects\GUAP.OP.1\QSort\ConsoleApp1\test1.txt";
        using (StreamReader inpFile = new StreamReader(inpPath))
        {
            char[] textArr = inpFile.ReadToEnd().ToCharArray();
            IList<string> words = SelectWords(textArr);
            words = QuickSort(words);
            Console.WriteLine("res");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
        Console.ReadKey();
    }

    static private List<string> SelectWords(char[] buffer)
    {
        List<string> res = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (char symb in buffer)
        {
            if (char.IsLetterOrDigit(symb))
            {
                stringBuilder.Append(symb);
            }
            else
            {
                if (stringBuilder.Length != 0)
                {
                    res.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
        }
        return res;
    }

    static private IList<string> QuickSort(IList<string> arraySegment)
    {
        if (arraySegment.Count <= 1) return arraySegment;
        string word = arraySegment[0];
        IList<string> mid = arraySegment.Where(x => word == x).ToList();
        IList<string> left = arraySegment.Where(x => string.Compare(word, x) > 0).ToList();
        IList<string> right = arraySegment.Where(x => string.Compare(word, x) < 0).ToList();
        IList<string> res = new List<string>();
        res = res.Concat(QuickSort(left)).ToList();
        res = res.Concat(mid).ToList();
        res = res.Concat(QuickSort(right)).ToList();
        return res;

        /*
        if (arraySegment.Count <= 1) return;

        int i = left, j = right;
        do
        {
            while (String.Compare(word, arraySegment[i]) >= 0) i++;
            while (String.Compare(word, arraySegment[j]) <= 0) j--;

            if (i <= j)
            {
                string tmp = arraySegment[i];
                Console.WriteLine(i);
                arraySegment[i] = arraySegment[j];
                arraySegment[j] = tmp;
            }

        } while (i <= j);

        //Рекурсивные вызовы, если осталось, что сортировать
        if (j > 0)
        {
            QuickSort(arraySegment, j + 1, right);
        }
        if (i < arraySegment.Count)
        {
            QuickSort(arraySegment, left, i);
        }
        */
    }
}
