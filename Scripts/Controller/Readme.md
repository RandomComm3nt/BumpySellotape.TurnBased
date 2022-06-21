

Actor - 
ActorBehaviour - AI for an enemy, selects actions and targets

In a project, Actors might have additional properties or systems like Equipment or Traits. These might give actions.
Even within a project, these systems might not be required for all actors. For example in an RPG, a Bandit enemy might have an Equipment system, but a Wolf enemy won't.
If we already need to do null checks, there's no extra overhead for a dictionary system.

If we are sticking to SRP I don't want to bloat Actor though.