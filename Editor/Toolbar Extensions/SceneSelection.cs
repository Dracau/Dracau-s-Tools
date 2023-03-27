using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Helper.Editor;
using UnityEditor.SceneManagement;

namespace Dracau {
    [InitializeOnLoad]
    public class SceneSelectionToolbar {
        private static int levelIndex => PlayerPrefs.GetInt("SceneDirectoryIndex", 0);
        private const int levelSelectionSize = 150;
        
        /// <summary>
        /// Method called during an initialization (reload, save, ...)
        /// </summary>
        static SceneSelectionToolbar() => ToolbarExt.leftToolbarGUI.Add(new DrawerAction(50, LevelSelection));

        /// <summary>
        /// Draw the Dropdown for the level selection
        /// </summary>
        private static void LevelSelection() {
            GUILayout.FlexibleSpace();
            GUILayout.Label("Scene :");
            int value = EditorGUILayout.Popup(levelIndex, GetLevelPossibilities().ToArray(), GUILayout.Width(levelSelectionSize));
            if (value != levelIndex)
            {
                OpenNewScene(value);
            }
        }

        #region Helper
        /// <summary>
        /// Retrieve all the scene that are selectable
        /// </summary>
        /// <returns></returns>
        private static List<string> GetLevelPossibilities() {
            List<string> possibilities = EditorBuildSettings.scenes.Select(file => Path.GetFileName(file.path).Split(".")[0]).ToList();
            return possibilities;
        }

        /// <summary>
        /// Open the new scene and save the index value
        /// </summary>
        /// <param name="value"></param>
        private static void OpenNewScene(int value) {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene(EditorBuildSettings.scenes[value].path);
            PlayerPrefs.SetInt("SceneDirectoryIndex", value);
        }
        #endregion Helper
    }
}