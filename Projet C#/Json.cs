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

    public struct JsonObject
    {
        string _name;
        string _typeObject;
        string _description;
        int _turn;
        float _boostHp;
        float _boostPt;
        float _boostAttack;

        public string Name { get => _name; set => _name = value; }
        public string TypeObject { get => _typeObject; set => _typeObject = value; }
        public string Description { get => _description; set => _description = value; }
        public int Turn { get => _turn; set => _turn = value; }
        public float BoostPt { get => _boostPt; set => _boostPt = value; }
        public float BoostHp { get => _boostHp; set => _boostHp = value; }
        public float BoostAttack { get => _boostAttack; set => _boostAttack = value; }
    }
}
