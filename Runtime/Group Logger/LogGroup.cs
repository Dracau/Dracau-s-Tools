using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracau
{
    [Serializable]
    public class LogGroup
    {
        public string name;
        public bool active;
        public LogGroup(string newName)
        {
            name = newName;
        }
        public static void Log(string message)
        {
            Debug.Log(message);
        }
    }
}