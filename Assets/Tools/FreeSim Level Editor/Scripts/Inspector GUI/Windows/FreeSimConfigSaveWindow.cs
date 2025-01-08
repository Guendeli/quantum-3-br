#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class FreeSimConfigSaveWindow : FreeSimEditorWindow
    {
        #region Public Static Functions
        public static FreeSimConfigSaveWindow Get()
        {
            return FreeSimWorldBuilder.ActiveInstance.ConfigSaveWindow;
        }
        #endregion

        #region Public Methods
        public override string GetTitle()
        {
            return "FreeSim Config Save";
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
            EditorGUILayout.HelpBox("Please choose the settings you wish to save.", UnityEditor.MessageType.None);
            FreeSimWorldBuilder.ActiveInstance.ConfigSaveSettings.View.Render();
            RenderSaveButton();
        }

        private void RenderSaveButton()
        {
            if(GUILayout.Button(GetContentForSaveButton(), GUILayout.Width(100.0f)))
            {
                string fileName = EditorUtility.SaveFilePanel("Save FreeSim Config", FreeSimWorldBuilder.ActiveInstance.ConfigSaveSettings.LastUsedFolder, "", "o3dcfg");
                if (!string.IsNullOrEmpty(fileName))
                {
                    FreeSimConfigSave.SaveConfig(fileName, FreeSimWorldBuilder.ActiveInstance.ConfigSaveSettings);
                    FreeSimWorldBuilder.ActiveInstance.ConfigSaveSettings.LastUsedFolder = FileSystem.GetLastFolderNameInPath(fileName);
                    EditorUtility.DisplayDialog("FreeSim Config Save", "The configuration was saved successfully!", "OK");
                }
            }
        }

        private GUIContent GetContentForSaveButton()
        {
            var content = new GUIContent();
            content.text = "Save settings";
            content.tooltip = "Saves the selected settings to a specified file.";

            return content;
        }
        #endregion
    }
}
#endif