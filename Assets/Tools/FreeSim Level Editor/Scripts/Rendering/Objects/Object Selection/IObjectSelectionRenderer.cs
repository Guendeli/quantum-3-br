#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace FreeSimEditor
{
    public interface IObjectSelectionRenderer
    {
        #region Interface Methods
        void Render(List<GameObject> selectedObjects);
        #endregion
    }
}
#endif