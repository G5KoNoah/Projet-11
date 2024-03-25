using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class PauseManager
    {
        public PauseManager() { }
        public void MainPause() 
        {
            GameManager.Instance.Draw.Pause(1);
            while (true)
            {
                GameManager.Instance.Input.InputPause();
            }
        }
    }
}
