using BumpySellotape.TurnBased.Controller;
using UnityEngine;

namespace BumpySellotape.TurnBased.Model.Actions
{
    public class DoNothingAction : TurnAction
    {
        public DoNothingAction()
        {
            action = (TurnActionContext c) =>
            {
                Debug.Log($"{c.turnActor.Name} does nothing!");
                c.turnActor.OnActionComplete();
            };
        }
    }
}
