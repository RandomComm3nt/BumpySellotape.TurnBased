namespace BumpySellotape.TurnBased.Controller.Actors
{
    public abstract class ActorBehaviour
    {
        public abstract void SelectAction(Actor actor);
        public abstract void DoTurn(Actor actor);
    }
}
