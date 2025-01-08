#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

namespace FreeSimEditor
{
    [Serializable]
    public class DecorPaintBrushViewLookAndFeelWindow : FreeSimEditorWindow 
    {
        [SerializeField]
        private Vector2 _scrollViewPosition = Vector2.zero;
        [NonSerialized]
        private DecorPaintBrushViewData _viewData;

        public DecorPaintBrushViewData ViewData { set { _viewData = value; } }


        #region Public Static Functions
        public static DecorPaintBrushViewLookAndFeelWindow Get()
        {
            return FreeSimWorldBuilder.ActiveInstance.EditorWindowPool.DecorPaintBrushViewLookAndFeelWindow;
        }
        #endregion

        #region Public Methods
        public override string GetTitle()
        {
            return "Brush View Look And Feel";
        }

        public override void ShowFreeSimWindow()
        {
            ShowDockable(true);
        }
        #endregion

        #region Protected Methods
        protected override void RenderContent()
        {
            if (_viewData == null) return;
            _scrollViewPosition = EditorGUILayout.BeginScrollView(_scrollViewPosition);

            var content = new GUIContent();
            content.text = "Element view height";
            content.tooltip = "Controls the height of the area in which the brush elements are displayed.";
            int newInt = EditorGUILayout.IntField(content, _viewData.ElementsScrollViewHeight);
            if(newInt != _viewData.ElementsScrollViewHeight)
            {
                UndoEx.RecordForToolAction(_viewData);
                _viewData.ElementsScrollViewHeight = newInt;
                FreeSimWorldBuilder.ActiveInstance.Inspector.Repaint();
            }

            content.text = "Num elements per row";
            content.tooltip = "Controls the number of elements which appear in a single row.";
            newInt = EditorGUILayout.IntField(content, _viewData.NumElementsPerRow);
            if (newInt != _viewData.NumElementsPerRow)
            {
                UndoEx.RecordForToolAction(_viewData);
                _viewData.NumElementsPerRow = newInt;
                FreeSimWorldBuilder.ActiveInstance.Inspector.Repaint();
            }

            content.text = "Element preview scale";
            content.tooltip = "The scale of the element preview images.";
            float newFloat = EditorGUILayout.FloatField(content, _viewData.ElementPreviewScale);
            if(newFloat != _viewData.ElementPreviewScale)
            {
                UndoEx.RecordForToolAction(_viewData);
                _viewData.ElementPreviewScale = newFloat;
                FreeSimWorldBuilder.ActiveInstance.Inspector.Repaint();
            }

            content.text = "Active element tint";
            content.tooltip = "The tint color for the active element.";
            Color newColor = EditorGUILayout.ColorField(content, _viewData.ActiveElementTintColor);
            if(newColor != _viewData.ActiveElementTintColor)
            {
                UndoEx.RecordForToolAction(_viewData);
                _viewData.ActiveElementTintColor = newColor;
                FreeSimWorldBuilder.ActiveInstance.Inspector.Repaint();
            }

            content.text = "Disabled element tint";
            content.tooltip = "The tint color for disabled elements.";
            newColor = EditorGUILayout.ColorField(content, _viewData.DisabledElementTintColor);
            if (newColor != _viewData.DisabledElementTintColor)
            {
                UndoEx.RecordForToolAction(_viewData);
                _viewData.DisabledElementTintColor = newColor;
                FreeSimWorldBuilder.ActiveInstance.Inspector.Repaint();
            }
            EditorGUILayout.EndScrollView();
        }
        #endregion
    }
}
#endif