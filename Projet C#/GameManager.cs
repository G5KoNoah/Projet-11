﻿using System;
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


        public GameManager() {
            _Input = new Input();
            _Player = new Player();
            _ListCharacterTypes = new List<CharacterType>();  
            InitMap();
            InitType();
            InitCharacter();

            _Draw.DrawMap();
            _Player.Move += _Draw.DrawMap;



        }

        public void InitMap()
        {
            _MapIsland = new Map();
            _Draw = new Draw(_MapIsland, _Player);
            var map = _Draw.FileToText("..\\..\\..\\map1.txt");
            _MapIsland.MapList = map;


            _MapBoat = new Map();
            var map2 = _Draw.FileToText("..\\..\\..\\boat.txt");
            _MapBoat.MapList = map2;


        }

        public void InitType()
        {
            _ListCharacterTypes.Add(new CharacterType("speed", 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 0.8f));
            _ListCharacterTypes.Add(new CharacterType("range", 0.8f, 1.2f, 0.8f, 0.8f, 0.8f, 1.2f));
            _ListCharacterTypes.Add(new CharacterType("strength", 1.2f, 0.8f, 1.2f, 1.2f, 1.0f, 1.0f));

            _ListCharacterTypes[0].Weakness = _ListCharacterTypes[1];
            _ListCharacterTypes[1].Weakness = _ListCharacterTypes[2];
            _ListCharacterTypes[2].Weakness = _ListCharacterTypes[0];
        }

        public void InitCharacter()
        {

            //Init CharacterStats

            CharacterStats luffyStats = new CharacterStats("Luffy", _ListCharacterTypes[2], 200, 80, 30, 30, 80, 60);

            //Init Character

            Character luffy = new Character(luffyStats, 1);
        }

        public void MainLoop()
        {
            while (true)
            {
                _Input.InputTest(_Player);
                if (_Player.LeftPos == 2)
                {
                    _Draw.Map = _MapBoat;
                }
            }
        }
    }
}
