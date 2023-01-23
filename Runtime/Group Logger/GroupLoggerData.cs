using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracau
{
    [CreateAssetMenu(fileName = "GroupLoggerData", menuName = "Tools/GroupLoggerData")]
    public class GroupLoggerData : ScriptableObject
    {
        public List<LogGroup> logGroups = new List<LogGroup>();
    }
}