using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Player
    {
        Dictionary<string, Character> _character;
        Dictionary<string, Objects> _objects;
        Dictionary<string, Objects> _currentObjects;
        int _LeftPos;
        int _TopPos;

        public Dictionary<string, Character> ListCharacter { get => _character; }

        public int LeftPos { get => _LeftPos; private set => _LeftPos = value; }
        public int TopPos { get => _TopPos; private set => _TopPos = value; }
        public Dictionary<string, Objects> Objects { get => _objects; set => _objects = value; }
        public Dictionary<string, Objects> CurrentObjects { get => _currentObjects; set => _currentObjects = value; }

        public Player(Dictionary<string, Character> characters, Dictionary<string, Objects> objects)
        {
            _character = characters;
            CurrentObjects = new Dictionary<string, Objects>();
            Objects = objects;
            _LeftPos = 6;
            _TopPos = 10;
        }

        public event Action Move;
        public event Action UseItem;
        public void MoveLeft(int nb)
        {
            List<string> collisions = GameManager.Instance.ListMap[0].MapList;
            if (collisions[TopPos][LeftPos + nb] != '|') {
                LeftPos += nb;
                Move?.Invoke();
            }
            

        }
        public void MoveTop(int nb)
        {
            List<string> collisions = GameManager.Instance.ListMap[0].MapList;
            if (collisions[TopPos + nb][LeftPos] != '|')
            {
                TopPos += nb;
                Move?.Invoke();
            }
            
        }

        public void Item(string name, Character character)
        {
            if(Objects.ContainsKey(name))
            {
                UseItem?.Invoke();
                if (Objects[name].UseTurn != -1)
                {
                    CurrentObjects[name] = Objects[name];
                }
                Objects[name].Use(character);
                Objects.Remove(name);
            }

        }

        public void ItemTime()
        {
            foreach(var item in CurrentObjects)
            {
                if(item.Value.UseTurn == 0)
                {
                    CurrentObjects.Remove(item.Key);
                    item.Value.DeleteStats();
                }else 
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
