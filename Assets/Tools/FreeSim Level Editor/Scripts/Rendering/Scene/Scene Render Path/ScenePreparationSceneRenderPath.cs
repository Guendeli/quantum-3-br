#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public class ScenePreparationSceneRenderPath : SceneRenderPath
    {
        #region Public Methods
        public override void RenderGizmos()
        {
            ObjectSnapping.Get().XZSnapGrid.RenderGizmos();
        }

        public override void RenderHandles()
        {
        }
        #endregion
    }
}
#endif