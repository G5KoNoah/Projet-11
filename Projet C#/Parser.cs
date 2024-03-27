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
        List<(int, int)> _posPNJ;
        (int, int) _objectPos;

        public List<string> MapOrCharacter { get => _mapOrCharacter; set => _mapOrCharacter = value; }
        public (int, int) PLayerPos { get => _pLayerPos; set => _pLayerPos = value; }
        public List<(int, int)> PosPNJ { get => _posPNJ; set => _posPNJ = value; }
        public (int, int) ObjectPos { get => _objectPos; set => _objectPos = value; }
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
            infoText.PosPNJ = new List<(int, int)>();
            StreamReader oFile = new StreamReader(sFilePath);
            if (oFile != null)
            {
                string line = oFile.ReadLine();
                string state = "";
                while (line != null)
                {
                    if (line.StartsWith("Player") || line.StartsWith("Map") || line.StartsWith("PNJ") || line.StartsWith("Object"))
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
                        case "Map":
                            infoText.MapOrCharacter.Add(line);
                            break;
                        case "PNJ":
                            var posPNJ = line.Split(' ');
                            int.TryParse(posPNJ[0], out int leftPNJ);
                            int.TryParse(posPNJ[1], out int topPNJ);
                            infoText.PosPNJ.Add((leftPNJ, topPNJ));
                            break;
                        case "Object":
                            var posObject = line.Split(' ');
                            int.TryParse(posObject[0], out int leftObject);
                            int.TryParse(posObject[1], out int topObject);
                            infoText.ObjectPos = (leftObject, topObject);
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
