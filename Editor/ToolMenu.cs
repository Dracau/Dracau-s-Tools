using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dracau
{
    public class ToolMenu : MonoBehaviour
    {
        [MenuItem("Tools/Test")]
        public static void Test()
        {
            Debug.Log("<color=green>Test</color>");
        }
        [MenuItem("Tools/Setup/Create Default Directories/2D")]
        public static void CreateDefaulFolder3D()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scriptable Objects", "Scripts", "Art");
            CreateDirs("Art", "Sprites");
            CreateDirs("Scriptable Objects","Scripts");
            AssetDatabase.Refresh();
            Debug.Log("Created default directories for 2D project.");
        }
        
        [MenuItem("Tools/Setup/Create Default Directories/3D")]
        public static void CreateDefaulFolders2D()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scriptable Objects", "Scripts", "Art");
            CreateDirs("Art", "Meshes", "Animations", "Materials","Shaders");
            CreateDirs("Scriptable Objects","Scripts");
            AssetDatabase.Refresh();
            Debug.Log("Created default directories for 3D project.");
        }

        public static void CreateDirs(string root, params string[] dirs)
        {
            var fullpath = Path.Combine(Application.dataPath, root);
            foreach (var dir in dirs)
            {
                Directory.CreateDirectory(Path.Combine(fullpath, dir));
            }
        }
    }
}