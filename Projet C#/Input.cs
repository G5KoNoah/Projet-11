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
        int _select;
        public enum StateFight { firstState, FightState };

        StateFight _state;

        public int Select { get => _select; set => _select = value; }
        public StateFight State { get => _state; set => _state = value; }

        public Input()
        {

            Select = 1;
            State = StateFight.firstState;



        }
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
                    //Console.WriteLine("Flèche gauche pressée");
                    player.MoveLeft(-1);
                    break;

                case ConsoleKey.UpArrow:
                    //Console.WriteLine("Flèche du haut pressée");
                    player.MoveTop(-1);

                    break;

                case ConsoleKey.RightArrow:
                    //Console.WriteLine("Flèche droite pressée");
                    player.MoveLeft(1);
                    break;

                case ConsoleKey.DownArrow:
                    //Console.WriteLine("Flèche du bas pressée");
                    player.MoveTop(1);
                    break;

                default:
                    break;
            }
        }

        public void InputFight(Player player, Enemy enemy) {

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (State)
            {
                case StateFight.firstState:
                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:

                            switch (Select)
                            {
                                case 1:
                                    State = StateFight.FightState;
                                    GameManager.Instance.Draw.Fight(player, enemy, Select);

                                    break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (Select == 1)
                            {
                                Select = 4;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == 4)
                            {
                                Select = 1;
                            }
                            else
                            {
                                Select += 1;
                            }
                            GameManager.Instance.Draw.Fight(player, enemy, Select);

                            break;
                        default:
                            break;
                    }
                    break;

                case StateFight.FightState:

                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:

                            switch (Select)
                            {
                                case 1:
                                    


                                    break;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (Select == 1)
                            {
                                Select = 3;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == 3)
                            {
                                Select = 1;
                            }
                            else
                            {
                                Select += 1;
                            }
                            GameManager.Instance.Draw.Fight(player, enemy, Select);

                            break;
                        default:
                            break;
                    }
                    break;


            } 
            

        }

        
    }
}
