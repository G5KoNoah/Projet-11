using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Projet_C_.FightManager;
using static Projet_C_.InventoryManager;

using static System.Net.Mime.MediaTypeNames;

namespace Projet_C_
{
    public class Draw
    {
        Map _map;
        public Map Map { get => _map; set => _map = value; }
        public Draw()
        {
            Map = null;
        }

        public void DrawMap(bool drawPlayer)
        {
            //Console.Clear();
            
            Player player = GameManager.Instance.Player;
            List<string> lMap = Map.MapList;
           
            for (int i = 0; i < lMap.Count; i++)
            {
                for (int j = 0; j < lMap[i].Length; j++)
                {
                    switch (lMap[i][j])
                    {
                        case '_' or '|':
                            Console.BackgroundColor = ConsoleColor.Blue;
                           
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case '*':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case '$':
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case '/':
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        case '1':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            break;
                        case '8':
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            break;
                        case '2':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            break;
                        case '3':
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                    }
                    if (drawPlayer)
                    {
                        bool letterDraw = false;
                        Console.ForegroundColor = ConsoleColor.Black;
                        foreach (var PNJ in Map.PosPNJ)
                        {
                            if (i == PNJ.Pos.Item2 && j == PNJ.Pos.Item1)
                            {
                                Console.Write('A');
                                letterDraw = true;
                            }
                        }
                        if (i == player.TopPos && j == player.LeftPos)
                        {
                            Console.Write('P');
                            letterDraw = true;
                        }
                        if (i == Map.ObjectPos.Item2 && j == Map.ObjectPos.Item1)
                        {
                            Console.Write('C');
                            letterDraw = true;
                        }
                        if (letterDraw == false)
                        {
                            Console.Write(' ');
                        }
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }
        public void Fight(Player player, Character enemy)
        {
            var fightManager = GameManager.Instance.FightManager;
            var currentCharacter = player.CurrentCharacter;
            DrawMap(false);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(14, 0);
            Console.WriteLine(currentCharacter.DefaultStats.Name + "  " + currentCharacter.DefaultStats.Type.Name);
            Console.SetCursorPosition(59, 0);
            Console.WriteLine(enemy.DefaultStats.Name + "  " + enemy.DefaultStats.Type.Name);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(14, 14);
            Console.WriteLine(currentCharacter.PV);
            Console.SetCursorPosition(59, 14);
            Console.WriteLine(enemy.PV);
            switch (fightManager.CurrentState)
            {
                case FightManager.StateFight.Start:
                    for (int i = 0; i < fightManager.Choice.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(fightManager.Choice[i]);
                    }
                    break;

                case FightManager.StateFight.Attack:
                    for (int i = 0; i < currentCharacter.Spells.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(currentCharacter.Spells[i].Name);
                    }

                    break;

                case FightManager.StateFight.Tools:
                    for (int i = 0; i < player.Objects.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(player.Objects.ElementAt(i).Value.Name);
                    }

                    break;

                case FightManager.StateFight.ChangePerso:
                    for (int i = 0; i < player.ListCharacter.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (player.ListCharacter.ElementAt(i).Value.PV == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine(player.ListCharacter.ElementAt(i).Value.DefaultStats.Name);
                    }

                    break;
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);


        }

        public void Inventory(Player player)
        {
            DrawMap(false);
            var inventoryManager = GameManager.Instance.InventoryManager;
            switch (inventoryManager.CurrentState)
            {
                case InventoryManager.StateInventory.Start:
                    for (int i = 0; i < inventoryManager.Choice.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == inventoryManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(inventoryManager.Choice[i]);
                    }
                    break;

                case InventoryManager.StateInventory.Object:
                    for (int i = 0; i < player.ListCharacter.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == inventoryManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(player.Objects.ElementAt(i).Value.Name);
                    }

                    break;
                case InventoryManager.StateInventory.Character:
                    for (int i = 0; i < player.ListCharacter.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == inventoryManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(player.ListCharacter.ElementAt(i).Value.DefaultStats.Name);
                    }

                    break;
                case InventoryManager.StateInventory.CharacterDetails:
                    Console.SetCursorPosition(13, 15);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select-1).Value.DefaultStats.Name);
                    Console.SetCursorPosition(13, 16);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select - 1).Value.Level);
                    Console.SetCursorPosition(25, 16);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select - 1).Value.NeedXP);
                    Console.SetCursorPosition(13, 17);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select - 1).Value.PV);
                    Console.SetCursorPosition(25, 17);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select - 1).Value.MaxPv);
                    Console.SetCursorPosition(13, 18);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select - 1).Value.PT);
                    Console.SetCursorPosition(25, 18);
                    Console.WriteLine(player.ListCharacter.ElementAt(inventoryManager.Select - 1).Value.MaxPt);


                    break;
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);


        }

        


        public void Win(Player player, Character enemy)
        {
            Console.SetCursorPosition(0, 0);
            Fight(player, enemy);
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("vous avez gagnez !!");
            Console.SetCursorPosition(0, 0);
        }

        public void Loose(Player player, Character enemy)
        {
            Console.SetCursorPosition(0, 0);
            Fight(player, enemy);
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("vous avez perdu !!");
            Console.SetCursorPosition(0, 0);
        }

        public void Damage(float damage, bool isEnemy)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(35, 10);
            if (isEnemy)
            {
                Console.WriteLine(" - " + damage + "<-");
            }
            else
            {
                Console.WriteLine("-> - " + damage);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }

        public void Pause()
        {
            DrawMap(false);
            Console.SetCursorPosition(33, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ONE PIECE");

            var choices = GameManager.Instance.Choice;
            for (int i = 0; i < choices.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (i + 1 == GameManager.Instance.Select)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.SetCursorPosition(13, 8 + 3 * i);
                Console.WriteLine(choices[i]);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }

        public void Menu()
        {
            var choices = GameManager.Instance.MenuChoice;
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < choices.Count;i++)
            {
                if( i + 1 == GameManager.Instance.Select)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.SetCursorPosition(45 , 15 + i + 1);
                Console.WriteLine(choices[i]);
            }
            Console.SetCursorPosition(0, 0);
        }


        public void Dialogue(string dialogue)
        {
            int ligne = 20;
            //string dialogue = "Salut mec !!!";
            Console.SetCursorPosition(15, ligne);
            Console.BackgroundColor = ConsoleColor.Black;
            for(int i = 0;i < 5; i++)
            {
                for(int j = 0; j< 40; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
                ligne++;
                Console.SetCursorPosition(15, ligne);
            }
            ligne = 20;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(15, ligne);
            for(int i = 0; i < dialogue.Length; i++)
            {
                Console.Write(dialogue[i]);
                Thread.Sleep(70);
                if(i % 39 == 0 && i > 0)
                {
                    
                    ligne++;
                    Console.SetCursorPosition(15, ligne);
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            
        }
    }
}
