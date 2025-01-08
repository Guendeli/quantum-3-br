#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class BlockObjectPlacementLookAndFeelSettingsView : SettingsView
    {
        #region Constructors
        public BlockObjectPlacementLookAndFeelSettingsView()
        {
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            BlockObjectPlacement.Get().BlockRenderSettings.View.Render();
            BlockObjectPlacement.Get().BlockExtensionPlaneRenderSettings.View.Render();
        }
        #endregion
    }
}
#endif