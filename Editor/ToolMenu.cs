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
        [MenuItem("Tools/Setup/Create Default Directories/2D")]
        public static void CreateDefaulFolder3D()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scriptable Objects", "Scripts", "Art");
            CreateDirs("Art", "Sprites");
            CreateDirs("Scriptable Objects","Scripts");
            AssetDatabase.Refresh();
        }
        
        [MenuItem("Tools/Setup/Create Default Directories/3D")]
        public static void CreateDefaulFolders2D()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scriptable Objects", "Scripts", "Art");
            CreateDirs("Art", "Meshes", "Materials","Shaders");
            CreateDirs("Scriptable Objects","Scripts");
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