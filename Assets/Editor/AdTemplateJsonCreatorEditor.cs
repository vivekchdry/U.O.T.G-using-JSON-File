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



    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        GUILayout.BeginVertical();
        templateCreator = (TemplateCreator)target;
        GUIStyle customButtonStyle = new GUIStyle(GUI.skin.button);
        customButtonStyle.fontSize = 20;
        customButtonStyle.fontStyle = FontStyle.Bold;
        GUIStyle customLabelStyle = new GUIStyle();
        customLabelStyle.fontSize = 25;
        customLabelStyle.fontStyle = FontStyle.Bold;
        customLabelStyle.wordWrap = true;
        customLabelStyle.normal.textColor = Color.red;

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
        GUILayout.Space(15);
        GUILayout.Label(messageForUser, customLabelStyle);
        GUILayout.Space(20);
        GUILayout.EndVertical();
    }
}