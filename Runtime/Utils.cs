//
//  Utils Class by Gautier Debreu aka Dracau
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracau
{
    public static class Utils
    {
        //
        //  Vector operations
        //
        
        //Get center of two 3D vectors
        public static Vector3 GetMiddlePoint(Vector3 firstVector, Vector3 secondVector)
        {
            return new Vector3((firstVector.x+secondVector.x)*0.5f,(firstVector.y+secondVector.y)*0.5f,(firstVector.z+secondVector.z)*0.5f);
        }
        
        //Get center of two 2D vectors
        public static Vector2 GetMiddlePoint(Vector2 firstVector, Vector2 secondVector)
        {
            return new Vector3((firstVector.x+secondVector.x)*0.5f,(firstVector.y+secondVector.y)*0.5f);
        }
        
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