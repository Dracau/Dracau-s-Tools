using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dracau
{
    /// <summary>
    /// Utils Class by Gautier Debreu aka Dracau
    /// </summary>
    public static class Utils
    {
        #region UI

        #region Handles

        //Draw Bezier curve between two objects
        #if UNITY_EDITOR
        /// <summary>
        /// Draw Bezier given an origin and target position
        /// </summary>
        /// <param name="srcPos">Origin position</param>
        /// <param name="targetPos">Target Position</param>
        public static void DrawSimpleBezier(Vector3 srcPos, Vector3 targetPos)
        {
            float halfHeight = (srcPos.y - targetPos.y) * 0.5f;
            Vector3 offset = Vector3.up * halfHeight;
            Handles.DrawBezier(srcPos, targetPos,srcPos-offset,targetPos+offset,Color.black,EditorGUIUtility.whiteTexture,1f);
        }
        #endif
        
        #if UNITY_EDITOR
        /// <summary>
        /// Draw Bezier given an origin and target position and a color
        /// </summary>
        /// <param name="srcPos">Origin position</param>
        /// <param name="targetPos">Target Position</param>
        /// <param name="color">Color of the Bezier</param>
        public static void DrawSimpleBezier(Vector3 srcPos, Vector3 targetPos, Color color)
        {
            float halfHeight = (srcPos.y - targetPos.y) * 0.5f;
            Vector3 offset = Vector3.up * halfHeight;
            Handles.DrawBezier(srcPos, targetPos,srcPos-offset,targetPos+offset,color,EditorGUIUtility.whiteTexture,1f);
        }
        #endif

        #endregion
        #endregion
        
        #region Maths

        #region Vector Operations
        
        /// <summary>
        /// Get center of two 3D vectors
        /// </summary>
        /// <param name="firstVector"></param>
        /// <param name="secondVector"></param>
        /// <returns></returns>
        public static Vector3 GetMiddlePoint(Vector3 firstVector, Vector3 secondVector)
        {
            return (firstVector + secondVector) * 0.5f;
        }
        
        /// <summary>
        /// Get center of two 2D vectors
        /// </summary>
        /// <param name="firstVector"></param>
        /// <param name="secondVector"></param>
        /// <returns></returns>
        public static Vector2 GetMiddlePoint(Vector2 firstVector, Vector2 secondVector)
        {
            return (firstVector + secondVector) * 0.5f;
        }
        #endregion
        #endregion

        #region Miscellaneous
        
        private static readonly Dictionary<float, WaitForSeconds> waitDictionary = new Dictionary<float, WaitForSeconds>();
        /// <summary>
        /// Reduces garbage collection due to repeated "new WaitForSeconds"
        /// </summary>
        /// <param name="time">Time in seconds to wait</param>
        /// <returns></returns>
        public static WaitForSeconds GetWaitForSeconds(float time)
        {
            if (waitDictionary.TryGetValue(time, out WaitForSeconds wait)) return wait;
            
            waitDictionary[time] = new WaitForSeconds(time);
            return waitDictionary[time];
        }
        
        /// <summary>
        /// Clears WaitForSecond dictionary
        /// </summary>
        public static void EmptyWaitForSeconds()
        {
            waitDictionary.Clear();
        }
        
        /// <summary>
        /// Delete all child of a Transform
        /// </summary>
        /// <param name="transform">Transform to delete all child of</param>
        public static void DeleteChildrens(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Object.Destroy(transform.GetChild(i));
            }
        }
        #endregion
    }
}