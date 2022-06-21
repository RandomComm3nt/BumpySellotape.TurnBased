using BumpySellotape.TurnBased.Controller.Actors;
using System;
using System.Collections.Generic;

namespace BumpySellotape.TurnBased.Controller
{
    public class TurnAction
    {
        public List<Actor> targetActors;
        public Action<TurnActionContext> action;

        public virtual void DoAction(TurnActionContext context)
        {
            context.targets = targetActors;
            action.Invoke(context);
        }
    }
}
