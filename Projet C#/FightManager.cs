using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class FightManager
    {

        Character _character;
        string[] _choix;
        public FightManager() {
            Choix = new string[] { "attaquer", "fuire", "objet", "personnage" };
        }


        public Character Character { get => _character; set => _character = value; }
        public string[] Choix { get => _choix; set => _choix = value; }

        public void MainLoop(Player player ,Enemy enemy)
        {

            Character = player.ListCharacter["Luffy"];
            GameManager.Instance.Draw.Fight(player, enemy, GameManager.Instance.Input.Select, Character);
            while (true)
            {
                GameManager.Instance.Input.InputFight(player, enemy, Character);

                if (enemy.Character.PV == 0)
                {
                    Console.WriteLine("c'est finit");
                    
                }

                

                if (player.ListCharacter["Luffy"].PV == 0)
                {
                    Console.WriteLine("c'est finit loose");
                    
                }
            }
            
        }
    }
}
