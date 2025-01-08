#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace FreeSimEditor
{
    public abstract class ObjectSelectionUpdateOperation : IObjectSelectionUpdateOperation
    {
        #region Public Abstract Methods
        public abstract void Perform();
        #endregion
    }
}
#endif