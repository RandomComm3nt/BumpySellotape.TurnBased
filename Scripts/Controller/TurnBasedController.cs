using UnityEngine;

namespace BumpySellotape.TurnBased.Controller
{
    public abstract class TurnBasedController : MonoBehaviour
    {
        public abstract TurnActionContext BuildTurnActionContext();
    }
}
