#if UNITY_EDITOR
using UnityEngine;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace FreeSimEditor
{
    public static class FreeSimConfigSave
    {
        #region Public Static Functions
        public static void SaveConfig(string fileName, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            using (XmlTextWriter xmlWriter = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteNewLine(0);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.RootNode);

                SaveSnapSettings(xmlWriter, saveSettings);
                SaveObjectSelectionSettings(xmlWriter, saveSettings);
                SaveObjectErasingSettings(xmlWriter, saveSettings);
                SaveMirrorLookAndFeel(ObjectPlacement.Get().MirrorRenderSettings, xmlWriter, saveSettings, true);
                SaveMirrorLookAndFeel(ObjectSelection.Get().MirrorRenderSettings, xmlWriter, saveSettings, false);
                SaveSnapLookAndFeel(xmlWriter, saveSettings);
                SaveObjectPlacementLookAndFeel(xmlWriter, saveSettings);
                SaveObjectSelectionLookAndFeel(xmlWriter, saveSettings);
                SaveObjectErasingLookAndFeel(xmlWriter, saveSettings);

                xmlWriter.WriteNewLine(0);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }
        #endregion

        #region Private Static Functions
        private static void SaveSnapSettings(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.SnapSettings)
            {
                ObjectSnapSettings snapSettings = ObjectSnapSettings.Get();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapSettingsNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.UseOriginalPivotNode);
                xmlWriter.WriteString(snapSettings.UseOriginalPivot.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.EnableObjectSurfaceGrid);
                xmlWriter.WriteString(snapSettings.EnableObjectSurfaceGrid.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapToCursorHitPointNode);
                xmlWriter.WriteString(snapSettings.SnapToCursorHitPoint.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapCenterToCenterGridNode);
                xmlWriter.WriteString(snapSettings.SnapCenterToCenterForXZGrid.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapCenterToCenterObjectSurfaceNode);
                xmlWriter.WriteString(snapSettings.SnapCenterToCenterForObjectSurface.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.EnableObjectToObjectSnapNode);
                xmlWriter.WriteString(snapSettings.EnableObjectToObjectSnap.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectToObjectSnapEpsilonNode);
                xmlWriter.WriteString(snapSettings.ObjectToObjectSnapEpsilon.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapGridXOffsetNode);
                xmlWriter.WriteString(snapSettings.XZSnapGridXOffset.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapGridYOffsetNode);
                xmlWriter.WriteString(snapSettings.XZSnapGridYOffset.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapGridYOffsetStepNode);
                xmlWriter.WriteString(snapSettings.XZGridYOffsetStep.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapGridZOffsetNode);
                xmlWriter.WriteString(snapSettings.XZSnapGridZOffset.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSurfaceGridDesiredCellSizeNode);
                xmlWriter.WriteString(snapSettings.ObjectColliderSnapSurfaceGridSettings.DesiredCellSize.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapGridCellSizeXNode);
                xmlWriter.WriteString(ObjectSnapping.Get().XZSnapGrid.CellSizeSettings.CellSizeX.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapGridCellSizeZNode);
                xmlWriter.WriteString(ObjectSnapping.Get().XZSnapGrid.CellSizeSettings.CellSizeZ.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveObjectSelectionSettings(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.ObjectSelectionSettings)
            {
                ObjectSelectionSettings objectSelectionSettings = ObjectSelectionSettings.Get();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionSettingsNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionAttachToObjectGroupNode);
                xmlWriter.WriteString(objectSelectionSettings.ObjectGroupSettings.AttachToObjectGroup.ToString());
                xmlWriter.WriteEndElement();

                if (objectSelectionSettings.ObjectGroupSettings.DestinationGroup != null &&
                    objectSelectionSettings.ObjectGroupSettings.DestinationGroup.GroupObject != null)
                {
                    xmlWriter.WriteNewLine(2);
                    xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionDestinationObjectGroupNode);
                    xmlWriter.WriteString(objectSelectionSettings.ObjectGroupSettings.DestinationGroup.GroupObject.name);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionXRotationStepNode);
                xmlWriter.WriteString(objectSelectionSettings.XRotationStep.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionYRotationStepNode);
                xmlWriter.WriteString(objectSelectionSettings.YRotationStep.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionZRotationStepNode);
                xmlWriter.WriteString(objectSelectionSettings.ZRotationStep.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionRotateAroundCenterNode);
                xmlWriter.WriteString(objectSelectionSettings.RotateAroundSelectionCenter.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionObject2ObjectSnapSettingsNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionObj2ObjSnapEpsNode);
                xmlWriter.WriteString(objectSelectionSettings.Object2ObjectSnapSettings.SnapEps.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionObj2ObjSnapCanHoverObjectsNode);
                xmlWriter.WriteString(objectSelectionSettings.Object2ObjectSnapSettings.CanHoverObjects.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionAllowPartialOverlapNode);
                xmlWriter.WriteString(objectSelectionSettings.AllowPartialOverlap.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionShapeTypeNode);
                xmlWriter.WriteString(objectSelectionSettings.SelectionShapeType.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionUpdateModeNode);
                xmlWriter.WriteString(objectSelectionSettings.SelectionUpdateMode.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionModeNode);
                xmlWriter.WriteString(objectSelectionSettings.SelectionMode.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionPaint_ShapePixelWidthNode);
                xmlWriter.WriteString(objectSelectionSettings.PaintModeSettings.SelectionShapeWidthInPixels.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionPaint_ShapePixelHeightNode);
                xmlWriter.WriteString(objectSelectionSettings.PaintModeSettings.SelectionShapeHeightInPixels.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionPaint_SizeAdjustmentSpeedScrollWheelNode);
                xmlWriter.WriteString(objectSelectionSettings.PaintModeSettings.ScrollWheelShapeSizeAdjustmentSpeed.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveObjectErasingSettings(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.ObjectErasingSettings)
            {
                ObjectEraserSettings eraserSettings = ObjectEraserSettings.Get();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasingSettingsNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasingAllowUndoRedoNode);
                xmlWriter.WriteString(eraserSettings.AllowUndoRedo.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectEraseDelayNode);
                xmlWriter.WriteString(eraserSettings.EraseDelayInSeconds.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectEraseModeNode);
                xmlWriter.WriteString(eraserSettings.EraseMode.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectEraseOnlyMeshObjectsNode);
                xmlWriter.WriteString(eraserSettings.EraseOnlyMeshObjects.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectMassErase2D_CircleRadiusNode);
                xmlWriter.WriteString(eraserSettings.Mass2DEraseSettings.CircleShapeRadius.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectMassErase2D_RadiusAdjustmentSpeedScrollWheelNode);
                xmlWriter.WriteString(eraserSettings.Mass2DEraseSettings.ScrollWheelCircleRadiusAdjustmentSpeed.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectMassErase2D_AllowPartialOverlap);
                xmlWriter.WriteString(eraserSettings.Mass2DEraseSettings.AllowPartialOverlap.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectMassErase3D_CircleRadiusNode);
                xmlWriter.WriteString(eraserSettings.Mass3DEraseSettings.CircleShapeRadius.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectMassErase3D_RadiusAdjustmentSpeedScrollWheelNode);
                xmlWriter.WriteString(eraserSettings.Mass3DEraseSettings.ScrollWheelCircleRadiusAdjustmentSpeed.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectMassErase3D_AllowPartialOverlap);
                xmlWriter.WriteString(eraserSettings.Mass3DEraseSettings.AllowPartialOverlap.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveMirrorLookAndFeel(InteractableMirrorRenderSettings renderSettings, XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings, bool objectPlacementMirror)
        {
            if(saveSettings.MirrorLookAndFeel)
            {
                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(objectPlacementMirror ? FreeSimConfigXMLInfo.ObjectPlacementMirrorLookAndFeelNode : FreeSimConfigXMLInfo.ObjectSelectionMirrorLookAndFeelNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirrorWidthNode);
                xmlWriter.WriteString(renderSettings.MirrorWidth.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirrorHeightNode);
                xmlWriter.WriteString(renderSettings.MirrorHeight.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirrorHasInfiniteWidthNode);
                xmlWriter.WriteString(renderSettings.UseInfiniteWidth.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirrorHasInfiniteHeightNode);
                xmlWriter.WriteString(renderSettings.UseInfiniteHeight.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirrorColorNode);
                xmlWriter.WriteColorString(renderSettings.MirrorPlaneColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirrorBorderColorNode);
                xmlWriter.WriteColorString(renderSettings.MirrorPlaneBorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirroredBoxColorNode);
                xmlWriter.WriteColorString(renderSettings.MirroredBoxColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.MirroredBoxBorderColorNode);
                xmlWriter.WriteColorString(renderSettings.MirroredBoxBorderLineColor);
                xmlWriter.WriteEndElement();
                
                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveSnapLookAndFeel(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.SnapLookAndFeel)
            {
                XZGridRenderSettings xzGridRenderSettings = ObjectSnapping.Get().XZSnapGrid.RenderSettings;
                XZGridRenderSettings objSurfaceGridRenderSettings = ObjectSnapping.Get().RenderSettingsForColliderSnapSurfaceGrid;
                CoordinateSystemRenderSettings coordSystemRenderSettings = ObjectSnapping.Get().XZSnapGrid.RenderableCoordinateSystem.RenderSettings;

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.SnapLookAndFeelNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.IsXZGridVisibleNode);
                xmlWriter.WriteString(xzGridRenderSettings.IsVisible.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridCellLineColorNode);
                xmlWriter.WriteColorString(xzGridRenderSettings.CellLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridCellLineThicknessNode);
                xmlWriter.WriteString(xzGridRenderSettings.CellLineThickness.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridPlaneColorNode);
                xmlWriter.WriteColorString(xzGridRenderSettings.PlaneColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridCoordSystemLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.IsXZGridCoordSystemVisibleNode);
                xmlWriter.WriteString(coordSystemRenderSettings.IsVisible.ToString());
                xmlWriter.WriteEndElement();

                List<CoordinateSystemAxis> allAxes = CoordinateSystemAxes.GetAll();
                foreach(var axis in allAxes)
                {
                    xmlWriter.WriteNewLine(3);
                    xmlWriter.WriteStartElement(axis.ToString());

                    xmlWriter.WriteNewLine(4);
                    xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.IsXZGridCoordSystemAxisVisibleNode);
                    xmlWriter.WriteString(coordSystemRenderSettings.IsAxisVisible(axis).ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteNewLine(4);
                    xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.IsXZGridCoordSystemAxisInfiniteNode);
                    xmlWriter.WriteString(coordSystemRenderSettings.IsAxisRenderedInfinite(axis).ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteNewLine(4);
                    xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridCoordSystemAxisFiniteSizeNode);
                    xmlWriter.WriteString(coordSystemRenderSettings.GetAxisFinitSize(axis).ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteNewLine(4);
                    xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.XZGridCoordSystemAxisColorNode);
                    xmlWriter.WriteColorString(coordSystemRenderSettings.GetAxisColor(axis));
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteNewLine(3);
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSnapSurfaceGridLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.IsObjectSnapSurfaceGridVisibleNode);
                xmlWriter.WriteString(objSurfaceGridRenderSettings.IsVisible.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSnapSurfaceGridCellLineColorNode);
                xmlWriter.WriteColorString(objSurfaceGridRenderSettings.CellLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSnapSurfaceGridCellLineThicknessNode);
                xmlWriter.WriteString(objSurfaceGridRenderSettings.CellLineThickness.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSnapSurfaceGridPlaneColorNode);
                xmlWriter.WriteColorString(objSurfaceGridRenderSettings.PlaneColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveObjectPlacementLookAndFeel(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.ObjectPlacementLookAndFeel)
            {
                ObjectPivotPointsRenderSettings pivotPointsRenderSettings = ObjectPlacement.Get().GuidePivotPointsRenderSettings;
                ProjectedBoxFacePivotPointsRenderSettings projectedPivotPointRenderSettings = pivotPointsRenderSettings.ProjectedBoxFacePivotPointsRenderSettings;
                ObjectVertexSnapSessionRenderSettings vertexSnapRenderSettings = ObjectPlacement.Get().ObjectVertexSnapSessionRenderSettings;

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectPlacementLookAndFeelNode);

                // Pivot points
                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.GuidePivotPointsLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.GuidePivotPointsShapeTypeNode);
                xmlWriter.WriteString(pivotPointsRenderSettings.ShapeType.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.GuidePivotPointsShapeSizeInPixelsNode);
                xmlWriter.WriteString(pivotPointsRenderSettings.PivotPointSizeInPixels.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.DrawPivotPointProjectionLinesNode);
                xmlWriter.WriteString(projectedPivotPointRenderSettings.RenderProjectionLines.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointProjectionLineColorNode);
                xmlWriter.WriteColorString(projectedPivotPointRenderSettings.ProjectionLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.DrawPivotPointConnectionLinesNode);
                xmlWriter.WriteString(projectedPivotPointRenderSettings.RenderPivotPointConnectionLines.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointConnectionLineColorNode);
                xmlWriter.WriteColorString(projectedPivotPointRenderSettings.PivotPointConnectionLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ActivePivotPointLookAndFeelNode);

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointIsVisibleNode);
                xmlWriter.WriteString(projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.IsVisible.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointFillColorNode);
                xmlWriter.WriteColorString(projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.FillColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointBorderColorNode);
                xmlWriter.WriteColorString(projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointScaleNode);
                xmlWriter.WriteString(projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.Scale.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.InactivePivotPointLookAndFeelNode);

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointIsVisibleNode);
                xmlWriter.WriteString(projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.IsVisible.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointFillColorNode);
                xmlWriter.WriteColorString(projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.FillColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointBorderColorNode);
                xmlWriter.WriteColorString(projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PivotPointScaleNode);
                xmlWriter.WriteString(projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.Scale.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                // Vertex snapping
                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectVertexSnappingLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectVertexSnappingDrawSrcVertexNode);
                xmlWriter.WriteString(vertexSnapRenderSettings.RenderSourceVertex.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectVertexSnappingSrcVertexFillColorNode);
                xmlWriter.WriteColorString(vertexSnapRenderSettings.SourceVertexFillColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectVertexSnappingSrcVertexBorderColorNode);
                xmlWriter.WriteColorString(vertexSnapRenderSettings.SourceVertexBorderColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectVertexSnappingSrcVertexPixelRadiusNode);
                xmlWriter.WriteString(vertexSnapRenderSettings.SourceVertexRadiusInPixels.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                // Decor paint
                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.DecorPaintLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.DecorPaintBrushCircleLookAndFeelNode);

                xmlWriter.WriteNewLine(4);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.DecorPaintBrushCircleBorderLineColorNode);
                xmlWriter.WriteColorString(ObjectPlacement.Get().DecorPaintObjectPlacement.BrushCircleRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                // Path
                ObjectPlacementPathRenderSettings pathRenderSettings = ObjectPlacement.Get().PathObjectPlacement.PathRenderSettings;
                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PathLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.PathBorderLineColorNode);
                xmlWriter.WriteColorString(pathRenderSettings.ManualConstructionRenderSettings.BoxBorderLineColor);
                xmlWriter.WriteEndElement();

                SaveExtensionPlaneLookAndFeel(ObjectPlacement.Get().PathObjectPlacement.PathExtensionPlaneRenderSettings, xmlWriter, 3);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                // Block
                ObjectPlacementBlockRenderSettings blockRenderSettings = ObjectPlacement.Get().BlockObjectPlacement.BlockRenderSettings;
                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.BlockLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.BlockBorderLineColorNode);
                xmlWriter.WriteColorString(blockRenderSettings.ManualConstructionRenderSettings.BoxBorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.BlockTextColorNode);
                xmlWriter.WriteColorString(blockRenderSettings.ManualConstructionRenderSettings.DimensionsLabelRenderSettings.TextColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.BlockFontSizeNode);
                xmlWriter.WriteString(blockRenderSettings.ManualConstructionRenderSettings.DimensionsLabelRenderSettings.FontSize.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.BlockBoldTextNode);
                xmlWriter.WriteString(blockRenderSettings.ManualConstructionRenderSettings.DimensionsLabelRenderSettings.Bold.ToString());
                xmlWriter.WriteEndElement();

                SaveExtensionPlaneLookAndFeel(ObjectPlacement.Get().BlockObjectPlacement.BlockExtensionPlaneRenderSettings, xmlWriter, 3);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveExtensionPlaneLookAndFeel(ObjectPlacementExtensionPlaneRenderSettings extensionPlaneRenderSettings, XmlTextWriter xmlWriter, int indent)
        {
            xmlWriter.WriteNewLine(indent);
            xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ExtensionPlaneLookAndFeelNode);

            int childIndent = indent + 1;
            xmlWriter.WriteNewLine(childIndent);
            xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ExtensionPlaneScaleNode);
            xmlWriter.WriteString(extensionPlaneRenderSettings.PlaneScale.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteNewLine(childIndent);
            xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ExtensionPlaneColorNode);
            xmlWriter.WriteColorString(extensionPlaneRenderSettings.PlaneColor);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteNewLine(childIndent);
            xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ExtensionPlaneBorderColorNode);
            xmlWriter.WriteColorString(extensionPlaneRenderSettings.PlaneBorderLineColor);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteNewLine(childIndent);
            xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ExtensionPlaneNormalLineLengthNode);
            xmlWriter.WriteString(extensionPlaneRenderSettings.PlaneNormalLineLength.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteNewLine(childIndent);
            xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ExtensionPlaneNormalLineColorNode);
            xmlWriter.WriteColorString(extensionPlaneRenderSettings.PlaneNormalLineColor);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteNewLine(indent);
            xmlWriter.WriteEndElement();
        }

        private static void SaveObjectSelectionLookAndFeel(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.ObjectSelectionLookAndFeel)
            {
                ObjectSelectionRenderSettings selectionRenderSettings = ObjectSelection.Get().RenderSettings;
                RectangleShapeRenderSettings rectRenderSettings = ObjectSelection.Get().RectangleSelectionShapeRenderSettings;
                EllipseShapeRenderSettings ellipseRenderSettings = ObjectSelection.Get().EllipseSelectionShapeRenderSettings;

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionLookAndFeelNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionBoxEdgeDrawModeNode);
                xmlWriter.WriteString(selectionRenderSettings.BoxRenderModeSettings.EdgeRenderMode.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionBoxCornerEdgeLengthPercentageNode);
                xmlWriter.WriteString(selectionRenderSettings.BoxRenderModeSettings.CornerEdgesRenderModeSettings.CornerEdgeLengthPercentage.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionBoxEdgeColorNode);
                xmlWriter.WriteColorString(selectionRenderSettings.BoxRenderModeSettings.EdgeColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionBoxColorNode);
                xmlWriter.WriteColorString(selectionRenderSettings.BoxRenderModeSettings.BoxColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionBoxScaleNode);
                xmlWriter.WriteString(selectionRenderSettings.BoxRenderModeSettings.BoxScale.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionRectLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionShapeFillColorNode);
                xmlWriter.WriteColorString(rectRenderSettings.FillColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionShapeBorderColorNode);
                xmlWriter.WriteColorString(rectRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionEllipseLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionShapeFillColorNode);
                xmlWriter.WriteColorString(ellipseRenderSettings.FillColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectSelectionShapeBorderColorNode);
                xmlWriter.WriteColorString(ellipseRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }

        private static void SaveObjectErasingLookAndFeel(XmlTextWriter xmlWriter, FreeSimConfigSaveLoadSettings saveSettings)
        {
            if(saveSettings.ObjectErasingLookAndFeel)
            {
                EllipseShapeRenderSettings circle2DRenderSettings = ObjectEraser.Get().Circle2DMassEraseShapeRenderSettings;
                XZOrientedEllipseShapeRenderSettings circle3DRenderSettings = ObjectEraser.Get().Circle3DMassEraseShapeRenderSettings;

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasingLookAndFeelNode);

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasing2DCircleLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasingShapeFillColorNode);
                xmlWriter.WriteColorString(circle2DRenderSettings.FillColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasingShapeBorderColorNode);
                xmlWriter.WriteColorString(circle2DRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasing3DCircleLookAndFeelNode);

                xmlWriter.WriteNewLine(3);
                xmlWriter.WriteStartElement(FreeSimConfigXMLInfo.ObjectErasingShapeBorderColorNode);
                xmlWriter.WriteColorString(circle3DRenderSettings.BorderLineColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(2);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteNewLine(1);
                xmlWriter.WriteEndElement();
            }
        }
        #endregion
    }
}
#endif