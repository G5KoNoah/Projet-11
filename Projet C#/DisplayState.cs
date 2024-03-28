using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public sealed class DisplayState
    {
        bool _exit;
        bool _enter;
        bool _bossUnlock;
        public enum Display
        {
            Menu,
            Map,
            Transition,
            Fight,
            Boss,
            Inventory,
            Pause
        }

        Display _displayState;
        public Display State { get => _displayState; set => _displayState = value; }

        private static DisplayState instance = null;
        private static readonly object padlock = new object();

        public static DisplayState Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DisplayState();
                    }
                    return instance;
                }
            }
        }

        public bool Exit { get => _exit; set => _exit = value; }
        public bool Enter { get => _enter; set => _enter = value; }
        public bool BossUnlock { get => _bossUnlock; set => _bossUnlock = value; }

        public DisplayState() 
        {
            State = Display.Menu;
            Exit = false;
            Enter = true;
        }

        public void EnterState()
        {
            if (Enter)
            {
                var draw = GameManager.Instance.Draw;
                var maps = GameManager.Instance.Maps;
                var player = GameManager.Instance.Player;
                var fightManager = GameManager.Instance.FightManager;
                var inventoryManager = GameManager.Instance.InventoryManager;
                switch (State)
                {
                    case Display.Menu:
                        draw.Map = maps["Start"];
                        draw.DrawMap(false);
                        GameManager.Instance.SelectChange += draw.Menu;
                        GameManager.Instance.ModifySelect(0);
                        
                        break;
                    case Display.Map:
                        draw.Map = maps["map" + (char)(GameManager.Instance.NumMap + '0')];
                        draw.DrawMap(true);
                        player.Move += draw.DrawMap;
                        break;
                    case Display.Transition:
                        draw.Map = maps["boat"];
                        draw.DrawMap(false);
                        break;
                    case Display.Fight:
                        draw.Map = maps["fight"];
                        

                        fightManager.CurrentState = FightManager.StateFight.Start;
                        fightManager.SelectChange += draw.Fight;
                        fightManager.ModifySelect(0);
                        break;
                    case Display.Inventory:
                        draw.Map = maps["inventory"];
                        draw.DrawMap(false);
                        inventoryManager.CurrentState = InventoryManager.StateInventory.Start;
                        inventoryManager.SelectChange += draw.Inventory;
                        inventoryManager.ModifySelect(0);
                        break;
                    case Display.Pause:
                        draw.Map = maps["break"];
                        GameManager.Instance.SelectChange += draw.Pause;
                        GameManager.Instance.ModifySelect(0);
                        break;
                }
                Enter = false;
            }
        }

        public void Update()
        {
            Player player = GameManager.Instance.Player;
            Draw draw = GameManager.Instance.Draw;
            var fightManager = GameManager.Instance.FightManager;
            var inventoryManager = GameManager.Instance.InventoryManager;
            var maps = GameManager.Instance.Maps;
            Input.Instance.InputGame(State);
            switch (State)
            {
                case Display.Menu:
                    break;
                case Display.Map:
                    if (draw.Map.MapList[player.TopPos][player.LeftPos] == '2')
                    {
                        if (GameManager.Instance.NumMap == 1)
                        {
                            GameManager.Instance.NumMap = 2;
                        }
                        else
                        {
                            GameManager.Instance.NumMap = 1;
                        }
                        (player.LeftPos, player.TopPos) = maps["map" + (char)(GameManager.Instance.NumMap + '0')].PlayerPos;
                        State = Display.Transition;
                        Exit = true;
                    }

                    foreach (var PNJ in draw.Map.PosPNJ)
                    {
                        if (PNJ.Pos.Item1 == player.LeftPos && PNJ.Pos.Item2 == player.TopPos)
                        {
                            draw.Dialogue(PNJ.Dialog);
                        }
                    }
                    if (draw.Map.MapList[player.TopPos][player.LeftPos] == '$' && new Random().Next(1, 10) == 1)
                    {
                        Console.WriteLine("Un ennemi est apparu !!!!");
                        Console.SetCursorPosition(0, 0);
                        Thread.Sleep(2000);
                        State = Display.Fight;
                        fightManager.Enemy = GameManager.Instance.EnemyList[new Random().Next(0, GameManager.Instance.EnemyList.Count - 1)];
                        fightManager.Enemy.Character.Level = player.CurrentCharacter.Level;
                        fightManager.Enemy.Character.StatsLevel();
                        fightManager.Enemy.Character.Spells[0].Level = 1;
                        Exit = true;
                    }else if(draw.Map.MapList[player.TopPos][player.LeftPos] == '@')
                    {
                        foreach(var charact in player.ListCharacter)
                        {
                            charact.Value.StatsLevel();
                        }
                    }
                    if(draw.Map.ObjectPos.Item1 == player.LeftPos && draw.Map.ObjectPos.Item2 == player.TopPos)
                    {
                        //Object key = new Object("oui", 1);
                        
                        //player.Objects.Add();
                        Console.WriteLine("objet récup");
                    }
                    if (player.LeftPos == 35 && player.TopPos == 9)
                    {
                        if (BossUnlock)
                        {
                            Console.WriteLine("Vous affrontez le BOSS !!!!");
                            Console.SetCursorPosition(0, 0);
                            Thread.Sleep(2000);
                            State = Display.Fight;
                            fightManager.Enemy = GameManager.Instance.Boss;
                            Exit = true;
                        }
                        else
                        {
                            bool keyFind = false;
                            foreach (var objectPlayer in player.Objects)
                            {
                                if (objectPlayer.Key == "Cle")
                                {
                                    keyFind = true;
                                }
                            }
                            if (keyFind)
                            {
                                BossUnlock = true;
                                draw.Dialogue("Vous avez debloque la porte, Crocodile vous attend !");
                                player.TopPos = 10;
                            }
                            else
                            {
                                draw.Dialogue("Vous ne pouvez pas entrer, il vous faut une clé!!");
                            }
                        }  
                    }
                    break;
                case Display.Transition:
                    Thread.Sleep(2000);
                    State = Display.Map;
                    Exit = true;
                    break;
                case Display.Fight:
                    if (fightManager.CurrentState == FightManager.StateFight.Flee)
                    {
                        State = Display.Map;
                        Exit = true;
                    }
                    break;
                case Display.Inventory:
                    break;
                case Display.Pause:
                    break;
            }
        }

        public void ExitState()
        {
            if (Exit)
            {
                Draw draw = GameManager.Instance.Draw;
                Player player = GameManager.Instance.Player;
                var fightManager = GameManager.Instance.FightManager;
                var inventoryManager = GameManager.Instance.InventoryManager;
                switch (State)
                {
                    case Display.Menu:
                        break;
                    case Display.Map:
                        player.Move -= draw.DrawMap;
                        break;
                    case Display.Transition:
                        break;
                    case Display.Fight:
                        fightManager.SelectChange -= draw.Fight;
                        break;
                    case Display.Inventory:
                        break;
                    case Display.Pause:
                        break;
                }
                Enter = true;
                Exit = false;
            }
        }
    }
}
