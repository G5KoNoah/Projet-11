using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Projet_C_
{
    public class Input
    {
        Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>> _inputByState;
        public Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>> InputByState { get => _inputByState; set => _inputByState = value; }
        public Input()
        {
            Player player = GameManager.Instance.Player;
            InputByState = new Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>>();

            InputByState[DisplayState.Display.Map][ConsoleKey.LeftArrow] = () => player.MoveLeft(-1);
            InputByState[DisplayState.Display.Map][ConsoleKey.UpArrow] = () => player.MoveTop(-1);
            InputByState[DisplayState.Display.Map][ConsoleKey.RightArrow] = () => player.MoveLeft(1);
            InputByState[DisplayState.Display.Map][ConsoleKey.DownArrow] = () => player.MoveTop(1);

            InputByState[DisplayState.Display.Fight][ConsoleKey.UpArrow] = () => { };
            InputByState[DisplayState.Display.Fight][ConsoleKey.DownArrow] = () => { };
        }

        public void Input
        

        public void InputTest()
        {
            Player player = GameManager.Instance.Player;
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
                    player.MoveLeft(-1);
                    break;

                case ConsoleKey.UpArrow:
                    player.MoveTop(-1);

                    break;

                case ConsoleKey.RightArrow:
                    player.MoveLeft(1);
                    break;

                case ConsoleKey.DownArrow:
                    player.MoveTop(1);
                    break;

                default:
                    break;
            }
        }

        
    }
}
