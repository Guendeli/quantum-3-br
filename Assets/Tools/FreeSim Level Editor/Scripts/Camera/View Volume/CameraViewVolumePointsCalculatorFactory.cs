#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public static class CameraViewVolumePointsCalculatorFactory
    {
        #region Public Static Functions
        public static CameraViewVolumePointsCalculator Create(Camera camera)
        {
            if (camera.orthographic) return new OrthoCameraViewVolumePointsCalculator();
            else return new PerspectiveCameraViewVolumePointsCalculator();
        }
        #endregion
    }
}
#endif
