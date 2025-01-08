#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public abstract class CameraViewVolumePointsCalculator
    {
        #region Public Abstract Methods
        public abstract Vector3[] CalculateWorldSpaceVolumePoints(Camera camera);
        #endregion
    }
}
#endif