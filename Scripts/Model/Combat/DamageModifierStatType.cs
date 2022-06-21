using BumpySellotape.Core.Stats.Model;
using System;
using UnityEngine;

namespace BumpySellotape.TurnBased.Model.Combat
{
    [Serializable]
    public class DamageModifierStatType
    {
        [field: SerializeField] public StatType StatType { get; private set; }
        [field: SerializeField] public bool Multiplicative { get; private set; }
        [field: SerializeField] public float Multiplier { get; private set; } = 1f;
    }
}
