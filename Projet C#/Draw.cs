using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Draw
    {
        public List<string> FileToText(string sFilePath)
        {
            List<string> lFileText = new List<string>();
            StreamReader oFile = new StreamReader(sFilePath);
            string line = oFile.ReadLine();
            if (oFile != null)
            {
                while (line != null)
                {
                    lFileText.Add(line);
                    line = oFile.ReadLine();

                }
                oFile.Close();
            }
            return lFileText;
        }

        public void DrawMap(List<string> lMap)
        {
            foreach (string l in lMap)
            {
                foreach (char m in l)
                {
                    switch (m)
                    {
                        case '_' or '|':
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case '*':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case '$':
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case '/':
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        case '§':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            break;
                        case '£':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
