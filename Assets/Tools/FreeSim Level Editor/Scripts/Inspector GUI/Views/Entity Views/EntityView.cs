#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public abstract class EntityView : GUIRenderableContent
    {
    }
}
#endif