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
            QuickSort(words);
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

    static private void QuickSort(IList<string> arraySegment)
    {
        QuickSort(arraySegment, 0, arraySegment.Count - 1);
    }

    static private void QuickSort(IList<string> array,int first,int last)
    {
        string word = array[first];
        int f = first, l = last;
        do
        {
            while (String.Compare(word, array[f]) > 0) f++;
            while (String.Compare(word, array[l]) < 0) l--;

            if (f <= l)
            {
                string tmp = array[f];
                Console.WriteLine(f);
                array[f] = array[l];
                array[l] = tmp;
                f++;
                l--;
            }

        } while (f < l);

        if (l > first)
        {
            QuickSort(array, first, l);
        }
        if (f < last)
        {
            QuickSort(array, f, last);
        }
    }
}
