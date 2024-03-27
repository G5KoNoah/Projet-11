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
        Dictionary<string, Object> _objects;
        Dictionary<string, Object> _currentObjects;
        int _leftPos;
        int _topPos;

        public Dictionary<string, Character> ListCharacter { get => _characters; private set => _characters = value; }

        public int LeftPos { get => _leftPos; set => _leftPos = value; }
        public int TopPos { get => _topPos; set => _topPos = value; }
        public Character CurrentCharacter { get => _currentCharacter; set => _currentCharacter = value; }
        public Dictionary<string, Object> CurrentObjects { get => _currentObjects; set => _currentObjects = value; }
        public Dictionary<string, Object> Objects { get => _objects; set => _objects = value; }

        public Player(Dictionary<string, Character> characters, (int, int) pos)
        {
            ListCharacter = characters;
            Objects = new Dictionary<string, Object> { };
            LeftPos = pos.Item1;
            TopPos = pos.Item2;
            CurrentCharacter = characters["Luffy"];
            CurrentObjects = new Dictionary<string, Object> { };
        }

        public event Action<bool> Move;
        public event Action UseItem;
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

        public void Item(string name, Character character)
        {
            if (Objects.ContainsKey(name))
            {
                UseItem?.Invoke();
                if (Objects[name].UseTurn != -1)
                {
                    CurrentObjects[name] = Objects[name];
                }
                if (Objects[name].Use(character))
                {
                    Objects.Remove(name);
                }

            }

        }

        public void ItemTime()
        {
            foreach (var item in CurrentObjects)
            {
                if (item.Value.UseTurn == 0)
                {
                    CurrentObjects.Remove(item.Key);
                    item.Value.DeleteStats();
                }
                else
                {
                    item.Value.UseTurn--;
                }
            }
        }

        public void ItemAllDestroy()
        {
            foreach (var item in CurrentObjects)
            {

                item.Value.DeleteStats();

            }
        }
    }
}
