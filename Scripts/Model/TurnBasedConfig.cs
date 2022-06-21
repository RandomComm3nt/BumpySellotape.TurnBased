
using BumpySellotape.Events.Model.Config;
using UnityEngine;

namespace BumpySellotape.TurnBased.Scripts.Model
{
    [CreateAssetMenu(menuName = "Config/Turn Based")]
    public class TurnBasedConfig : ConfigBase
    {
        [field: SerializeField] public GameObject BattleScreenPrefab { get; private set; }

        [field: SerializeField] public bool SelectAllActionsBeforeDoing { get; private set; }
    }
}
