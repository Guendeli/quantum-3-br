#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class DecorPaintObjectPlacementLookAndFeelSettingsView : SettingsView
    {
        #region Constructors
        public DecorPaintObjectPlacementLookAndFeelSettingsView()
        {
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            DecorPaintObjectPlacement.Get().BrushCircleRenderSettings.View.Render();
        }
        #endregion
    }
}
#endif