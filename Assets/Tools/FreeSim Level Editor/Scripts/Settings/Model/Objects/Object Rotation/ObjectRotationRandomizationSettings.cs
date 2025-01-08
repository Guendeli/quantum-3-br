#if UNITY_EDITOR
using UnityEngine;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class ObjectRotationRandomizationSettings : ScriptableObject
    {
        #region Private Variables
        [SerializeField]
        private bool _randomizeRotation = false;

        [SerializeField]
        private CustomAxisRotationRandomizationSettings _customAxisRandomizationSettings;
        [SerializeField]
        private AxisRotationRandomizationSettings _xAxisRandomizationSettings;
        [SerializeField]
        private AxisRotationRandomizationSettings _yAxisRandomizationSettings;
        [SerializeField]
        private AxisRotationRandomizationSettings _zAxisRandomizationSettings;

        [SerializeField]
        private ObjectRotationRandomizationSettingsView _view;
        #endregion

        #region Public Properties
        public bool RandomizeRotation { get { return _randomizeRotation; } set { _randomizeRotation = value; } }

        public CustomAxisRotationRandomizationSettings CustomAxisRandomizationSettings
        {
            get
            {
                if (_customAxisRandomizationSettings == null) _customAxisRandomizationSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<CustomAxisRotationRandomizationSettings>();
                return _customAxisRandomizationSettings;
            }
        }
        public AxisRotationRandomizationSettings XAxisRandomizationSettings
        {
            get
            {
                if (_xAxisRandomizationSettings == null)
                {
                    _xAxisRandomizationSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<AxisRotationRandomizationSettings>();
                    _xAxisRandomizationSettings.Axis = TransformAxis.X;
                }
                return _xAxisRandomizationSettings;
            }
        }
        public AxisRotationRandomizationSettings YAxisRandomizationSettings
        {
            get
            {
                if (_yAxisRandomizationSettings == null)
                {
                    _yAxisRandomizationSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<AxisRotationRandomizationSettings>();
                    _yAxisRandomizationSettings.Axis = TransformAxis.Y;
                }
                return _yAxisRandomizationSettings;
            }
        }
        public AxisRotationRandomizationSettings ZAxisRandomizationSettings
        {
            get
            {
                if (_zAxisRandomizationSettings == null)
                {
                    _zAxisRandomizationSettings = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<AxisRotationRandomizationSettings>();
                    _zAxisRandomizationSettings.Axis = TransformAxis.Z;
                }
                return _zAxisRandomizationSettings;
            }
        }

        public ObjectRotationRandomizationSettingsView View { get { return _view; } }
        #endregion

        #region Constructors
        public ObjectRotationRandomizationSettings()
        {
            _view = new ObjectRotationRandomizationSettingsView(this);
        }
        #endregion
    }
}
#endif