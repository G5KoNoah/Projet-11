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
        int _selectPause;
        TimeSpan _timer;
        public enum StateFight { firstState, FightState, PersoState, ObjectState };

        StateFight _state;

        public int Select { get => _select; set => _select = value; }
        public StateFight State { get => _state; set => _state = value; }
        public int SelectPause { get => _selectPause; set => _selectPause = value; }
        public TimeSpan Timer { get => _timer; set => _timer = value; }

        public Input()
        {

            Select = 1;
            SelectPause = 1;
            State = StateFight.firstState;



        }
        public void InputGame()
        {
            Player player = GameManager.Instance.Player;
            ConsoleKeyInfo  key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("Entrer pressée");
                    
                    break;

                case ConsoleKey.Escape:
                    //Console.WriteLine("Echape pressée");
                    DateTime dateTime = DateTime.Now;
                    Timer = dateTime - GameManager.Instance.StartDateTime;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("     " + Timer.Hours + " : " + Timer.Minutes + " : " + Timer.Seconds + "                                                                                                          ");
                    GameManager.Instance.PauseManager.MainPause() ;
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

        public void InputPause()
        {

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    GameManager.Instance.Draw.DrawMap();
                    GameManager.Instance.MainLoop();
                    break;
                case ConsoleKey.Enter:
                    switch(SelectPause)
                    {
                        case 1:
                            GameManager.Instance.Draw.DrawMap();
                            GameManager.Instance.MainLoop();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (SelectPause == 1)
                    {
                        SelectPause = 2;
                    }
                    else
                    {
                        SelectPause = 1;
                    }
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("     " + Timer.Hours + " : " + Timer.Minutes + " : " + Timer.Seconds + "                                                                                                         ");
                    GameManager.Instance.Draw.Pause(SelectPause);
                    break;
                case ConsoleKey.DownArrow :
                    if (SelectPause == 1)
                    {
                        SelectPause = 2;
                    }
                    else
                    {
                        SelectPause = 1;
                    }
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("     " + Timer.Hours + " : " + Timer.Minutes + " : " + Timer.Seconds + "                                                                                                          ");
                    GameManager.Instance.Draw.Pause(SelectPause);
                    break;

            }


        }
            public void InputFight(Player player, Enemy enemy, Character character)
            {

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
                                Select = GameManager.Instance.FightManager.Choix.Length;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == GameManager.Instance.FightManager.Choix.Length)
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

                            Console.BackgroundColor = ConsoleColor.Blue;
                            enemy.Character.TakeDamage(character.SpellAttack(Select - 1, enemy.Character.DefaultStats.Type));
                            Console.SetCursorPosition(35, 10);
                            Console.WriteLine( "-> - " + character.SpellAttack(Select - 1, enemy.Character.DefaultStats.Type));
                            
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 0);
                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            
                            Random aleatoire = new Random();
                            int spell = aleatoire.Next(0, enemy.Character.Spells.Count);
                            character.TakeDamage(enemy.Character.SpellAttack(spell, character.DefaultStats.Type));
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.SetCursorPosition(35, 10);
                            Console.WriteLine(" - " + enemy.Character.SpellAttack(spell, character.DefaultStats.Type) + "<-");

                            Thread.Sleep(1000);
                            Console.SetCursorPosition(0, 0);
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
                                Select = player.Objects.Count;
                            }
                            else
                            {
                                Select -= 1;
                            }

                            GameManager.Instance.Draw.Fight(player, enemy, Select, character);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Select == player.Objects.Count)
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
                            //character = player.ListCharacter[Select - 1];
                            character = player.ListCharacter["Luffy"];
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
