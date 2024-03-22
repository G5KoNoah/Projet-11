using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projet_C_
{
    public sealed class GameManager
    {
        Input _Input;
        FightManager _fightManager;
        PauseManager _pauseManager;
        Map _MapIsland;
        Map _MapBoat;
        Player _Player;
        Draw _Draw;
        List<CharacterType> _ListCharacterTypes;
        List<TypeJson> _ListTypeJson;
        List<Character> _characters;
        List<Map> _ListMap;
        List<Tools> _tools;
        Enemy _enemy;
        DateTime _startDateTime;

        Random _Random;

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
        public List<CharacterType> ListCharacterTypes { get => _ListCharacterTypes; private set => _ListCharacterTypes = value; }

        public Draw Draw { get => _Draw; private set => _Draw = value; }
        public Input Input { get => _Input; private set => _Input = value; }
        public List<Map> ListMap { get => _ListMap; private set => _ListMap = value; }
        public List<Character> Characters { get => _characters; set => _characters = value; }
        public List<Tools> Tools { get => _tools; set => _tools = value; }
        public FightManager FightManager { get => _fightManager; set => _fightManager = value; }
        public DateTime StartDateTime { get => _startDateTime; private set => _startDateTime = value; }
        public PauseManager PauseManager { get => _pauseManager; set => _pauseManager = value; }
        public List<TypeJson> ListTypeJson { get => _ListTypeJson; set => _ListTypeJson = value; }

        public GameManager() {
            Input = new Input();
            ListCharacterTypes = new List<CharacterType>();  
            ListMap = new List<Map>();
            Characters = new List<Character>();
            Tools = new List<Tools>();
            Player = new Player(Characters, Tools);
            _enemy = new Enemy();
            FightManager = new FightManager();
            PauseManager = new PauseManager();
            _Random = new Random();
            StartDateTime = DateTime.Now;
            InitMap();
            InitTypeJson();
            InitType();
            InitCharacter();

            Draw.DrawMap();

            CharacterStats stats = new CharacterStats("oui", ListCharacterTypes[0],2,1,2,1,2,1);

            Character cTest = new Character(stats,1);
            _enemy.Character = cTest;
            
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
        public void InitTypeJson()
        {
            string filePath = "..\\..\\..\\type.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                ListTypeJson = JsonSerializer.Deserialize<List<TypeJson>>(jsonContent);

            }
            else
            {
                Console.WriteLine("Le fichier JSON n'existe pas.");
            }
        }
        public void InitType()
        {
            foreach(TypeJson type in ListTypeJson)
            {
                ListCharacterTypes.Add(new CharacterType(type.Name, type.PV, type.PT, type.Attack, type.Defense, type.AttackSpeed, type.Precision));
            }

            ListCharacterTypes[0].Weakness = ListCharacterTypes[1];
            ListCharacterTypes[1].Weakness = ListCharacterTypes[2];
            ListCharacterTypes[2].Weakness = ListCharacterTypes[0];
        }

        public void InitCharacter()
        {

            //Init CharacterStats

            CharacterStats luffyStats = new CharacterStats("Luffy", ListCharacterTypes[2], 200, 80, 30, 30, 80, 60);
            CharacterStats crocoStats = new CharacterStats("Croco", ListCharacterTypes[1], 200.0f, 80.0f, 30.0f, 30.0f, 80.0f, 60.0f);
            //Init Character

            Character luffy = new Character(luffyStats, 1);
            Characters.Add(luffy);

            Character croco = new Character(crocoStats, 1);
            Characters.Add(croco);

            Spell redHawk = new Spell(1, "Red Hawk", 1.5f, 50.0f, ListCharacterTypes[2]);

            luffy.Spells.Add(redHawk);
        }

        public void MainLoop()
        {
            while (true)
            {
                Input.InputGame();

                //if (Player.LeftPos == 6)
                //{
                //    Draw.Map = ListMap[1];
                //    Draw.Fight(Player, _enemy);
                //    FightManager.MainLoop(Player, _enemy);
                //}
                if (Draw.Map.MapList[Player.TopPos][Player.LeftPos] == '$' && _Random.Next(1,10) == 1)
                {
                    //Draw.Map = ListMap[1];
                    //Draw.Fight(Player, _enemy);
                    Console.WriteLine("Un ennemi est apparu !!!!");
                    Thread.Sleep(2000);
                    FightManager.MainLoop(Player, _enemy);

                }else if(Draw.Map.MapList[Player.TopPos][Player.LeftPos] == '&')
                {
                    Console.WriteLine("Fight the boss !!!!");
                    Thread.Sleep(2000);
                    FightManager.MainLoop(Player, _enemy);
                }
            }
        }
    }
}
