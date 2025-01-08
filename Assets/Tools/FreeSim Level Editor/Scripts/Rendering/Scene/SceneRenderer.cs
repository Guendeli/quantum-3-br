#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public class SceneRenderer
    {
        #region Public Methods
        public void RenderGizmos()
        {
            if (FreeSimWorldBuilder.ActiveInstance == null) return;
            SceneRenderPathType sceneRenderPathType = InspectorGUIIdentifiers.GetSceneRenderPathTypeFromIdentifier(FreeSimWorldBuilder.ActiveInstance.Inspector.ActiveInspectorGUIIdentifier);
            SceneRenderPathFactory.Create(sceneRenderPathType).RenderGizmos();
        }

        public void RenderHandles()
        {
            if (FreeSimWorldBuilder.ActiveInstance == null) return;
            SceneRenderPathType sceneRenderPathType = InspectorGUIIdentifiers.GetSceneRenderPathTypeFromIdentifier(FreeSimWorldBuilder.ActiveInstance.Inspector.ActiveInspectorGUIIdentifier);
            SceneRenderPathFactory.Create(sceneRenderPathType).RenderHandles();
        }
        #endregion
    }
}
#endif