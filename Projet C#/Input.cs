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
        public enum StateFight { firstState, FightState, PersoState, ObjectState };

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

        public void InputFight(Player player, Enemy enemy, Character character) {

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
                                    GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                                    break;

                                case 3:
                                    State = StateFight.ObjectState;
                                    Select = 1;
                                    GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                                    break;

                                case 4:
                                    State = StateFight.PersoState;
                                    Select = 1;
                                    GameManager.Instance.Draw.Fight(player, enemy, Select, character);
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

                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
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
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);

                            break;
                        default:
                            break;
                    }
                    break;

                case StateFight.FightState:

                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:

                            
                            enemy.Character.TakeDamage(character.SpellAttack(Select - 1));
                            //Console.WriteLine(player.ListCharacter[0].SpellAttack(0));         
                            Random aleatoire = new Random();
                            int spell = aleatoire.Next(0, enemy.Character.Spells.Count);
                            character.TakeDamage(enemy.Character.SpellAttack(spell));                                   
                            State = StateFight.firstState;                
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
  
                            break;
                        case ConsoleKey.UpArrow:
                            if (Select == 1)
                            {
                                Select = character.Spells.Count;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == character.Spells.Count)
                            {
                                Select = 1;
                            }
                            else
                            {
                                Select += 1;
                            }
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);

                            break;
                        default:
                            break;
                    }
                    break;


                case StateFight.ObjectState:

                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:
                            
                            break;
                        case ConsoleKey.UpArrow:
                            if (Select == 1)
                            {
                                Select = player.ListTools.Count;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == player.ListTools.Count)
                            {
                                Select = 1;
                            }
                            else
                            {
                                Select += 1;
                            }
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);

                            break;
                        default:
                            break;
                    }
                    break;

                case StateFight.PersoState:

                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:
                            character = player.ListCharacter[Select - 1];
                            Select = 1;
                            State = StateFight.firstState;
                            GameManager.Instance.FightManager.Character = character;
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            break;
                        case ConsoleKey.UpArrow:
                            if (Select == 1)
                            {
                                Select = player.ListCharacter.Count;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == player.ListCharacter.Count)
                            {
                                Select = 1;
                            }
                            else
                            {
                                Select += 1;
                            }
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);

                            break;
                        default:
                            break;
                    }
                    break;


            } 
            

        }

        
    }
}
