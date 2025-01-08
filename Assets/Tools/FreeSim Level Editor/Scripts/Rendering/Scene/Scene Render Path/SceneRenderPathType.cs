#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public enum SceneRenderPathType
    {
        ObjectPlacement = 0,
        ObjectErase,
        ObjectSelection,
        ObjectLayers,
        ScenePreparation
    }
}
#endif
