using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

//Класс для работы с пользователем и форматирование входных/выходных данных.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь до исходного файл:");
        string inpPath = Console.ReadLine();
        IList<string> words;
        using (StreamReader inpFile = new StreamReader(inpPath))
        {
            char[] textArr = inpFile.ReadToEnd().ToCharArray();
            words = SelectWords(textArr);
        }

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        words.QuickSort();
        stopWatch.Stop();
        double seconds = stopWatch.Elapsed.TotalSeconds;

        Console.WriteLine("Введите путь до файла-результата:");
        WriteResult(Console.ReadLine(), words);
        Console.WriteLine("Введите путь до файла-аналитики:");
        WriteAnalysis(Console.ReadLine(), words, seconds);
    }

    static public void WriteAnalysis(string filePath, in IList<string> input, double secs)
    {
        using (StreamWriter outFile = new StreamWriter(filePath))
        {
            outFile.WriteLine($"Затрачено секунд = {secs}");
            long symbols = input.Aggregate<string, long>(0, (aggr, word) => aggr += word.Length);
            outFile.WriteLine($"Количество символов = {symbols}");
            outFile.WriteLine($"Количество слов = {input.Count}");

            var groupedResult = input.GroupBy(word => char.ToLower(word[0]))
                .Select(group => $"{group.Key} = {group.Count()}");
            foreach (string formatedRes in groupedResult)
            {
                outFile.WriteLine(formatedRes);
            }
            outFile.Write("Количество слов на остальные буквы алфавита = 0");
        }
    }

    static public void WriteResult(string filePath, in IList<string> input)
    {
        using (StreamWriter outFile = new StreamWriter(filePath))
        {
            var groupedResult = input.GroupBy(word => char.ToLower(word[0]))
                .Select(group => string.Join(" ", group));
            foreach (string formatedRes in groupedResult)
            {
                outFile.WriteLine(formatedRes);
            }
        }
    }

    static private List<string> SelectWords(IList<char> buffer)
    {
        List<string> res = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (char symb in buffer)
        {
            if (symb == ',' && int.TryParse(stringBuilder.ToString(), out _))
            {
                stringBuilder.Append(symb);
            }
            else if (char.IsLetterOrDigit(symb))
            {
                stringBuilder.Append(symb);
            }
            else if (stringBuilder.Length != 0)
            {
                res.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
        }
        if (stringBuilder.Length != 0)
        {
            res.Add(stringBuilder.ToString());
        }
        return res;
    }
}

//Класс для реализации алгоритмов (сортировки в данном случае)
static public class Algorithm
{
    static public void QuickSort(this IList<string> list)
    {
        Func<string, string, bool> func = (f, s) => string.Compare(f, s) > 0;
        QuickSort(list, 0, list.Count - 1, func);
    }

    static public void QuickSort<T>(this IList<T> list, Func<T, T, bool> comparator)
    {
        QuickSort(list, 0, list.Count - 1, comparator);
    }

    static private void QuickSort<T>(IList<T> array, int first, int last, Func<T, T, bool> comparator)
    {
        T key = array[first];
        int f = first, l = last;
        do
        {
            while (comparator(key, array[f])) f++;
            while (comparator(array[l], key)) l--;

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
            QuickSort(array, first, l, comparator);
        }
        if (f < last)
        {
            QuickSort(array, f, last, comparator);
        }
    }
}
