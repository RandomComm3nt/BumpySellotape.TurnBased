using System;

namespace BumpySellotape.TurnBased.Model.Combat
{
    [Flags]
    public enum TargetType
    {
        Enemy = 1,
        Self = 2,
        Ally = 4,
    }
}
