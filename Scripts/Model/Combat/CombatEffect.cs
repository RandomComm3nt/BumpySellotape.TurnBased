using BumpySellotape.TurnBased.Controller;
using System;

namespace BumpySellotape.TurnBased.Model.Combat
{
    public abstract class CombatEffect
    {
        public abstract void DoEffect(TurnActionContext context, Action effectCompleteCallback);
    }
}
