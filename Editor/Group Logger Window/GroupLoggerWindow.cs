using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dracau
{
    public class GroupLoggerWindow : EditorWindow
    {
        private VisualElement root;
        [SerializeField] private VisualTreeAsset visualTree;
        [SerializeField] private GroupLoggerData groupLoggerData;
        public List<LogGroup> logGroups;
        
        private TextField newGroupTextField;
        private Button addGroupButton;
        private VisualElement logGroupsView;

        [MenuItem("Tools/Group Logger")]
        public static void ShowWindow()
        {
            GroupLoggerWindow window = GetWindow<GroupLoggerWindow>();
            window.titleContent = new GUIContent("Group Logger");
            window.minSize = new Vector2(200, 200);
        }

        public void CreateGUI()
        {
            root = rootVisualElement;

            root.Add(visualTree.Instantiate());

            Bind();
        }

        private void Bind()
        {
            newGroupTextField = root.Q<TextField>("newLogGroupName");
            addGroupButton = root.Q<Button>("addGroupButton");
            logGroupsView = root.Q<VisualElement>("logGroupsView");
            
            addGroupButton.clicked += () => AddGroup(new LogGroup(newGroupTextField.value), false);
            
            Load();
        }

        private void AddGroup(LogGroup logGroup, bool setup)
        {
            if (!setup)
            {
                if(newGroupTextField.value == "" || newGroupTextField.value == "filler text") return;
                if(logGroups.Contains(logGroup)) return;
                logGroups.Add(logGroup);
            }

            LogGroupField logGroupField = new LogGroupField(logGroup);
            logGroupsView.Add(logGroupField);
            logGroupField.toggle.text = logGroup.name;
            logGroupField.toggle.value = logGroup.active;
            logGroupField.toggle.RegisterValueChangedCallback(evt => { logGroup.active = evt.newValue; });
            logGroupField.deleteButton.clicked += () => DeleteLogGroup(logGroupField);
            if(!setup) Save();
        }

        private void DeleteLogGroup(LogGroupField logGroupField)
        {
            logGroups.Remove(logGroupField.logGroup);
            logGroupField.RemoveFromHierarchy();
            Save();
        }
        private void Load()
        {
            logGroups = groupLoggerData.logGroups;
            foreach (LogGroup logGroup in logGroups)
            {
                AddGroup(logGroup, true);
            }
        }
        private void Save()
        {
            groupLoggerData.logGroups = logGroups;
        }
    }
}