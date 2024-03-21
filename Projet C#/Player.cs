using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Player
    {
        List<Character> _characters;
        List<Tools> _tools;
        int _leftPos;
        int _topPos;

        public List<Character> ListCharacter { get => _characters; private set => _characters = value; }
        public List<Tools> ListTools { get => _tools; private set => _tools = value; }

        public int LeftPos { get => _leftPos; private set => _leftPos = value; }
        public int TopPos { get => _topPos; private set => _topPos = value; }
        public Player()
        {
            ListCharacter = new List<Character>(); ;
            ListTools = new List<Tools>(); ;
            LeftPos = 6;
            TopPos = 10;
        }

        public event Action Move;
        public void MoveLeft(int nb)
        {
            List<string> collisions = GameManager.Instance.Maps["map1"].MapList;
            if (collisions[TopPos][LeftPos + nb] != '|') {
                LeftPos += nb;
                Move?.Invoke();
            }
            
        }
        public void MoveTop(int nb)
        {
            List<string> collisions = GameManager.Instance.Maps["map1"].MapList;
            if (collisions[TopPos + nb][LeftPos] != '|')
            {
                TopPos += nb;
                Move?.Invoke();
            }
        }
    }
}
