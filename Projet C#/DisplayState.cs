using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class DisplayState
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

        public DisplayState() {
            State = Display.Map;
            Exit = false;
            Enter = true;
        }

        private void EnterState()
        {
            if (Enter)
            {
                switch (State)
                {
                    case Display.Menu:
                        break;
                    case Display.Map:
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
            }
        }
    }
}
