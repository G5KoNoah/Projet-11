﻿using System;
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


        List<TypeJson> _ListTypeJson;
        Dictionary<string, CharacterType> _characterTypes;

        List<CharacterJson> _characterJson;
        Dictionary<string, CharacterStats> _characterStats;
        Dictionary<string, Character> _characterPlayer;

        List<Map> _ListMap;
        Dictionary<string, Objects> _objects;
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

        public Draw Draw { get => _Draw; private set => _Draw = value; }
        public Input Input { get => _Input; private set => _Input = value; }
        public List<Map> ListMap { get => _ListMap; private set => _ListMap = value; }
        public Dictionary<string, Objects> Objects { get => _objects; set => _objects = value; }
        public FightManager FightManager { get => _fightManager; set => _fightManager = value; }
        public DateTime StartDateTime { get => _startDateTime; private set => _startDateTime = value; }
        public PauseManager PauseManager { get => _pauseManager; set => _pauseManager = value; }
        public List<TypeJson> ListTypeJson { get => _ListTypeJson; set => _ListTypeJson = value; }
        public List<CharacterJson> CharacterJson { get => _characterJson; set => _characterJson = value; }
        public Dictionary<string, CharacterType> CharacterTypes { get => _characterTypes; set => _characterTypes = value; }
        public Dictionary<string, CharacterStats> CharacterStats { get => _characterStats; set => _characterStats = value; }
        public Dictionary<string, Character> CharacterPlayer { get => _characterPlayer; set => _characterPlayer = value; }

        public GameManager() {
            Input = new Input();

            CharacterStats = new Dictionary<string, CharacterStats>();
            CharacterTypes = new Dictionary<string, CharacterType>();
            CharacterPlayer = new Dictionary<string, Character>();

            ListMap = new List<Map>();

            Objects = new Dictionary<string, Objects>();
            Player = new Player(CharacterPlayer, Objects);
            _enemy = new Enemy();
            FightManager = new FightManager();
            PauseManager = new PauseManager();
            _Random = new Random();
            StartDateTime = DateTime.Now;
            InitMap();
            InitTypeJson();
            InitType();
            InitCharacterJson();
             
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


            Map mapInventory = new Map();
            var text3 = Draw.FileToText("..\\..\\..\\fight.txt");
            mapInventory.MapList = text3;

            ListMap.Add(mapInventory);


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
                CharacterTypes[type.Name] =  new CharacterType(type.Name, type.PV, type.PT, type.Attack, type.Defense, type.AttackSpeed, type.Precision);
            }

            CharacterTypes["speed"].Weakness = CharacterTypes["range"];
            CharacterTypes["range"].Weakness = CharacterTypes["strength"];
            CharacterTypes["strength"].Weakness = CharacterTypes["speed"];
        }

        public void InitCharacterJson()
        {
            string filePath = "..\\..\\..\\character.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                CharacterJson = JsonSerializer.Deserialize<List<CharacterJson>>(jsonContent);

            }
            else
            {
                Console.WriteLine("Le fichier JSON n'existe pas.");
            }
        }
        public void InitCharacter()
        {

            //Init CharacterStats
            foreach(CharacterJson character in CharacterJson)
            {
                CharacterStats[character.Name] = new CharacterStats(character.Name, CharacterTypes[character.CharacterType], character.PV, character.PT, character.Attack, character.Defense, character.AttackSpeed, character.Precision);
            }
            //Init Character

            Character luffy = new Character(CharacterStats["Luffy"], 1);
            CharacterPlayer["Luffy"] = luffy;

            Character croco = new Character(CharacterStats["Croco"], 1);
            CharacterPlayer["Croco"] = croco;

            Spell redHawk = new Spell(1, "Red Hawk", 1.5f, 50.0f, CharacterTypes["range"]);
            Spell attaque2 = new Spell(1, "Attaque 2", 2.5f, 50.0f, CharacterTypes["strength"]);

            Food tools1 = new Food("potion",2,3,5,8);
            Food tools2 = new Food("poison", 2, 3, 5, 8);

            luffy.Spells.Add(redHawk);
            luffy.Spells.Add(attaque2);

            CharacterStats stats = new CharacterStats("oui", CharacterTypes["range"], 2, 1, 2, 1, 2, 1);
            Character cTest = new Character(stats, 1);
            _enemy.Character = cTest;
            _enemy.Character.Spells.Add(redHawk);

            Player.Objects[tools1.Name] = tools1;
            Player.Objects[tools2.Name] = tools2;
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
                    
                    Draw.Map = ListMap[2];
                    Draw.DrawMap();
                    //Draw.DrawInventory();

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
