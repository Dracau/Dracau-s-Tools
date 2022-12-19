//
//  Utils Class by Gautier Debreu aka Dracau
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dracau
{
    public static class Utils
    {
        //
        //  Vector Operations
        //
        
        //Get center of two 3D vectors
        public static Vector3 GetMiddlePoint(Vector3 firstVector, Vector3 secondVector)
        {
            return (firstVector + secondVector) * 0.5f;
        }
        
        //Get center of two 2D vectors
        public static Vector2 GetMiddlePoint(Vector2 firstVector, Vector2 secondVector)
        {
            return (firstVector + secondVector) * 0.5f;
        }
        
        
        //
        // Handles Things
        //

        //Draw Bezier curve between two objects
        #if UNITY_EDITOR
        public static void DrawSimpleBezier(Vector3 srcPos, Vector3 targetPos)
        {
            float halfHeight = (srcPos.y - targetPos.y) * 0.5f;
            Vector3 offset = Vector3.up * halfHeight;
            Handles.DrawBezier(srcPos, targetPos,srcPos-offset,targetPos+offset,Color.black,EditorGUIUtility.whiteTexture,1f);
        }
        #endif
        
        //Draw Bezier curve between two objects, with custom color
        #if UNITY_EDITOR
        public static void DrawSimpleBezier(Vector3 srcPos, Vector3 targetPos, Color color)
        {
            float halfHeight = (srcPos.y - targetPos.y) * 0.5f;
            Vector3 offset = Vector3.up * halfHeight;
            Handles.DrawBezier(srcPos, targetPos,srcPos-offset,targetPos+offset,color,EditorGUIUtility.whiteTexture,1f);
        }
        #endif
        
        
        //
        //  Miscellaneous
        //
        
        //Reduce garbage collection due to "new WaitForSeconds" situations
        private static readonly Dictionary<float, WaitForSeconds> waitDictionary = new Dictionary<float, WaitForSeconds>();
        public static WaitForSeconds GetWaitForSeconds(float time)
        {
            if (waitDictionary.TryGetValue(time, out WaitForSeconds wait)) return wait;
            
            waitDictionary[time] = new WaitForSeconds(time);
            return waitDictionary[time];
        }
        
        //Clears WaitForSeconds Dictionary
        public static void EmptyWaitForSeconds()
        {
            waitDictionary.Clear();
        }
        
        //Delete all children of a Transform
        public static void DeleteChildrens(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Object.Destroy(transform.GetChild(i));
            }
        }
    }
}