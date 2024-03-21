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
            }
            
        }
    }
}
