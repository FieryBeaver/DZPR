using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "note.txt";
            string text = "";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string input = text;//{ if (a){} dlkkfd;dsjjdsffjsdsddfssfd;} for(;;){for(;;){ewrrwrw;}}//<< \"Size(;;;) of char: for forfor \" << for(int i=0;i<k;i--) sizeof(char) << \" byte\" << endl;cout << \"Size of int: \" << sizeof(int) << \" bytes\" << endl;       cout << \"Size of float: \" << sizeof(float) << \" bytes\" << endl; cout << \"Size of double: \" << sizeof(double) << \" bytes\" << endl;return 0; }}aaaaaaaa";
           
            string outStr = Regex.Replace(input, " *", " "); // можна і без regex але не в 1 стрічку а 10+-
            outStr =outStr.Replace(",", ", ");
            outStr = outStr.Replace(";", ";\n");    
            outStr = outStr.Replace("for", "\n\for");
            outStr = outStr.Replace("(", " (");
            outStr = outStr.Replace("/*", "\n/*");
            outStr = outStr.Replace("*/", "\n*/");
            outStr = outStr.Replace("do", "\ndo");

            int i = 0;
            string tabs = "\n";
            while (i < outStr.Length)
            {
                switch (outStr[i])
               {
                    case '{' :
                           tabs += "\t";
                           outStr = outStr.Insert(i-1, tabs);
                           i += tabs.Length+1;
                           outStr = outStr.Insert(i, "\n");
                           i--;
                        break;

                    case '}':

                        outStr = outStr.Insert(i-1, tabs);
                        i += tabs.Length;
                        outStr = outStr.Insert(i+1,"\n");
                        if (tabs !="")tabs =tabs.Remove(tabs.Length-1, 1);
                        
                        break;
                
                    case '(':
                        while (outStr[i]!=')')
                        {
                            if (outStr[i] == ';' && outStr[i + 1] == '\n') outStr = outStr.Remove(i + 1, 1);
                            else i++;
                           
                        }
                        break;


                    case '\n':
                        outStr = outStr.Insert(i+1, tabs+"\t");
                        i += tabs.Length;
                        break;
                }


                i++;
                //Console.WriteLine(i);
            }

            Console.WriteLine(outStr);
            Console.ReadKey();
        }

        






    }
}
