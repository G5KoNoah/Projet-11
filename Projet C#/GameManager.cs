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
        IList<Map> _ListMap;


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
        public IList<CharacterType> ListCharacterTypes { get => _ListCharacterTypes; private set => _ListCharacterTypes = value; }

        public Draw Draw { get => _Draw; private set => _Draw = value; }
        public Input Input { get => _Input; private set => _Input = value; }
        public IList<Map> ListMap { get => _ListMap; private set => _ListMap = value; }

        public GameManager() {
            Input = new Input();
            Player = new Player();
            ListCharacterTypes = new List<CharacterType>();  
            ListMap = new List<Map>();
            Enemy enemy = new Enemy();  

            InitMap();
            InitType();
            InitCharacter();

            //Draw.DrawMap();

            CharacterStats stats = new CharacterStats("oui", ListCharacterTypes[0],2,1,2,1,2,1);

            Character cTest = new Character(stats,1);
            enemy.Character = cTest;
            
            Draw.Fight(Player, enemy);
            Player.Move += Draw.DrawMap;

            Console.CursorVisible = false;



        }

        public void InitMap()
        {
            Map mapIsland = new Map();
            Draw = new Draw(mapIsland, Player);
            var text = Draw.FileToText("..\\..\\..\\map1.txt");
            mapIsland.MapList = text;

            ListMap.Add(mapIsland);
           

            Map mapBoat = new Map();
            var text2 = Draw.FileToText("..\\..\\..\\boat.txt");
            mapBoat.MapList = text2;

            ListMap.Add(mapBoat);


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
            Player.ListCharacter.Add(luffy);
        }

        public void MainLoop()
        {
            while (true)
            {
                Input.InputTest();
                if (Player.LeftPos == 2)
                {
                    Draw.Map = ListMap[1];
                }
            }
        }
    }
}
