#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class ObjectLayersWindow : FreeSimEditorWindow
    {
        #region Private Variables
        [SerializeField]
        private Vector2 _scrollViewPosition = Vector2.zero;
        #endregion

        #region Public Static Functions
        public static ObjectLayersWindow Get()
        {
            return FreeSimWorldBuilder.ActiveInstance.ObjectLayersWindow;
        }
        #endregion

        #region Public Methods
        public override string GetTitle()
        {
            return "Object Layers";
        }

        public override void ShowFreeSimWindow()
        {
            ShowDockable(true);
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            _scrollViewPosition = EditorGUILayout.BeginScrollView(_scrollViewPosition);
            RenderContentInScrollView();
            EditorGUILayout.EndScrollView();
        }
        #endregion

        #region Private Methods
        private void RenderContentInScrollView()
        {
            EditorGUILabelWidth.Push(EditorGUILayoutEx.PreferedEditorWindowLabelWidth);
            ObjectLayerDatabase.Get().View.Render();
            EditorGUILabelWidth.Pop();
        }
        #endregion
    }
}
#endif