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
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("Entrer pressée");
                    break;

                case ConsoleKey.Escape:
                    Console.WriteLine("Echape pressée");
                    break;

                case ConsoleKey.LeftArrow:
                    Console.WriteLine("Flèche gauche pressée");
                    break;

                case ConsoleKey.UpArrow:
                    Console.WriteLine("Flèche du haut pressée");
                    break;

                case ConsoleKey.RightArrow:
                    Console.WriteLine("Flèche droite pressée");
                    break;

                case ConsoleKey.DownArrow:
                    Console.WriteLine("Flèche du bas pressée");
                    break;

                default:
                    break;
            }
        }

        
    }
}
