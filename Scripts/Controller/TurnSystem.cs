using BumpySellotape.Core.Messaging;
using BumpySellotape.Events.Model.Config;
using BumpySellotape.TurnBased.Scripts.Model;
using System.Collections.Generic;
using System.Linq;

namespace BumpySellotape.TurnBased.Controller.Actors
{
    public class TurnSystem
    {
        private readonly List<Actor> actors;
        private readonly TurnBasedConfig turnBasedConfig;
        private int turnIndex;
        private List<Actor> actorsInTurnOrder;

        public List<Actor> Actors => actors;
        public Actor CurrentTurnActor => actors[turnIndex];
        public Actor NextTurnActor => actors[(turnIndex + 1) % actors.Count];

        public TurnBasedController TurnBasedController { get; }

        public delegate void ActorEvent(Actor actor);
        public event ActorEvent OnTurnChanged;
        public event ActorEvent OnActorAdded;

        public TurnSystem(TurnBasedController turnBasedController)
        {
            actors = new List<Actor>();
            ConfigManager.Instance.TryGetConfigFile(out turnBasedConfig);
            TurnBasedController = turnBasedController;
        }

        internal void AddActor(Actor actor)
        {
            actors.Add(actor);
            OnActorAdded?.Invoke(actor);
        }

        public void Start()
        {
            turnIndex = 0;
            StartRound();
        }

        private void StartRound()
        {
            if (turnBasedConfig.SelectAllActionsBeforeDoing)
            {
                actorsInTurnOrder = actors.ToList();
            }
            else
            {
                actorsInTurnOrder = actors.ToList();
            }

            turnIndex = 0;
            actorsInTurnOrder[turnIndex].BeginActionSelection();
        }

        private void EndRound()
        {
            actors.Select(a => a as IMessageReceiver).SendMessage(new Message(MessageType.CombatRoundEnd));

            StartRound();
        }

        public void OnActionSelected(Actor actor)
        {
            if (turnBasedConfig.SelectAllActionsBeforeDoing)
            {
                AdvanceActionSelection();
            }
            else
            {
                actor.DoAction();
            }
        }

        public void OnActionTaken()
        {
            if (turnBasedConfig.SelectAllActionsBeforeDoing)
            {
                AdvanceActionDoing();
            }
            else
            {
                AdvanceActionSelection();
            }
        }

        private void AdvanceActionSelection()
        {
            turnIndex++;
            if (turnIndex < actorsInTurnOrder.Count)
            {
                actorsInTurnOrder[turnIndex].BeginActionSelection();
            }
            else
            {
                if (turnBasedConfig.SelectAllActionsBeforeDoing)
                {
                    actorsInTurnOrder = actors.ToList();
                    turnIndex = 0;
                    actorsInTurnOrder[turnIndex].DoAction();
                }
                else
                {
                    EndRound();
                }
            }
        }

        private void AdvanceActionDoing()
        {
            turnIndex++;
            if (turnIndex < actorsInTurnOrder.Count)
            {
                actorsInTurnOrder[turnIndex].DoAction();
            }
            else
            {
                EndRound();
            }
        }

        public void EndCurrentTurn()
        {
            CurrentTurnActor.EndTurn();
            turnIndex = (turnIndex + 1) % actors.Count;
            OnTurnChanged?.Invoke(CurrentTurnActor);
            CurrentTurnActor.StartTurn();
        }
    }
}
