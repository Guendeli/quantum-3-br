#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public static class ObjectSelectionUpdateOperationFactory
    {
        #region Public Static Functions
        public static IObjectSelectionUpdateOperation Create(ObjectSelectionUpdateOperationType operationType)
        {
            switch(operationType)
            {
                case ObjectSelectionUpdateOperationType.Click:

                    return new ClickObjectSelectionUpdateOperation();

                case ObjectSelectionUpdateOperationType.MouseDrag:

                    return new MouseDragObjectSelectionUpdateOperation();

                default:

                    return null;
            }
        }
        #endregion
    }
}
#endif