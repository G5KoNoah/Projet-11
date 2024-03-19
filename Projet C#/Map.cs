using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    class Map
    {

        public List<string> fileToText(string sFilePath)
        {
            List<string> lMap = new List<string>();
            StreamReader oFile = new StreamReader(sFilePath);
            string line = oFile.ReadLine();
            if (oFile != null)
            {
                while (line != null)
                {
                    lMap.Add(line);
                    line = oFile.ReadLine();
                    
                }
                oFile.Close();
            }
            return lMap;
        }

    }
}
