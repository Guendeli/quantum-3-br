#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public enum ObjectPlacementMode
    {
        DecorPaint = 0,
        PointAndClick,
        Path,
        Block,
        VolumeTiles
    }
}
#endif