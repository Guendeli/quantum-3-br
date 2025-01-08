#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class SerializableFreeSimMeshDictionary : SerializableDictionary<Mesh, FreeSimMesh> { }
}
#endif