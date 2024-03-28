using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public struct Json
    {
        string _name;
        string _characterType;
        float _PV;
        float _PT;
        float _attack;
        float _defense;
        float _attackSpeed;
        float _precision;

        public float PV { get => _PV; set => _PV = value; }
        public float PT { get => _PT; set => _PT = value; }
        public float Attack { get => _attack; set => _attack = value; }
        public float Defense { get => _defense; set => _defense = value; }
        public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
        public float Precision { get => _precision; set => _precision = value; }
        public string Name { get => _name; set => _name = value; }
        public string CharacterType { get => _characterType; set => _characterType = value; }
    }

    public struct Save {
        int _map;
        PlayerData _player;
        public int Map { get => _map; set => _map = value; }
        public PlayerData Player { get => _player; set => _player = value; }
    }

    public struct PlayerData {
        int _leftPos;
        int _topPos;
        ObjectData[] _objects;
        CharacterData[] _characters;

        public int LeftPos { get => _leftPos; set => _leftPos = value; }
        public int TopPos { get => _topPos; set => _topPos = value; }
        public ObjectData[] Objects { get => _objects; set => _objects = value; }
        public CharacterData[] Characters { get => _characters; set => _characters = value; }
    }

    public struct ObjectData {
        string _name;
        int _number;

        public string Name { get => _name; set => _name = value; }
        public int Number { get => _number; set => _number = value; }
    }

    public struct CharacterData
    {
        string _name;
        int _level;
        int _needXP;
        SpellData[] _spells;

        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }
        public int NeedXP { get => _needXP; set => _needXP = value; }
        public SpellData[] Spells { get => _spells; set => _spells = value; }
    }

    public struct SpellData
    {
        string _name;
        int _level;
        int _needXP;
        string _type;
        int _consumed;

        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }
        public int NeedXP { get => _needXP; set => _needXP = value; }
        public string Type { get => _type; set => _type = value; }
        public int Consumed { get => _consumed; set => _consumed = value; }
    }
}
