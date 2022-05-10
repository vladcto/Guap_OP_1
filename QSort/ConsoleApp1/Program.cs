using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Класс для работы с пользователем и форматирование входных/выходных данных.
class Program
{
    static void Main(string[] args)
    {
        string inpPath = @"D:\Projects\GUAP.OP.1\QSort\ConsoleApp1\test3.txt";
        using (StreamReader inpFile = new StreamReader(inpPath))
        {
            char[] textArr = inpFile.ReadToEnd().ToCharArray();
            IList<string> words = SelectWords(textArr);
            words.QuickSort();
            Console.WriteLine("res");
            for (int i = 0; i < 35; i++)
            {
                Console.WriteLine($"{i}:{words[i]}");
            }
        }
        Console.ReadKey();
    }

    static private List<string> SelectWords(IList<char> buffer)
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
}

//Класс для реализации алгоритмов (сортировки в данном случае)
static public class Algorithm
{
    static public void QuickSort(this IList<string> arraySegment)
    {
        Func<string, string, bool> func = (f, s) => string.Compare(f, s) > 0;
        QuickSort<string>(arraySegment, 0, arraySegment.Count - 1, func);
    }

    static public void QuickSort<T>(this IList<T> arraySegment, Func<T, T, bool> comparator)
    {
        QuickSort(arraySegment, 0, arraySegment.Count - 1,comparator);
    }

    static private void QuickSort<T>(IList<T> array, int first, int last,Func<T, T, bool> comparator)
    {
        T word = array[first];
        int f = first, l = last;
        do
        {
            while (comparator(word, array[f])) f++;
            while (comparator(array[l], word)) l--;

            if (f <= l)
            {
                T tmp = array[f];
                array[f] = array[l];
                array[l] = tmp;
                f++;
                l--;
            }
        } while (f < l);

        if (l > first)
        {
            QuickSort(array, first, l,comparator);
        }
        if (f < last)
        {
            QuickSort(array, f, last,comparator);
        }
    }
}
