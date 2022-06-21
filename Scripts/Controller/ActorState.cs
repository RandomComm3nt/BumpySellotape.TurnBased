namespace BumpySellotape.TurnBased.Controller
{
    public enum ActorState
    {
        WaitingToSelectAction,
        SelectingAction,
        WaitingToDoAction,
        DoingAction,
        ActionTaken,
    }
}
