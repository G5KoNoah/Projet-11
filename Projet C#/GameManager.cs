using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public sealed class GameManager
    {
        Parser _parser;
        Input _input;
        Player _player;
        Draw _draw;
        List<CharacterType> _listTypes;
        Dictionary<string, Map> _maps;

        private static GameManager instance = null;
        private static readonly object padlock = new object();

        public static GameManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                    return instance;
                }
            }
        }

        public Player Player { get => _player; private set => _player = value; }
        public List<CharacterType> ListCharacterTypes { get => _listTypes; private set => _listTypes = value; }
        public Draw Draw { get => _draw; private set => _draw = value; }
        public Input Input { get => _input; private set => _input = value; }
        public Dictionary<string, Map> Maps { get => _maps; set => _maps = value; }
        public Parser Parser { get => _parser; set => _parser = value; }
        

        public GameManager() {
            Parser = new Parser();
            Input = new Input();
            Player = new Player();
            ListCharacterTypes = new List<CharacterType>();
            Maps = new Dictionary<string, Map>();

            InitMap();
            InitType();
            InitCharacter();

            Draw = new Draw(Maps["map1"], Player);

            Draw.DrawMap();
            Player.Move += Draw.DrawMap;

            Console.CursorVisible = false;
        }

        public void InitMap()
        {
            string[] names = { "map1", "boat" };
            foreach (string name in names)
            {
                Map map = new Map();
                var text = Parser.FileToText("..\\..\\..\\" + name +".txt");
                map.MapList = text;
                Maps.Add(name, map);
            }
        }

        public void InitType()
        {
            ListCharacterTypes.Add(new CharacterType("speed", 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 0.8f));
            ListCharacterTypes.Add(new CharacterType("range", 0.8f, 1.2f, 0.8f, 0.8f, 0.8f, 1.2f));
            ListCharacterTypes.Add(new CharacterType("strength", 1.2f, 0.8f, 1.2f, 1.2f, 1.0f, 1.0f));

            ListCharacterTypes[0].Weakness = ListCharacterTypes[1];
            ListCharacterTypes[1].Weakness = ListCharacterTypes[2];
            ListCharacterTypes[2].Weakness = ListCharacterTypes[0];
        }

        public void InitCharacter()
        {

            //Init CharacterStats

            CharacterStats luffyStats = new CharacterStats("Luffy", ListCharacterTypes[2], 200, 80, 30, 30, 80, 60);

            //Init Character

            Character luffy = new Character(luffyStats, 1);
        }

        public void MainLoop()
        {
            while (true)
            {
                switch (DisplayState)
                {
                    case Display.Menu:
                        break;
                    case Display.Map:
                        Input.InputTest();
                        if (Player.LeftPos == 10)
                        {
                            Draw.Map = Maps["boat"];
                            DisplayState = Display.Transition;
                        }
                        break;
                    case Display.Transition:
                        Draw.DrawMap();
                        Thread.Sleep(2000);
                        Draw.Map = Maps["map1"];
                        DisplayState = Display.Map;
                        Draw.DrawMap();
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
