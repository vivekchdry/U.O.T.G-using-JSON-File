using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
//using System.Diagnostics;


[CustomEditor(typeof(AdTemplateJsonInspector))]
public class AdTemplateJsonInspectorEditor : Editor
{
    public AdTemplateJsonInspector templateInspector;
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
        templateInspector = (AdTemplateJsonInspector)target;

        GUILayout.Space(20);
        if (GUILayout.Button("Load Json Data"))
        {
            Debug.Log("Load Json Data");
            templateInspector.LoadDataFromAsset();
            messageForUser = templateInspector.messageForUser;
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Save Edited Data"))
        {
            Debug.Log("Save Edited Data");
            templateInspector.SaveJsonFile();
            messageForUser = templateInspector.messageForUser;

        }
        GUILayout.Space(10);
        if (GUILayout.Button("Clear Loaded Data"))
        {
            Debug.Log("Clear Loaded Data");
            templateInspector.ClearData();
            messageForUser = string.Empty;
            templateInspector.messageForUser = string.Empty;
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Create UI Template In Scene"))
        {
            Debug.Log("Create UI Template In Scene");
            templateInspector.CreateUiTemplateInScene();
            messageForUser = string.Empty;
            templateInspector.messageForUser = string.Empty;
        }
        GUILayout.Space(20);

        GUILayout.Label(messageForUser, UserWarning);
        GUILayout.Space(20);
        ShowJsonData();

        GUILayout.EndVertical();
    }

    public void ShowJsonData()
    {
        //serializedObject.Update();

        GUILayout.Space(20);

        if (templateInspector.adTemplateJsonAsset != null && templateInspector.isDataLoaded)
        {
            EditorGUILayout.LabelField("ad_Headline", templateInspector.adJsonData.ad_Headline);
            EditorGUILayout.LabelField("ad_Description", templateInspector.adJsonData.ad_Description);
            EditorGUILayout.LabelField("ad_IconUrl", templateInspector.adJsonData.ad_IconUrl);
            EditorGUILayout.LabelField("ad_maxStarRaing", templateInspector.adJsonData.ad_maxStarRaing.ToString());
            EditorGUILayout.LabelField("ad_givenStarRaing", templateInspector.adJsonData.ad_givenStarRaing.ToString());
            EditorGUILayout.LabelField("ad_priceValue", templateInspector.adJsonData.ad_priceValue.ToString());
            EditorGUILayout.LabelField("ad_AppUrl", templateInspector.adJsonData.ad_AppUrl);
        }

        serializedObject.ApplyModifiedProperties();

    }

}
