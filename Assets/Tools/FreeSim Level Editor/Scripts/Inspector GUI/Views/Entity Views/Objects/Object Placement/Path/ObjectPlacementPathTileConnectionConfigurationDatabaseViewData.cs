#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class ObjectPlacementPathTileConnectionConfigurationDatabaseViewData : ScriptableObject
    {
        #region Private Variables
        [SerializeField]
        private string _nameForNewConfiguration = "";
        #endregion

        #region Public Properties
        public string NameForNewConfiguration { get { return _nameForNewConfiguration; } set { _nameForNewConfiguration = value; } }
        #endregion
    }
}
#endif