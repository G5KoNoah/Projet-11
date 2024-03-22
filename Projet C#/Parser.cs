using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public struct InfoText
    {
        List<string> _mapOrCharacter;
        (int, int) _pLayerPos;

        public List<string> MapOrCharacter { get => _mapOrCharacter; set => _mapOrCharacter = value; }
        public (int, int) PLayerPos { get => _pLayerPos; set => _pLayerPos = value; }
    }
    public class Parser
    {
        public Parser() { }

        public List<string> FileToText(string sFilePath)
        {
            List<string> lFileText = new List<string>();
            StreamReader oFile = new StreamReader(sFilePath);
            if (oFile != null)
            {
                string line = oFile.ReadLine();
                while (line != null)
                {
                    lFileText.Add(line);
                    line = oFile.ReadLine();

                }
                oFile.Close();
            }
            return lFileText;
        }

        public InfoText FileToTextTest(string sFilePath)
        {
            InfoText infoText = new InfoText();
            infoText.MapOrCharacter = new List<string>();
            StreamReader oFile = new StreamReader(sFilePath);
            if (oFile != null)
            {
                string line = oFile.ReadLine();
                string state = "";
                while (line != null)
                {
                    if (line.StartsWith("Player") || line.StartsWith("Map") || line.StartsWith("Character"))
                    {
                        state = line;
                        line = oFile.ReadLine();
                        continue;
                    }
                    switch (state)
                    {
                        case "Player":
                            var pos = line.Split(' ');
                            int.TryParse(pos[0], out int left);
                            int.TryParse(pos[1], out int top);
                            infoText.PLayerPos = (left, top);
                            break;
                        case "Map" or "Character":
                            infoText.MapOrCharacter.Add(line);
                            break;
                    }
                    
                    line = oFile.ReadLine();
                }
                oFile.Close();
            }
            return infoText;
        }
    }
}
