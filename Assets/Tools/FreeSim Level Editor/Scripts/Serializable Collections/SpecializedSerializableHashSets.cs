#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class SerializableGameObjectHashSet : SerializableHashSet<GameObject> { }

    [Serializable]
    public class SerializableStringHashSet : SerializableHashSet<string> { }
}
#endif