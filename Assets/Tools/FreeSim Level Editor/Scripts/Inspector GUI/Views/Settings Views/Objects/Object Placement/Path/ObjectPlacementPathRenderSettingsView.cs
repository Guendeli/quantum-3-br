#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class ObjectPlacementPathRenderSettingsView : SettingsView
    {
        #region Private Variables
        [NonSerialized]
        private ObjectPlacementPathRenderSettings _settings;
        #endregion

        #region Constructors
        public ObjectPlacementPathRenderSettingsView(ObjectPlacementPathRenderSettings settings)
        {
            _settings = settings;
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            _settings.ManualConstructionRenderSettings.View.Render();
        }
        #endregion
    }
}
#endif