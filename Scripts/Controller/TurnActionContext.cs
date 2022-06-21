using BumpySellotape.Events.Controller;
using BumpySellotape.Events.Model.Effects;
using BumpySellotape.TurnBased.Controller.Actors;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.TurnBased.Controller
{
    public class TurnActionContext : ProcessingContext
    {
        public MonoBehaviour coroutineBehaviour;
        public TurnSystem turnSystem;
        public List<Actor> targets;
        public Actor turnActor;

        public TurnActionContext(GameController gameController) : base(gameController)
        {
        }
    }
}
