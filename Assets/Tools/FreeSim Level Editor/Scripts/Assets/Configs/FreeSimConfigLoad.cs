#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace FreeSimEditor
{
    public static class FreeSimConfigLoad
    {
        #region Public Static Functions
        public static void LoadConfig(string fileName, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            LoadSnapSettings(xmlDoc, loadSettings);
            LoadObjectSelectionSettings(xmlDoc, loadSettings);
            LoadObjectErasingSettings(xmlDoc, loadSettings);
            LoadMirrorLookAndFeel(xmlDoc, loadSettings, ObjectPlacement.Get().MirrorRenderSettings, true);
            LoadMirrorLookAndFeel(xmlDoc, loadSettings, ObjectSelection.Get().MirrorRenderSettings, false);
            LoadSnapLookAndFeel(xmlDoc, loadSettings);
            LoadObjectPlacementLookAndFeel(xmlDoc, loadSettings);
            LoadObjectSelectionLookAndFeel(xmlDoc, loadSettings);
            LoadObjectErasingLookAndFeel(xmlDoc, loadSettings);
        }
        #endregion

        #region Private Static Functions
        private static void LoadSnapSettings(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if(loadSettings.SnapSettings)
            {
                XmlNode snapSettingsNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.SnapSettingsNode);
                if(snapSettingsNode != null)
                {
                    ObjectSnapSettings snapSettings = ObjectSnapSettings.Get();

                    XmlNode node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.UseOriginalPivotNode);
                    if(node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) snapSettings.UseOriginalPivot = boolRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.EnableObjectSurfaceGrid);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) snapSettings.EnableObjectSurfaceGrid = boolRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapToCursorHitPointNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) snapSettings.SnapToCursorHitPoint = boolRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapCenterToCenterGridNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) snapSettings.SnapCenterToCenterForXZGrid = boolRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapCenterToCenterObjectSurfaceNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) snapSettings.SnapCenterToCenterForObjectSurface = boolRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.EnableObjectToObjectSnapNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) snapSettings.EnableObjectToObjectSnap = boolRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectToObjectSnapEpsilonNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) snapSettings.ObjectToObjectSnapEpsilon = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapGridXOffsetNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) snapSettings.XZSnapGridXOffset = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapGridYOffsetNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) snapSettings.XZSnapGridYOffset = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapGridYOffsetStepNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) snapSettings.XZGridYOffsetStep = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapGridZOffsetNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) snapSettings.XZSnapGridZOffset = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSurfaceGridDesiredCellSizeNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) snapSettings.ObjectColliderSnapSurfaceGridSettings.DesiredCellSize = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapGridCellSizeXNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) ObjectSnapping.Get().XZSnapGrid.CellSizeSettings.CellSizeX = floatRes;
                    }

                    node = snapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.SnapGridCellSizeZNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) ObjectSnapping.Get().XZSnapGrid.CellSizeSettings.CellSizeZ = floatRes;
                    }
                }
            }
        }

        private static void LoadObjectSelectionSettings(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if(loadSettings.ObjectSelectionSettings)
            {
                XmlNode selectionSettingsNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.ObjectSelectionSettingsNode);
                if(selectionSettingsNode != null)
                {
                    ObjectSelectionSettings objectSelectionSettings = ObjectSelectionSettings.Get();

                    XmlNode node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionAllowPartialOverlapNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectSelectionSettings.AllowPartialOverlap = boolRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionAttachToObjectGroupNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectSelectionSettings.ObjectGroupSettings.AttachToObjectGroup = boolRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionDestinationObjectGroupNode);
                    if (node != null && !string.IsNullOrEmpty(node.InnerText))
                    {
                        ObjectGroupDatabase groupDatabase = FreeSimWorldBuilder.ActiveInstance.PlacementObjectGroupDatabase;
                        ObjectGroup objectGroup = groupDatabase.GetObjectGroupByName(node.InnerText);
                        if (objectGroup != null) objectSelectionSettings.ObjectGroupSettings.DestinationGroup = objectGroup;
                        else
                        {
                            ObjectGroup newGroup = groupDatabase.CreateObjectGroup(node.InnerText);
                            if (newGroup != null) objectSelectionSettings.ObjectGroupSettings.DestinationGroup = objectGroup;
                        }
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionXRotationStepNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) objectSelectionSettings.XRotationStep = floatRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionYRotationStepNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) objectSelectionSettings.YRotationStep = floatRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionZRotationStepNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) objectSelectionSettings.ZRotationStep = floatRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionRotateAroundCenterNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectSelectionSettings.RotateAroundSelectionCenter = boolRes;
                    }

                    XmlNode obj2objSnapSettingsNode = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionObject2ObjectSnapSettingsNode);
                    if(obj2objSnapSettingsNode != null)
                    {
                        node = obj2objSnapSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionObj2ObjSnapEpsNode);
                        if (node != null)
                        {
                            float floatRes;
                            if (float.TryParse(node.InnerText, out floatRes)) objectSelectionSettings.Object2ObjectSnapSettings.SnapEps = floatRes;
                        }

                        node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionObj2ObjSnapCanHoverObjectsNode);
                        if (node != null)
                        {
                            bool boolRes;
                            if (bool.TryParse(node.InnerText, out boolRes)) objectSelectionSettings.Object2ObjectSnapSettings.CanHoverObjects = boolRes;
                        }
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionShapeTypeNode);
                    if (node != null)
                    {
                        try
                        {
                            objectSelectionSettings.SelectionShapeType = (ObjectSelectionShapeType)Enum.Parse(typeof(ObjectSelectionShapeType), node.InnerText);
                        }
                        catch (Exception) { }
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionUpdateModeNode);
                    if (node != null)
                    {
                        try
                        {
                            objectSelectionSettings.SelectionUpdateMode = (ObjectSelectionUpdateMode)Enum.Parse(typeof(ObjectSelectionUpdateMode), node.InnerText);
                        }
                        catch (Exception) { }
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionModeNode);
                    if (node != null)
                    {
                        try
                        {
                            objectSelectionSettings.SelectionMode = (ObjectSelectionMode)Enum.Parse(typeof(ObjectSelectionMode), node.InnerText);
                        }
                        catch (Exception) { }
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionPaint_ShapePixelWidthNode);
                    if (node != null)
                    {
                        int intRes;
                        if (int.TryParse(node.InnerText, out intRes)) objectSelectionSettings.PaintModeSettings.SelectionShapeWidthInPixels = intRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionPaint_ShapePixelHeightNode);
                    if (node != null)
                    {
                        int intRes;
                        if (int.TryParse(node.InnerText, out intRes)) objectSelectionSettings.PaintModeSettings.SelectionShapeHeightInPixels = intRes;
                    }

                    node = selectionSettingsNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionPaint_SizeAdjustmentSpeedScrollWheelNode);
                    if (node != null)
                    {
                        int intRes;
                        if (int.TryParse(node.InnerText, out intRes)) objectSelectionSettings.PaintModeSettings.ScrollWheelShapeSizeAdjustmentSpeed = intRes;
                    }
                }
            }
        }

        private static void LoadObjectErasingSettings(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if(loadSettings.ObjectErasingSettings)
            {
                XmlNode objectErasingNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.ObjectErasingSettingsNode);
                if (objectErasingNode != null)
                {
                    ObjectEraserSettings objectEraserSettings = ObjectEraserSettings.Get();

                    XmlNode node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectErasingAllowUndoRedoNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectEraserSettings.AllowUndoRedo = boolRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectEraseDelayNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) objectEraserSettings.EraseDelayInSeconds = floatRes;
                    }


                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectEraseModeNode);
                    if (node != null)
                    {
                        try
                        {
                            objectEraserSettings.EraseMode = (ObjectEraseMode)Enum.Parse(typeof(ObjectEraseMode), node.InnerText);
                        }
                        catch (Exception) { }
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectEraseOnlyMeshObjectsNode);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectEraserSettings.EraseOnlyMeshObjects = boolRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectMassErase2D_CircleRadiusNode);
                    if (node != null)
                    {
                        int intRes;
                        if (int.TryParse(node.InnerText, out intRes)) objectEraserSettings.Mass2DEraseSettings.CircleShapeRadius = intRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectMassErase2D_RadiusAdjustmentSpeedScrollWheelNode);
                    if (node != null)
                    {
                        int intRes;
                        if (int.TryParse(node.InnerText, out intRes)) objectEraserSettings.Mass2DEraseSettings.ScrollWheelCircleRadiusAdjustmentSpeed = intRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectMassErase2D_AllowPartialOverlap);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectEraserSettings.Mass2DEraseSettings.AllowPartialOverlap = boolRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectMassErase3D_CircleRadiusNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) objectEraserSettings.Mass3DEraseSettings.CircleShapeRadius = floatRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectMassErase3D_RadiusAdjustmentSpeedScrollWheelNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) objectEraserSettings.Mass3DEraseSettings.ScrollWheelCircleRadiusAdjustmentSpeed = floatRes;
                    }

                    node = objectErasingNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectMassErase3D_AllowPartialOverlap);
                    if (node != null)
                    {
                        bool boolRes;
                        if (bool.TryParse(node.InnerText, out boolRes)) objectEraserSettings.Mass3DEraseSettings.AllowPartialOverlap = boolRes;
                    }
                }
            }
        }

        private static void LoadMirrorLookAndFeel(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings, InteractableMirrorRenderSettings renderSettings, bool objectPlacementMirror)
        {
            if (loadSettings.MirrorLookAndFeel)
            {
                XmlNode mirrorLookAndFeelNode = xmlDoc.SelectSingleNode("//" + (objectPlacementMirror ? FreeSimConfigXMLInfo.ObjectPlacementMirrorLookAndFeelNode : FreeSimConfigXMLInfo.ObjectSelectionMirrorLookAndFeelNode));
                if (mirrorLookAndFeelNode != null)
                {
                    XmlNode node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirrorWidthNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) renderSettings.MirrorWidth = floatRes;
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirrorHeightNode);
                    if (node != null)
                    {
                        float floatRes;
                        if (float.TryParse(node.InnerText, out floatRes)) renderSettings.MirrorHeight = floatRes;
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirrorHasInfiniteWidthNode);
                    if (node != null)
                    {
                        bool res;
                        if (bool.TryParse(node.InnerText, out res)) renderSettings.UseInfiniteWidth = res;
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirrorHasInfiniteHeightNode);
                    if (node != null)
                    {
                        bool res;
                        if (bool.TryParse(node.InnerText, out res)) renderSettings.UseInfiniteHeight = res;
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirrorColorNode);
                    if (node != null)
                    {
                        renderSettings.MirrorPlaneColor = ColorExtensions.FromString(node.InnerText);
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirrorBorderColorNode);
                    if (node != null)
                    {
                        renderSettings.MirrorPlaneBorderLineColor = ColorExtensions.FromString(node.InnerText);
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirroredBoxColorNode);
                    if (node != null)
                    {
                        renderSettings.MirroredBoxColor = ColorExtensions.FromString(node.InnerText);
                    }

                    node = mirrorLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.MirroredBoxBorderColorNode);
                    if (node != null)
                    {
                        renderSettings.MirroredBoxBorderLineColor = ColorExtensions.FromString(node.InnerText);
                    }
                }
            }
        }

        private static void LoadSnapLookAndFeel(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if(loadSettings.SnapLookAndFeel)
            {
                XmlNode snapLookAndFeelNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.SnapLookAndFeelNode);
                if(snapLookAndFeelNode != null)
                {
                    XZGridRenderSettings xzGridRenderSettings = ObjectSnapping.Get().XZSnapGrid.RenderSettings;
                    XZGridRenderSettings objSurfaceGridRenderSettings = ObjectSnapping.Get().RenderSettingsForColliderSnapSurfaceGrid;
                    CoordinateSystemRenderSettings coordSystemRenderSettings = ObjectSnapping.Get().XZSnapGrid.RenderableCoordinateSystem.RenderSettings;

                    XmlNode xzGridLookAndFeelNode = snapLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridLookAndFeelNode);
                    if(xzGridLookAndFeelNode != null)
                    {
                        XmlNode node = xzGridLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.IsXZGridVisibleNode);
                        if (node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) xzGridRenderSettings.IsVisible = res;
                        }

                        node = xzGridLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridCellLineColorNode);
                        if (node != null)
                        {
                            xzGridRenderSettings.CellLineColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = xzGridLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridCellLineThicknessNode);
                        if (node != null)
                        {
                            float res;
                            if (float.TryParse(node.InnerText, out res)) xzGridRenderSettings.CellLineThickness = res;
                        }

                        node = xzGridLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridPlaneColorNode);
                        if (node != null)
                        {
                            xzGridRenderSettings.PlaneColor = ColorExtensions.FromString(node.InnerText);
                        }
                    }

                    XmlNode xzGridCoordSystemLookAndFeelNode = snapLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridCoordSystemLookAndFeelNode);
                    if(xzGridCoordSystemLookAndFeelNode != null)
                    {
                        XmlNode node = xzGridCoordSystemLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.IsXZGridCoordSystemVisibleNode);
                        if(node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) coordSystemRenderSettings.IsVisible = res;
                        }

                        List<CoordinateSystemAxis> allAxes = CoordinateSystemAxes.GetAll();
                        foreach(var axis in allAxes)
                        {
                            node = xzGridCoordSystemLookAndFeelNode.SelectSingleNode(".//" + axis.ToString());
                            if(node != null)
                            {
                                XmlNode axisPropNode = node.SelectSingleNode(".//" + FreeSimConfigXMLInfo.IsXZGridCoordSystemAxisVisibleNode);
                                if(axisPropNode != null)
                                {
                                    bool res;
                                    if (bool.TryParse(axisPropNode.InnerText, out res)) coordSystemRenderSettings.SetAxisVisible(axis, res);
                                }

                                axisPropNode = node.SelectSingleNode(".//" + FreeSimConfigXMLInfo.IsXZGridCoordSystemAxisInfiniteNode);
                                if (axisPropNode != null)
                                {
                                    bool res;
                                    if (bool.TryParse(axisPropNode.InnerText, out res)) coordSystemRenderSettings.SetAxisRenderInfinite(axis, res);
                                }

                                axisPropNode = node.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridCoordSystemAxisFiniteSizeNode);
                                if (axisPropNode != null)
                                {
                                    float res;
                                    if (float.TryParse(axisPropNode.InnerText, out res)) coordSystemRenderSettings.SetAxisFiniteSize(axis, res);
                                }

                                axisPropNode = node.SelectSingleNode(".//" + FreeSimConfigXMLInfo.XZGridCoordSystemAxisColorNode);
                                if (axisPropNode != null)
                                {
                                    coordSystemRenderSettings.SetAxisColor(axis, ColorExtensions.FromString(axisPropNode.InnerText));
                                }
                            }
                        }
                    }

                    XmlNode objectSnapSurfaceLookAndFeelNode = snapLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSnapSurfaceGridLookAndFeelNode);
                    if(objectSnapSurfaceLookAndFeelNode != null)
                    {
                        XmlNode node = objectSnapSurfaceLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.IsObjectSnapSurfaceGridVisibleNode);
                        if(node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) objSurfaceGridRenderSettings.IsVisible = res;
                        }

                        node = objectSnapSurfaceLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSnapSurfaceGridCellLineColorNode);
                        if (node != null)
                        {
                            objSurfaceGridRenderSettings.CellLineColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = objectSnapSurfaceLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSnapSurfaceGridCellLineThicknessNode);
                        if (node != null)
                        {
                            float res;
                            if (float.TryParse(node.InnerText, out res)) objSurfaceGridRenderSettings.CellLineThickness = res;
                        }

                        node = objectSnapSurfaceLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSnapSurfaceGridPlaneColorNode);
                        if (node != null)
                        {
                            objSurfaceGridRenderSettings.PlaneColor = ColorExtensions.FromString(node.InnerText);
                        }
                    }
                }
            }
        }

        public static void LoadObjectPlacementLookAndFeel(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if(loadSettings.ObjectPlacementLookAndFeel)
            {
                ObjectPivotPointsRenderSettings pivotPointsRenderSettings = ObjectPlacement.Get().GuidePivotPointsRenderSettings;
                ProjectedBoxFacePivotPointsRenderSettings projectedPivotPointRenderSettings = pivotPointsRenderSettings.ProjectedBoxFacePivotPointsRenderSettings;
                ObjectVertexSnapSessionRenderSettings vertexSnapRenderSettings = ObjectPlacement.Get().ObjectVertexSnapSessionRenderSettings;

                XmlNode objPlacementLookAndFeelNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.ObjectPlacementLookAndFeelNode);
                if(objPlacementLookAndFeelNode != null)
                {
                    XmlNode guidePivotPointLookAndFeelNode = objPlacementLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.GuidePivotPointsLookAndFeelNode);
                    if(guidePivotPointLookAndFeelNode != null)
                    {
                        XmlNode node = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.GuidePivotPointsShapeTypeNode);
                        if(node != null)
                        {
                            try
                            {
                                pivotPointsRenderSettings.ShapeType = (ObjectPivotPointShapeType)Enum.Parse(typeof(ObjectPivotPointShapeType), node.InnerText);
                            }
                            catch (Exception) { }
                        }

                        node = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.GuidePivotPointsShapeSizeInPixelsNode);
                        if(node != null)
                        {
                            float res;
                            if (float.TryParse(node.InnerText, out res)) pivotPointsRenderSettings.PivotPointSizeInPixels = res;
                        }

                        node = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.DrawPivotPointProjectionLinesNode);
                        if (node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) projectedPivotPointRenderSettings.RenderProjectionLines = res;
                        }

                        node = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointProjectionLineColorNode);
                        if (node != null)
                        {
                            projectedPivotPointRenderSettings.ProjectionLineColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.DrawPivotPointConnectionLinesNode);
                        if (node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) projectedPivotPointRenderSettings.RenderPivotPointConnectionLines = res;
                        }

                        node = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointConnectionLineColorNode);
                        if (node != null)
                        {
                            projectedPivotPointRenderSettings.PivotPointConnectionLineColor = ColorExtensions.FromString(node.InnerText);
                        }

                        XmlNode activePivotPointLookAndFeelNode = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ActivePivotPointLookAndFeelNode);
                        if(activePivotPointLookAndFeelNode != null)
                        {
                            node = activePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointIsVisibleNode);
                            if(node != null)
                            {
                                bool res;
                                if (bool.TryParse(node.InnerText, out res)) projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.IsVisible = res;
                            }

                            node = activePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointFillColorNode);
                            if (node != null)
                            {
                                projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.FillColor = ColorExtensions.FromString(node.InnerText);
                            }

                            node = activePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointBorderColorNode);
                            if (node != null)
                            {
                                projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                            }

                            node = activePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointScaleNode);
                            if (node != null)
                            {
                                float res;
                                if (float.TryParse(node.InnerText, out res)) projectedPivotPointRenderSettings.ActivePivotPointRenderSettings.Scale = res;
                            }
                        }

                        XmlNode inactivePivotPointLookAndFeelNode = guidePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.InactivePivotPointLookAndFeelNode);
                        if (activePivotPointLookAndFeelNode != null)
                        {
                            node = inactivePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointIsVisibleNode);
                            if (node != null)
                            {
                                bool res;
                                if (bool.TryParse(node.InnerText, out res)) projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.IsVisible = res;
                            }

                            node = inactivePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointFillColorNode);
                            if (node != null)
                            {
                                projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.FillColor = ColorExtensions.FromString(node.InnerText);
                            }

                            node = inactivePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointBorderColorNode);
                            if (node != null)
                            {
                                projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                            }

                            node = inactivePivotPointLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PivotPointScaleNode);
                            if (node != null)
                            {
                                float res;
                                if (float.TryParse(node.InnerText, out res)) projectedPivotPointRenderSettings.InactivePivotPointRenderSettings.Scale = res;
                            }
                        }
                    }

                    XmlNode vertexSnappingLookAndFeelNode = objPlacementLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectVertexSnappingLookAndFeelNode);
                    if(vertexSnappingLookAndFeelNode != null)
                    {
                        XmlNode node = vertexSnappingLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectVertexSnappingDrawSrcVertexNode);
                        if(node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) vertexSnapRenderSettings.RenderSourceVertex = res;
                        }

                        node = vertexSnappingLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectVertexSnappingSrcVertexFillColorNode);
                        if (node != null)
                        {
                            vertexSnapRenderSettings.SourceVertexFillColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = vertexSnappingLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectVertexSnappingSrcVertexBorderColorNode);
                        if (node != null)
                        {
                            vertexSnapRenderSettings.SourceVertexBorderColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = vertexSnappingLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectVertexSnappingSrcVertexPixelRadiusNode);
                        if (node != null)
                        {
                            float res;
                            if (float.TryParse(node.InnerText, out res)) vertexSnapRenderSettings.SourceVertexRadiusInPixels = res;
                        }
                    }

                    XmlNode decorPaintLookAndFeelNode = objPlacementLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.DecorPaintLookAndFeelNode);
                    if(decorPaintLookAndFeelNode != null)
                    {
                        XmlNode decorPaintBrushLookAndFeelNode = decorPaintLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.DecorPaintBrushCircleLookAndFeelNode);
                        if(decorPaintBrushLookAndFeelNode != null)
                        {
                            XmlNode node = decorPaintBrushLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.DecorPaintBrushCircleBorderLineColorNode);
                            if(node != null)
                            {
                                ObjectPlacement.Get().DecorPaintObjectPlacement.BrushCircleRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                            }
                        }
                    }

                    XmlNode pathLookAndFeelNode = objPlacementLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PathLookAndFeelNode);
                    if(pathLookAndFeelNode != null)
                    {
                        ObjectPlacementPathRenderSettings pathRenderSettings = ObjectPlacement.Get().PathObjectPlacement.PathRenderSettings;

                        XmlNode node = pathLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.PathBorderLineColorNode);
                        if(node != null)
                        {
                            pathRenderSettings.ManualConstructionRenderSettings.BoxBorderLineColor = ColorExtensions.FromString(node.InnerText);
                        }

                        LoadExtensionPlaneLookAndFeel(ObjectPlacement.Get().PathObjectPlacement.PathExtensionPlaneRenderSettings, pathLookAndFeelNode);
                    }

                    XmlNode blockLookAndFeelNode = objPlacementLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.BlockLookAndFeelNode);
                    if(blockLookAndFeelNode != null)
                    {
                        ObjectPlacementBlockRenderSettings blockRenderSettings = ObjectPlacement.Get().BlockObjectPlacement.BlockRenderSettings;

                        XmlNode node = blockLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.BlockBorderLineColorNode);
                        if (node != null)
                        {
                            blockRenderSettings.ManualConstructionRenderSettings.BoxBorderLineColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = blockLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.BlockTextColorNode);
                        if (node != null)
                        {
                            blockRenderSettings.ManualConstructionRenderSettings.DimensionsLabelRenderSettings.TextColor = ColorExtensions.FromString(node.InnerText);
                        }

                        node = blockLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.BlockFontSizeNode);
                        if (node != null)
                        {
                            int res;
                            if (int.TryParse(node.InnerText, out res)) blockRenderSettings.ManualConstructionRenderSettings.DimensionsLabelRenderSettings.FontSize = res;
                        }

                        node = blockLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.BlockBoldTextNode);
                        if (node != null)
                        {
                            bool res;
                            if (bool.TryParse(node.InnerText, out res)) blockRenderSettings.ManualConstructionRenderSettings.DimensionsLabelRenderSettings.Bold = res;
                        }

                        LoadExtensionPlaneLookAndFeel(ObjectPlacement.Get().BlockObjectPlacement.BlockExtensionPlaneRenderSettings, blockLookAndFeelNode);
                    }
                }
            }
        }

        private static void LoadExtensionPlaneLookAndFeel(ObjectPlacementExtensionPlaneRenderSettings renderSettings, XmlNode parentNode)
        {
            XmlNode extensionPlaneLookAndFeel = parentNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ExtensionPlaneLookAndFeelNode);
            if(extensionPlaneLookAndFeel != null)
            {
                XmlNode node = extensionPlaneLookAndFeel.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ExtensionPlaneScaleNode);
                if(node != null)
                {
                    float res;
                    if (float.TryParse(node.InnerText, out res)) renderSettings.PlaneScale = res;
                }

                node = extensionPlaneLookAndFeel.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ExtensionPlaneColorNode);
                if (node != null)
                {
                    renderSettings.PlaneColor = ColorExtensions.FromString(node.InnerText);
                }

                node = extensionPlaneLookAndFeel.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ExtensionPlaneBorderColorNode);
                if (node != null)
                {
                    renderSettings.PlaneBorderLineColor = ColorExtensions.FromString(node.InnerText);
                }

                node = extensionPlaneLookAndFeel.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ExtensionPlaneNormalLineLengthNode);
                if (node != null)
                {
                    float res;
                    if (float.TryParse(node.InnerText, out res)) renderSettings.PlaneNormalLineLength = res;
                }

                node = extensionPlaneLookAndFeel.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ExtensionPlaneNormalLineColorNode);
                if (node != null)
                {
                    renderSettings.PlaneNormalLineColor = ColorExtensions.FromString(node.InnerText);
                }
            }
        }

        private static void LoadObjectSelectionLookAndFeel(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if(loadSettings.ObjectSelectionLookAndFeel)
            {
                XmlNode selectionLookAndFeelNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.ObjectSelectionLookAndFeelNode);
                if(selectionLookAndFeelNode != null)
                {
                    ObjectSelectionRenderSettings selectionRenderSettings = ObjectSelection.Get().RenderSettings;
                    RectangleShapeRenderSettings rectRenderSettings = ObjectSelection.Get().RectangleSelectionShapeRenderSettings;
                    EllipseShapeRenderSettings ellipseRenderSettings = ObjectSelection.Get().EllipseSelectionShapeRenderSettings;

                    XmlNode node = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionBoxEdgeDrawModeNode);
                    if(node != null)
                    {
                        try
                        {
                            selectionRenderSettings.BoxRenderModeSettings.EdgeRenderMode = (ObjectSelectionBoxEdgeRenderMode)Enum.Parse(typeof(ObjectSelectionBoxEdgeRenderMode), node.InnerText);
                        }
                        catch (Exception) { }
                    }

                    node = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionBoxCornerEdgeLengthPercentageNode);
                    if (node != null)
                    {
                        float res;
                        if (float.TryParse(node.InnerText, out res)) selectionRenderSettings.BoxRenderModeSettings.CornerEdgesRenderModeSettings.CornerEdgeLengthPercentage = res;
                    }

                    node = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionBoxEdgeColorNode);
                    if (node != null)
                    {
                        selectionRenderSettings.BoxRenderModeSettings.EdgeColor = ColorExtensions.FromString(node.InnerText);
                    }

                    node = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionBoxColorNode);
                    if (node != null)
                    {
                        selectionRenderSettings.BoxRenderModeSettings.BoxColor = ColorExtensions.FromString(node.InnerText);
                    }

                    node = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionBoxScaleNode);
                    if (node != null)
                    {
                        float res;
                        if (float.TryParse(node.InnerText, out res)) selectionRenderSettings.BoxRenderModeSettings.BoxScale = res;
                    }

                    XmlNode selRectNode = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionRectLookAndFeelNode);
                    if(selRectNode != null)
                    {
                        node = selRectNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionShapeFillColorNode);
                        if (node != null) rectRenderSettings.FillColor = ColorExtensions.FromString(node.InnerText);

                        node = selRectNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionShapeBorderColorNode);
                        if (node != null) rectRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                    }

                    XmlNode selEllipseNode = selectionLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionEllipseLookAndFeelNode);
                    if (selRectNode != null)
                    {
                        node = selEllipseNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionShapeFillColorNode);
                        if (node != null) ellipseRenderSettings.FillColor = ColorExtensions.FromString(node.InnerText);

                        node = selEllipseNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectSelectionShapeBorderColorNode);
                        if (node != null) ellipseRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                    }
                }
            }
        }

        private static void LoadObjectErasingLookAndFeel(XmlDocument xmlDoc, FreeSimConfigSaveLoadSettings loadSettings)
        {
            if (loadSettings.ObjectErasingLookAndFeel)
            {
                XmlNode erasingLookAndFeelNode = xmlDoc.SelectSingleNode("//" + FreeSimConfigXMLInfo.ObjectErasingLookAndFeelNode);
                if (erasingLookAndFeelNode != null)
                {
                    EllipseShapeRenderSettings circle2DRenderSettings = ObjectEraser.Get().Circle2DMassEraseShapeRenderSettings;
                    XZOrientedEllipseShapeRenderSettings circle3DRenderSettings = ObjectEraser.Get().Circle3DMassEraseShapeRenderSettings;

                    XmlNode mass2DCircleNode = erasingLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectErasing2DCircleLookAndFeelNode);
                    if(mass2DCircleNode != null)
                    {
                        XmlNode node = mass2DCircleNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectErasingShapeFillColorNode);
                        if (node != null) circle2DRenderSettings.FillColor = ColorExtensions.FromString(node.InnerText);

                        node = mass2DCircleNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectErasingShapeBorderColorNode);
                        if (node != null) circle2DRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                    }

                    XmlNode mas3DCircleNode = erasingLookAndFeelNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectErasing3DCircleLookAndFeelNode);
                    if (mas3DCircleNode != null)
                    {
                        XmlNode node = mas3DCircleNode.SelectSingleNode(".//" + FreeSimConfigXMLInfo.ObjectErasingShapeBorderColorNode);
                        if (node != null) circle3DRenderSettings.BorderLineColor = ColorExtensions.FromString(node.InnerText);
                    }
                }
            }
        }
        #endregion
    }
}
#endif