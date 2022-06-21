using BumpySellotape.Core;
using BumpySellotape.TurnBased.Controller;
using BumpySellotape.TurnBased.Controller.Actors;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.TurnBased.Model
{
    [CreateAssetMenu(menuName = "Actors/Actor Template")]
    public class ActorTemplate : SerializedScriptableObject
    {
        [field: SerializeField, HideLabel] public ActorDetails ActorDetails { get; private set; } = new ActorDetails();

        [field: SerializeField] public List<Generator> SystemGenerators { get; private set; } = new List<Generator>();
    }

    public class ActorDetails
    {
        [field: SerializeField] public string ActorName { get; private set; }
        [field: OdinSerialize] public ActorBehaviour ActorBehaviour { get; private set; }
        [field: SerializeField] public ActorType ActorType { get; private set; }

        public ActorDetails(string actorName = "", 
            ActorBehaviour actorBehaviour = null,
            ActorType actorType = ActorType.Ally)
        {
            ActorName = actorName;
            ActorBehaviour = actorBehaviour;
            ActorType = actorType;
        }
    }
}