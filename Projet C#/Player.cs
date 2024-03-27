using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Player
    {
        Dictionary<string, Character> _characters;
        Character _currentCharacter;
        List<Tools> _tools;
        int _leftPos;
        int _topPos;

        public Dictionary<string, Character> ListCharacter { get => _characters; private set => _characters = value; }
        public List<Tools> ListTools { get => _tools; private set => _tools = value; }

        public int LeftPos { get => _leftPos; set => _leftPos = value; }
        public int TopPos { get => _topPos; set => _topPos = value; }
        public Character CurrentCharacter { get => _currentCharacter; set => _currentCharacter = value; }

        public Player(Dictionary<string, Character> characters, List<Tools> tools, (int, int) pos)
        {
            ListCharacter = characters;
            ListTools = tools;
            LeftPos = pos.Item1;
            TopPos = pos.Item2;
            CurrentCharacter = characters["Luffy"];
        }

        public event Action<bool> Move;
        public void MoveLeft(int nb)
        {
            List<string> collisions = GameManager.Instance.Maps["map1"].MapList;
            if (collisions[TopPos][LeftPos + nb] != '|') {
                LeftPos += nb;
                Move?.Invoke(true);
            }
            
        }
        public void MoveTop(int nb)
        {
            List<string> collisions = GameManager.Instance.Maps["map1"].MapList;
            if (collisions[TopPos + nb][LeftPos] != '|')
            {
                TopPos += nb;
                Move?.Invoke(true);
            }
        }
    }
}
