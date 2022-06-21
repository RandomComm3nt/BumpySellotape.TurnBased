using BumpySellotape.Core.Traits.Controller;
using BumpySellotape.Core.Traits.Model;
using BumpySellotape.TurnBased.Controller;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BumpySellotape.TurnBased.Model.Combat
{
    [HideReferenceObjectPicker]
    public class TraitCombatEffect : CombatEffect
    {
        [SerializeField] private ChangeType changeType = ChangeType.Add;
        [SerializeField, Required] private TraitType traitType;
        [SerializeField, ShowIf(nameof(IsTraitStackable))] private uint stacks = 1;

        private bool IsTraitStackable => traitType && traitType.IsStackable;

        public override void DoEffect(TurnActionContext context, Action effectCompleteCallback)
        {
            var tc = context.turnActor.SystemLinks.GetSystemSafe<TraitCollection>();
            switch (changeType)
            {
                case ChangeType.Add:
                    tc.AddTrait(traitType, IsTraitStackable ? stacks : 1);
                    break;
                case ChangeType.Remove:
                    tc.RemoveTrait(traitType);
                    break;
            }
            effectCompleteCallback?.Invoke();
        }

        private enum ChangeType
        {
            Add = 0,
            Remove,
            AddStacks,
            RemoveStacks,
        }
    }
}
