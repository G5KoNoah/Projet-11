using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_C_
{
    public abstract class Stats
    {
        float _PV;
        float _PT;
        float _attack;
        float _defense;
        float _attackSpeed;
        float _precision;

        public float PV { get => _PV; protected set => _PV = value; }
        public float PT { get => _PT; protected set => _PT = value; }
        public float Attack { get => _attack; protected set => _attack = value; }
        public float Defense { get => _defense; protected set => _defense = value; }
        public float AttackSpeed { get => _attackSpeed; protected set => _attackSpeed = value; }
        public float Precision { get => _precision; protected set => _precision = value; }
    }
}