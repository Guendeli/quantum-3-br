#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public enum CoordinateSystemAxis
    {
        PositiveRight = 0,
        NegativeRight,
        PositiveUp,
        NegativeUp,
        PositiveLook,
        NegativeLook
    }

    public enum Axis
    {
        X = 0, Y, Z
    }
}
#endif