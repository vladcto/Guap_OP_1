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
        string inpPath = @"D:\Projects\GUAP.OP.1\QSort\ConsoleApp1\test1.txt";
        using (StreamReader inpFile = new StreamReader(inpPath)) {
            char[] textArr = inpFile.ReadToEnd().ToCharArray();
            List<string> lol = SelectWords(textArr);
            Console.WriteLine(lol.Count);
        }
        Console.ReadKey();
    }

    static private List<string> SelectWords(char[] buffer)
    {
        List<string> res = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        foreach(char symb in buffer)
        {
            if (char.IsLetterOrDigit(symb))
            {
                stringBuilder.Append(symb);
            }
            else
            {
                if(stringBuilder.Length != 0)
                {
                    res.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
        }
        return res;
    }

}
