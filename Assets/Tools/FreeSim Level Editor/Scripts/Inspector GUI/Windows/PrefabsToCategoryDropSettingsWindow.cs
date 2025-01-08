#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace FreeSimEditor
{
    [Serializable]
    public class PrefabsToCategoryDropSettingsWindow : FreeSimEditorWindow
    {
        #region Private Variables
        [SerializeField]
        private Vector2 _scrollViewPosition = Vector2.zero;
        #endregion

        #region Public Static Functions
        public static PrefabsToCategoryDropSettingsWindow Get()
        {
            return FreeSimWorldBuilder.ActiveInstance.PrefabsToCategoryDropSettingsWindow;
        }
        #endregion

        #region Public Methods
        public override string GetTitle()
        {
            return "Prefabs To Category Drop Settings";
        }

        public override void ShowFreeSimWindow()
        {
            ShowUtility(true);
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            _scrollViewPosition = EditorGUILayout.BeginScrollView(_scrollViewPosition);
            PrefabsToCategoryDropEventHandler dropEventHandler = PrefabsToCategoryDropEventHandler.Get();
            dropEventHandler.PrefabsDropSettings.View.Render();
            dropEventHandler.PrefabFoldersDropSettings.View.Render();
            EditorGUILayout.EndScrollView();
        }
        #endregion
    }
}
#endif