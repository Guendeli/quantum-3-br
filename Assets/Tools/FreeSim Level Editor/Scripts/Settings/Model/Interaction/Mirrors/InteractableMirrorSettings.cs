#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class InteractableMirrorSettings : ScriptableObject
    {
        #region Private Variables
        [SerializeField]
        private ObjectMouseMoveAlongDirectionSettings _mouseOffsetFromHoverSurfaceSettings;
        [SerializeField]
        private ObjectMouseRotationSettings _mouseRotationSettings;
        [SerializeField]
        private ObjectKeyboardRotationSettings _keyboardRotationSettings;

        [SerializeField]
        private InteractableMirrorSettingsView _view;
        #endregion

        #region Public Properties
        public ObjectMouseMoveAlongDirectionSettings MouseOffsetFromHoverSurfaceSettings
        {
            get
            {
                if (_mouseOffsetFromHoverSurfaceSettings == null) _mouseOffsetFromHoverSurfaceSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<ObjectMouseMoveAlongDirectionSettings>();
                return _mouseOffsetFromHoverSurfaceSettings;
            }
        }
        public ObjectMouseRotationSettings MouseRotationSettings
        {
            get
            {
                if (_mouseRotationSettings == null) _mouseRotationSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<ObjectMouseRotationSettings>();
                return _mouseRotationSettings;
            }
        }

        public ObjectKeyboardRotationSettings KeyboardRotationSettings
        {
            get
            {
                if (_keyboardRotationSettings == null) _keyboardRotationSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<ObjectKeyboardRotationSettings>();
                return _keyboardRotationSettings;
            }
        }

        public InteractableMirrorSettingsView View { get { return _view; } }
        #endregion

        #region Constructors
        private InteractableMirrorSettings()
        {
            _view = new InteractableMirrorSettingsView(this);
        }
        #endregion
    }
}
#endif