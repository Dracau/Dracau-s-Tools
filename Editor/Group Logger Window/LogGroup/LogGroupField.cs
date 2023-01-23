using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using Dracau;

public class LogGroupField : VisualElement
{
    private VisualTreeAsset visualTreeAsset;
    public LogGroup logGroup;

    public Button deleteButton;
    public Toggle toggle;
    public LogGroupField(LogGroup newLogGroup)
    {
        logGroup = newLogGroup;
        Init();
    }

    private void Init()
    {
        visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/package/Dracau-s-Tools/Editor/Group Logger Window/LogGroup/LogGroup.uxml");
        Add(visualTreeAsset.Instantiate());
        Bind();
    }

    void Bind()
    {
        deleteButton = this.Q<Button>("deleteButton");
        toggle = this.Q<Toggle>("toggle");
    }
}