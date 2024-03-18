using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_C_
{
    internal class Input
    {
       
        public Input()
        {
            
            
        }
        public void InputTest()
        {
            ConsoleKeyInfo  key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                Console.WriteLine("Flèche gauche pressée");
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                Console.WriteLine("Flèche droite pressée");
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                Console.WriteLine("Flèche du bas pressée");
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                Console.WriteLine("Flèche du haut pressée");
            }
        }

        
    }
}
