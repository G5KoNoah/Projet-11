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
        public enum Display
        {
            Menu,
            Map,
            Transition,
            Fight,
            Inventary,
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

        public DisplayState() 
        {
            State = Display.Map;
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
                switch (State)
                {
                    case Display.Menu:
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
                        fightManager.Enemy = GameManager.Instance.Enemy;
                        fightManager.CurrentState = FightManager.StateFight.Start;
                        fightManager.SelectChange += draw.Fight;
                        fightManager.ModifySelect(0);
                        break;
                    case Display.Inventary:
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


                    if (draw.Map.MapList[player.TopPos][player.LeftPos] == '/')
                    {
                        draw.Dialogue();
                    }
                    if (draw.Map.MapList[player.TopPos][player.LeftPos] == '$' && new Random().Next(1, 10) == 1)
                    {
                        Console.WriteLine("Un ennemi est apparu !!!!");
                        Console.SetCursorPosition(0, 0);
                        Thread.Sleep(2000);
                        State = Display.Fight;
                        Exit = true;
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
                case Display.Inventary:
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
                    case Display.Inventary:
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
