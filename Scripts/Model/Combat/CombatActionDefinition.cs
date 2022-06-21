using BumpySellotape.Core;
using BumpySellotape.Events.Model.Conditions;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.TurnBased.Model.Combat
{
    [CreateAssetMenu(menuName = "TurnBased/Combat/Action")]
    public class CombatActionDefinition : SerializedScriptableObject
    {
        [field: SerializeField] public string Label { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public bool ShowTargetting { get; private set; } = true;
        [field: SerializeField, ShowIf(nameof(ShowTargetting))] public TargetType TargetType { get; private set; }
        [field: SerializeField, ShowIf(nameof(ShowTargetting))] public bool TargetAllAvailable { get; private set; }


        // visual effect

        [field: SerializeField, Required] public List<CombatEffect> Effects { get; } = new List<CombatEffect>();
        [field: SerializeField, Required] public ICondition UseCondition { get; } = new AlwaysTrueCondition();
        [field: SerializeField, Required] public ICondition ShowCondition { get; } = new AlwaysTrueCondition();
        [field: SerializeField, Required] public SystemLinks<ICombatActionProperties> SystemLinks { get; } = new SystemLinks<ICombatActionProperties>();
    }

    public interface ICombatActionProperties
    { }
}
