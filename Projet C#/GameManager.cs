using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public sealed class GameManager
    {
        Input _Input;
        Map _MapIsland;
        Map _MapBoat;
        Player _Player;
        Draw _Draw;
        IList<CharacterType> _ListCharacterTypes;


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

        public Player Player { get => _Player; private set => _Player = value; }
        public Map MapIsland { get => _MapIsland; private set => _MapIsland = value; }
        internal Input Input { get => _Input; set => _Input = value; }
        public IList<CharacterType> ListCharacterTypes { get => _ListCharacterTypes; set => _ListCharacterTypes = value; }
        public Draw Draw { get => _Draw; set => _Draw = value; }

        public GameManager() {
            Input = new Input();
            Player = new Player();
            ListCharacterTypes = new List<CharacterType>();  
            InitMap();
            InitType();
            InitCharacter();

            Draw.DrawMap();
            Player.Move += Draw.DrawMap;



        }

        public void InitMap()
        {
            MapIsland = new Map();
            Draw = new Draw(MapIsland, Player);
            var map = Draw.FileToText("..\\..\\..\\map1.txt");
            MapIsland.MapList = map;


            _MapBoat = new Map();
            var map2 = Draw.FileToText("..\\..\\..\\boat.txt");
            _MapBoat.MapList = map2;


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
                Input.InputTest();
                if (Player.LeftPos == 2)
                {
                    Draw.Map = _MapBoat;
                }
            }
        }
    }
}
