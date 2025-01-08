#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace FreeSimEditor
{
    //[Serializable]
    public class FreeSimMeshDatabase
    {
        #region Private Variables
        //[SerializeField]
        private SerializableFreeSimMeshDictionary _meshes = new SerializableFreeSimMeshDictionary();
        #endregion

        #region Public Static Functions
        public static FreeSimMeshDatabase Get()
        {
            return FreeSimScene.Get().FreeSimMeshDatabase;
        }
        #endregion

        #region Constructors
        public FreeSimMeshDatabase()
        {
            EditorApplication.projectChanged -= RemoveNullMeshEntries;
            EditorApplication.projectChanged += RemoveNullMeshEntries;
        }
        #endregion

        #region Public Methods
        public FreeSimMesh GetFreeSimMesh(Mesh mesh)
        {
            if (mesh == null) return null;

            if (!Contains(mesh)) _meshes.Dictionary.Add(mesh, new FreeSimMesh(mesh));
            return _meshes.Dictionary[mesh];
        }

        public bool Contains(Mesh mesh)
        {
            return mesh != null && _meshes.Dictionary.ContainsKey(mesh);
        }
        #endregion

        #region Private Methods
        private void RemoveNullMeshEntries()
        {
            var newMeshDictionary = new SerializableFreeSimMeshDictionary();
            foreach (KeyValuePair<Mesh, FreeSimMesh> pair in _meshes.Dictionary)
            {
                if (pair.Key != null) newMeshDictionary.Dictionary.Add(pair.Key, pair.Value);
            }
    
            _meshes = newMeshDictionary;
        }
        #endregion
    }
}
#endif