using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Projet_C_
{
    public sealed class Input
    {
        Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>> _inputByState;
        public Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>> InputByState { get => _inputByState; set => _inputByState = value; }

        private static Input instance = null;
        private static readonly object padlock = new object();

        public static Input Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Input();
                    }
                    return instance;
                }
            }
        }
        public Input()
        {
            var player = GameManager.Instance.Player;
            var fightManager = GameManager.Instance.FightManager;
            InputByState = new Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>>
{
                { DisplayState.Display.Map, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.LeftArrow, () => { player.MoveLeft(-1); }},
                        { ConsoleKey.RightArrow, () => { player.MoveLeft(1); }},
                        { ConsoleKey.UpArrow, () => { player.MoveTop(-1); }},
                        { ConsoleKey.DownArrow, () => { player.MoveTop(1); }},
                        { ConsoleKey.Escape, () => {
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Pause;
                            displayState.Exit = true;
                        }}
                    }
                },
                { DisplayState.Display.Fight, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.UpArrow, () => { fightManager.ModifySelect(-1); }},
                        { ConsoleKey.DownArrow, () => { fightManager.ModifySelect(1); }},
                        { ConsoleKey.Enter, () => { fightManager.ValideSelect(); }}
                    }
                },
                { DisplayState.Display.Pause, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.UpArrow, () => { GameManager.Instance.ModifySelect(-1); }},
                        { ConsoleKey.DownArrow, () => { GameManager.Instance.ModifySelect(1); }},
                        { ConsoleKey.Enter, () => { GameManager.Instance.ValideSelect(); }},
                        { ConsoleKey.Escape, () => {
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Map;
                            displayState.Exit = true; 
                        }}
                    }
                }
            };
        }

        public void InputGame(DisplayState.Display currentState)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (InputByState.ContainsKey(currentState) && InputByState[currentState].ContainsKey(key))
            {
                InputByState[currentState][key].Invoke();
            }
        }  
    }
}
