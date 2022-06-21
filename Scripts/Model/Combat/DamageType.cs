using BumpySellotape.Core.Stats.Model;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.TurnBased.Model.Combat
{
    [CreateAssetMenu(menuName = "TurnBased/Damage Type")]
    public class DamageType : ScriptableObject
    {
        [field: SerializeField] public StatType DamageDealtTo { get; private set; }
        [field: SerializeField] public List<DamageModifierStatType> DamageModifierStatTypes { get; private set; }
    }
}
