using BumpySellotape.TurnBased.Model;

namespace BumpySellotape.TurnBased.Controller.Actors
{
    public class ActorFactory
    {
        public void CreateActor(TurnSystem turnSystem, ActorTemplate template)
        {
            var a = new Actor(turnSystem, template.ActorDetails);

            template.SystemGenerators.ForEach(g => a.SystemLinks.RegisterSystem(g.Generate()));
        }
    }
}
