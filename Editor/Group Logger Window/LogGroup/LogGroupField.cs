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
        visualTreeAsset = Resources.Load("LogGroup") as VisualTreeAsset;
        Add(visualTreeAsset.Instantiate());
        Bind();
    }

    void Bind()
    {
        deleteButton = this.Q<Button>("deleteButton");
        toggle = this.Q<Toggle>("toggle");
    }
}