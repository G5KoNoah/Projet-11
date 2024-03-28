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
            var inventoryManager = GameManager.Instance.InventoryManager;
            InputByState = new Dictionary<DisplayState.Display, Dictionary<ConsoleKey, Action>>
{
                { DisplayState.Display.Menu, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.UpArrow, () => { GameManager.Instance.ModifySelect(-1) ; Console.Beep(100, 50);}},
                        { ConsoleKey.DownArrow, () => { GameManager.Instance.ModifySelect(1); Console.Beep(100, 50);}},
                        { ConsoleKey.Enter, () => { GameManager.Instance.ValideSelect(); Console.Beep(100, 50);}},
                        { ConsoleKey.Escape, () => {
                            Console.Beep(100, 50);
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Map;
                            displayState.Exit = true;

                        }}

                    }
                },
                { DisplayState.Display.Map, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.LeftArrow, () => { player.MoveLeft(-1);  Console.Beep(100, 50);}},
                        { ConsoleKey.RightArrow, () => { player.MoveLeft(1); Console.Beep(100, 50);}},
                        { ConsoleKey.UpArrow, () => { player.MoveTop(-1); Console.Beep(100, 50);}},
                        { ConsoleKey.DownArrow, () => { player.MoveTop(1); Console.Beep(100, 50);}},
                        { ConsoleKey.Escape, () => {
                            Console.Beep(200, 100);
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Pause;
                            displayState.Exit = true;
                        }},
                        { ConsoleKey.I, () => {
                            Console.Beep(200, 100);
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Inventory;
                            displayState.Exit = true;
                        }}
                    }
                },
                { DisplayState.Display.Fight, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.UpArrow, () => { fightManager.ModifySelect(-1); Console.Beep(100, 50);  }},
                        { ConsoleKey.DownArrow, () => { fightManager.ModifySelect(1); Console.Beep(100, 50);}},
                        { ConsoleKey.LeftArrow, () => { fightManager.SelectBack(); Console.Beep(100, 50);}},
                        { ConsoleKey.Enter, () => { fightManager.ValideSelect(); Console.Beep(200, 50);}}
                    }
                },
                { DisplayState.Display.Inventory, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.UpArrow, () => { inventoryManager.ModifySelect(-1); Console.Beep(100, 50);}},
                        { ConsoleKey.DownArrow, () => { inventoryManager.ModifySelect(1); Console.Beep(100, 50);}},
                        { ConsoleKey.Enter, () => { inventoryManager.ValideSelect(); Console.Beep(100, 50);}},
                        { ConsoleKey.LeftArrow, () => { inventoryManager.SelectBack(); Console.Beep(100, 50);}},
                        { ConsoleKey.Escape, () => {
                            Console.Beep(200, 100);
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Pause;
                            displayState.Exit = true;
                        }},
                        { ConsoleKey.I, () => {
                            Console.Beep(200, 100);
                            var displayState = DisplayState.Instance;
                            displayState.State = DisplayState.Display.Map;
                            displayState.Exit = true;
                        }}
                    }
                },
                { DisplayState.Display.Pause, new Dictionary<ConsoleKey, Action>
                    {
                        { ConsoleKey.UpArrow, () => { GameManager.Instance.ModifySelect(-1); Console.Beep(100, 50);}},
                        { ConsoleKey.DownArrow, () => { GameManager.Instance.ModifySelect(1); Console.Beep(100, 50);}},
                        { ConsoleKey.Enter, () => { GameManager.Instance.ValideSelect();Console.Beep(200, 50); }},
                        { ConsoleKey.Escape, () => {
                            Console.Beep(200, 100);
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
            if(currentState != DisplayState.Display.Transition)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (InputByState.ContainsKey(currentState) && InputByState[currentState].ContainsKey(key))
                {
                    InputByState[currentState][key].Invoke();
                }
            }
            
        }  
    }
}
