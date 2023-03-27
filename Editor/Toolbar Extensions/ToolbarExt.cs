using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dracau;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Helper.Editor {
    [InitializeOnLoad]
    public static class ToolbarExt {
        private static Type toolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");
        private static ScriptableObject currentToolbar;

        private static Action OnToolbarGUILeft;
        private static Action OnToolbarGUIRight;

        public static readonly List<DrawerAction> leftToolbarGUI = new();
        public static readonly List<DrawerAction> rightToolbarGUI = new();

        /// <summary>
        /// Method called during an initialization (reload, save, ...)
        /// </summary>
        static ToolbarExt() {
            EditorApplication.update -= OnUpdate;
            EditorApplication.update += OnUpdate;
            OnToolbarGUILeft = GUILeft;
            OnToolbarGUIRight = GUIRight;
        }

        /// <summary>
        /// Method called in the EditorApplication.Update
        /// </summary>
        private static void OnUpdate() {
            if (currentToolbar != null) return;

            RetrieveRootVisualElement()?.Q("ToolbarZoneLeftAlign").CallbackDrawer(OnToolbarGUILeft, "LeftToolbarContainer");
            RetrieveRootVisualElement()?.Q("ToolbarZoneRightAlign").CallbackDrawer(OnToolbarGUIRight, "RightToolbarContainer");
        }

        #region Drawer Callback

        /// <summary>
        /// Draw the toolbar elements on the left side of the current toolbar
        /// </summary>
        private static void GUILeft() => leftToolbarGUI.HorizontalToolbarDrawer();

        /// <summary>
        /// Draw the toolbar elements on the right side of the current toolbar
        /// </summary>
        private static void GUIRight() => rightToolbarGUI.HorizontalToolbarDrawer();

        #endregion

        #region Helper

        /// <summary>
        /// Retrieve the root element of the currentToolbar
        /// </summary>
        /// <returns></returns>
        private static VisualElement RetrieveRootVisualElement() {
            Object[] toolbars = Resources.FindObjectsOfTypeAll(toolbarType);
            currentToolbar = (ScriptableObject) toolbars[0];
            if (currentToolbar == null) return null;

            FieldInfo root = currentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
            return root?.GetValue(currentToolbar) as VisualElement;
        }

        /// <summary>
        /// Draw the toolbar elements based on a list of Toolbar Action
        /// </summary>
        /// <param name="toolbarAction"></param>
        private static void HorizontalToolbarDrawer(this List<DrawerAction> toolbarAction) {
            using (new GUILayout.HorizontalScope()) {
                List<DrawerAction> toolbars = toolbarAction.OrderBy(gam => gam.orderPriority).ToList();
                foreach (DrawerAction handler in toolbars) handler.action();
            }
        }

        /// <summary>
        /// Draw the elements inside the Visual Element
        /// </summary>
        /// <param name="action"></param>
        /// <param name="rootQ"></param>
        private static void CallbackDrawer(this VisualElement rootQ, Action action, string containerName) {
            VisualElement parent = new VisualElement() {style = {flexGrow = 1, flexDirection = FlexDirection.Row, alignItems = Align.Center}};

            parent.Add(action.CreateIMGUIContainer(containerName, VisualElementExt.FlexGrow(1)));
            rootQ.Add(parent);
        }

        #endregion
    }
    
    /// <summary>
    /// Class which allow to set a priority order inside the scripts
    /// </summary>
    public sealed class DrawerAction {
        public DrawerAction(int orderPriority, Action action) {
            this.orderPriority = orderPriority;
            this.action = action;
        }

        public int orderPriority;
        public Action action;
    }
}