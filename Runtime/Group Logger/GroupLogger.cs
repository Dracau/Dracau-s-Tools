using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dracau
{
    public static class GroupLogger
    {
        private static GroupLoggerData groupLoggerData;
        public static void Log(string groupName,string message)
        {
            if(CheckGroupActive(groupName)) Debug.Log(message);
        }
        public static void Log(string groupName,string message, Object context)
        {
            if(CheckGroupActive(groupName)) Debug.Log(message, context);
        }
        public static void LogWarning(string groupName,string message)
        {
            if(CheckGroupActive(groupName)) Debug.LogWarning(message);
        }
        public static void LogWarning(string groupName,string message, Object context)
        {
            if(CheckGroupActive(groupName)) Debug.LogWarning(message, context);
        }
        public static void LogError(string groupName,string message)
        {
            if(CheckGroupActive(groupName)) Debug.LogError(message);
        }
        public static void LogError(string groupName,string message, Object context)
        {
            if(CheckGroupActive(groupName)) Debug.LogError(message,context);
        }
        public static bool CheckGroupActive(string groupName)
        {
            #if UNITY_EDITOR
            if(groupLoggerData == null)
            {
                Debug.Log("GroupLoggerData not found, creating new one");
                groupLoggerData = Resources.Load("GroupLoggerData") as GroupLoggerData;
            }
            foreach (LogGroup logGroup in groupLoggerData.logGroups)
            {
                if(logGroup.name == groupName)
                {
                    return logGroup.active;
                }
            }
            Debug.LogError(groupName + " is not a valid log group name");
            #endif
            return false;
        }
    }
}