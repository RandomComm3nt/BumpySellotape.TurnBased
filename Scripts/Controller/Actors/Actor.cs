using BumpySellotape.Core;
using BumpySellotape.Core.Messaging;
using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.TurnBased.Model;
using System;
using UnityEngine;

namespace BumpySellotape.TurnBased.Controller.Actors
{
    public class Actor : IMessageReceiver
    {
        private TurnAction selectedAction;
        private ActorState actorState;

        public delegate void StateChange(Actor actor);
        public event StateChange OnStateChange;

        public string Name => ActorDetails.ActorName;
        [Obsolete]
        public StatCollection StatCollection { get; private set; }
        public ActorDetails ActorDetails { get; private set; }
        public SystemLinks SystemLinks { get; private set; }
        public TurnSystem TurnSystem { get; }

        public ActorState ActorState
        {
            get => actorState; 
            private set
            {
                actorState = value;
                Debug.Log($"{Name} : {value}");
                OnStateChange?.Invoke(this);
            }
        }

        public Actor(TurnSystem turnSystem, ActorDetails actorDetails)
        {
            TurnSystem = turnSystem;
            ActorDetails = actorDetails;

            SystemLinks = new SystemLinks();
            turnSystem.AddActor(this);
        }

        public void BeginActionSelection()
        {
            ActorState = ActorState.SelectingAction;
            ActorDetails.ActorBehaviour?.SelectAction(this);
        }

        public void SelectAction(TurnAction turnAction)
        {
            selectedAction = turnAction;
            ActorState = ActorState.WaitingToDoAction;
            TurnSystem.OnActionSelected(this);
        }

        public void DoAction()
        {
            ActorState = ActorState.DoingAction;
            var context = TurnSystem.TurnBasedController.BuildTurnActionContext();
            context.turnActor = this;
            selectedAction.DoAction(context);
        }

        public void OnActionComplete()
        {
            ActorState = ActorState.ActionTaken;
            TurnSystem.OnActionTaken();
        }

        public void StartTurn()
        {
            ActorDetails.ActorBehaviour.DoTurn(this);
        }

        public void EndTurn()
        {

        }

        public void TakeAction(TurnAction turnAction)
        {

        }

        public void EndCurrentTurn()
        {
            TurnSystem.EndCurrentTurn();
        }

        public void SendMessage(Message message)
        {
            Debug.Log("message");
            SystemLinks.GetSystemsOfType<IMessageReceiver>().SendMessage(message);
        }
    }
}
