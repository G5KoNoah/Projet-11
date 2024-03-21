using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Parser
    {
        public Parser() { }

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
    }
}
