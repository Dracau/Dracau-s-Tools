using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dracau
{
    public class ToolMenu : MonoBehaviour
    {
        [MenuItem("Tools/Setup/Create Default Directories/2D")]
        public static void CreateDefaultFolders3D()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scriptable Objects", "Scripts", "Art");
            CreateDirs("Art", "Sprites");
            CreateDirs("Scriptable Objects","Scripts");
            AssetDatabase.Refresh();
            
            Utils.ShowNotificationOnScenes("Created default directories for 2D project.",1.5f);
            Debug.Log("Created default directories for 2D project.".Color(Color.red).Bold());
        }
        
        [MenuItem("Tools/Setup/Create Default Directories/3D")]
        public static void CreateDefaultFolders2D()
        {
            CreateDirs("","Scenes", "Editor", "Prefabs", "Scriptable Objects", "Scripts", "Art");
            CreateDirs("Art", "Meshes", "Animations", "Materials","Shaders");
            CreateDirs("Scriptable Objects","Scripts");
            AssetDatabase.Refresh();
            
            Utils.ShowNotificationOnScenes("Created default directories for 3D project.",1.5f);
            Debug.Log("Created default directories for 3D project.".Color(Color.red).Bold());
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