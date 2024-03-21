using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class FightManager
    {
        public FightManager() { }
        public void MainLoop(Player player ,Enemy enemy)
        {
            
            
            GameManager.Instance.Draw.Fight(player, enemy, 1);
            while (true)
            {
                GameManager.Instance.Input.InputFight(player, enemy);

                if (enemy.Character.PV == 0)
                {
                    Console.WriteLine("c'est finit");
                    
                }

                

                if (player.ListCharacter[0].PV == 0)
                {
                    Console.WriteLine("c'est finit loose");
                    
                }
            }
            
        }
    }
}
