#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public static class ObjectEraseOperationFactory
    {
        #region Public Static Functions
        public static IObjectEraseOperation Create(ObjectEraseMode objectEraseMode)
        {
            switch(objectEraseMode)
            {
                case ObjectEraseMode.HoveredObject:

                    return new HoveredObjectEraseOperation();

                case ObjectEraseMode.ObjectMass2D:

                    return new ObjectMassEraseOperation();

                case ObjectEraseMode.ObjectMass3D:

                    return new ObjectMassEraseOperation();

                default:

                    return null;
            }
        }
        #endregion
    }
}
#endif