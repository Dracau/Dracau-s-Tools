using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Directory = UnityEngine.Windows.Directory;

namespace Dracau
{
    public class ToolMenu : MonoBehaviour
    {
        [MenuItem("Tools/Setup/Create Default Directories")]
        public static void CreateDefaulFolders()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scripts", "Art");
            AssetDatabase.Refresh();
        }

        public static void CreateDirs(string root, params string[] dirs)
        {
            var fullpath = Path.Combine(Application.dataPath, root);
            foreach (var dir in dirs)
            {
                Directory.CreateDirectory(Path.Combine(fullpath, dir));
            }
            Debug.Log("Created default directories.");
        }
    }
}