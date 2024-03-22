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
        private Display State { get => _displayState; set => _displayState = value; }

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
                Draw draw = GameManager.Instance.Draw;
                var maps = GameManager.Instance.Maps;
                Player player = GameManager.Instance.Player;
                switch (State)
                {
                    case Display.Menu:
                        break;
                    case Display.Map:
                        draw.Map = maps["map1"];
                        draw.DrawMap();
                        player.Move += draw.DrawMap;
                        break;
                    case Display.Transition:
                        draw.Map = maps["boat"];
                        draw.DrawMap();
                        break;
                    case Display.Fight:
                        break;
                    case Display.Inventary:
                        break;
                    case Display.Pause: 
                        break;
                }
                Enter = false;
            }
        }

        public void Update()
        {
            Player player = GameManager.Instance.Player;
            Input.Instance.InputGame(State);
            switch (State)
            {
                case Display.Menu:
                    break;
                case Display.Map:
                    if (player.LeftPos == 10)
                    {
                        State = Display.Transition;
                        Exit = true;
                    }
                    break;
                case Display.Transition:
                    Thread.Sleep(2000);
                    State = Display.Map;
                    Exit = true;
                    break;
                case Display.Fight:
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
