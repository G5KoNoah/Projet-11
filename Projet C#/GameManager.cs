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
        FightManager _fightManager;
        Map _MapIsland;
        Map _MapBoat;
        Player _Player;
        Draw _Draw;
        IList<CharacterType> _ListCharacterTypes;
        List<Character> _characters;
        IList<Map> _ListMap;
        List<Tools> _tools;
        Enemy _enemy;


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
        public List<Character> Characters { get => _characters; set => _characters = value; }
        public List<Tools> Tools { get => _tools; set => _tools = value; }
        public FightManager FightManager { get => _fightManager; set => _fightManager = value; }

        public GameManager() {
            Input = new Input();
            ListCharacterTypes = new List<CharacterType>();  
            ListMap = new List<Map>();
            Characters = new List<Character>();
            Tools = new List<Tools>();
            Player = new Player(Characters, Tools);
            _enemy = new Enemy();
            FightManager = new FightManager();

            InitMap();
            InitType();
            
            InitCharacter();

            Draw.DrawMap();

            
            
            //Draw.Fight(Player, enemy);
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
            CharacterStats crocoStats = new CharacterStats("Croco", ListCharacterTypes[1], 200.0f, 80.0f, 30.0f, 30.0f, 80.0f, 60.0f);

            CharacterStats stats = new CharacterStats("Mec", ListCharacterTypes[0], 100, 1, 2, 1, 2, 1);

            Character cTest = new Character(stats, 1);
            _enemy.Character = cTest;
            //Init Character

            Character luffy = new Character(luffyStats, 1);
            Characters.Add(luffy);

            Character croco = new Character(crocoStats, 1);
            Characters.Add(croco);

            Spell redHawk = new Spell(1, "Red Hawk", 1.5f, 50.0f, ListCharacterTypes[2]);
            Spell attaque2 = new Spell(1, "Attaque 2", 1.5f, 50.0f, ListCharacterTypes[2]);

            luffy.Spells.Add(redHawk);
            luffy.Spells.Add(attaque2);
            _enemy.Character.Spells.Add(redHawk);
        }

        public void MainLoop()
        {
            while (true)
            {
                Input.InputTest();
                if (Player.LeftPos == 6)
                {
                    //Draw.Map = ListMap[1];
                    //Draw.Fight(Player, _enemy);
                    FightManager.MainLoop(Player, _enemy);
                }
            }
        }
    }
}
