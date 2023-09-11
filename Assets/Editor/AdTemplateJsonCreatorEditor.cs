using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;


[CustomEditor(typeof(TemplateCreator))]
public class AdTemplateJsonCreatorEditor : Editor
{
    public TemplateCreator templateCreator;
    private string messageForUser;

    private bool initDone = false;
    public GUIStyle UserWarning;

    void InitStyles()
    {
        initDone = true;
        UserWarning = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleLeft,
            margin = new RectOffset(),
            padding = new RectOffset(),
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            richText = true
        };

    }

    public override void OnInspectorGUI()
    {
        if (!initDone)
        {
            InitStyles();
        }
        base.OnInspectorGUI();
        GUILayout.BeginVertical();
        templateCreator = (TemplateCreator)target;
        GUIStyle customButtonStyle = new GUIStyle(GUI.skin.button);
        customButtonStyle.fontSize = 20;
        customButtonStyle.fontStyle = FontStyle.Bold;
        GUILayout.Space(20);
        if (GUILayout.Button("Create New Template", customButtonStyle, GUILayout.ExpandWidth(true)))
        {
            //Debug.Log("Create New Template");
            templateCreator.CreateNewJsonFileTemplate();
            messageForUser = templateCreator.messageForUser;
            Repaint();
            AssetDatabase.Refresh();
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Clear The Template", customButtonStyle, GUILayout.ExpandWidth(true)))
        {
            //Debug.Log("Clear The Template");
            templateCreator.ClearData();
            messageForUser = string.Empty;
            templateCreator.messageForUser = string.Empty;
            Repaint();
            AssetDatabase.Refresh();
        }
        GUILayout.Space(10);
        GUILayout.EndVertical();
    }
}