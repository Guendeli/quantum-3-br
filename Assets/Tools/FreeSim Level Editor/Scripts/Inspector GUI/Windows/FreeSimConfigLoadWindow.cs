#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class FreeSimConfigLoadWindow : FreeSimEditorWindow
    {
        #region Public Static Functions
        public static FreeSimConfigLoadWindow Get()
        {
            return FreeSimWorldBuilder.ActiveInstance.ConfigLoadWindow;
        }
        #endregion

        #region Public Methods
        public override string GetTitle()
        {
            return "FreeSim Config Load";
        }

        public override void ShowFreeSimWindow()
        {
            ShowDockable(true);
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            RenderContentInScrollView();
        }
        #endregion

        #region Private Methods
        private void RenderContentInScrollView()
        {
            EditorGUILayout.HelpBox("Please choose the settings you wish to load.", UnityEditor.MessageType.None);
            FreeSimWorldBuilder.ActiveInstance.ConfigLoadSettings.View.Render();
            RenderLoadButton();
        }

        private void RenderLoadButton()
        {
            if (GUILayout.Button(GetContentForLoadButton(), GUILayout.Width(100.0f)))
            {
                string fileName = EditorUtility.OpenFilePanel("Load FreeSim Config", FreeSimWorldBuilder.ActiveInstance.ConfigLoadSettings.LastUsedFolder, "o3dcfg");
                if (!string.IsNullOrEmpty(fileName))
                {
                    FreeSimConfigLoad.LoadConfig(fileName, FreeSimWorldBuilder.ActiveInstance.ConfigLoadSettings);
                    FreeSimWorldBuilder.ActiveInstance.ConfigLoadSettings.LastUsedFolder = FileSystem.GetLastFolderNameInPath(fileName);
                    FreeSimWorldBuilder.ActiveInstance.Inspector.Repaint();
                    EditorUtility.DisplayDialog("FreeSim Config Load", "The configuration was loaded successfully!", "OK");
                }
            }
        }

        private GUIContent GetContentForLoadButton()
        {
            var content = new GUIContent();
            content.text = "Load settings";
            content.tooltip = "Loads the selected settings to a specified file.";

            return content;
        }
        #endregion
    }
}
#endif