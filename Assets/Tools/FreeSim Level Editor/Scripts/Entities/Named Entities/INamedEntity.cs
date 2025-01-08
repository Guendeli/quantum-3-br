#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public interface INamedEntity
    {
        #region Interface Properties
        string Name { get; set; }
        #endregion
    }
}
#endif