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

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.BeginVertical();
        templateInspector = (AdTemplateJsonInspector)target;
        GUIStyle customButtonStyle = new GUIStyle(GUI.skin.button);
        customButtonStyle.fontSize = 20;
        customButtonStyle.fontStyle = FontStyle.Bold;
        GUILayout.Space(20);
        if (GUILayout.Button("Load Json Data", customButtonStyle, GUILayout.ExpandWidth(true)))
        {
            //Debug.Log("Load Json Data");
            templateInspector.LoadDataFromAsset();
            messageForUser = templateInspector.messageForUser;
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Save Edited Data", customButtonStyle, GUILayout.ExpandWidth(true)))
        {
            //Debug.Log("Save Edited Data");
            templateInspector.SaveJsonFile();
            messageForUser = templateInspector.messageForUser;
            AssetDatabase.Refresh();
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Clear Loaded Data", customButtonStyle, GUILayout.ExpandWidth(true)))
        {
            //Debug.Log("Clear Loaded Data");
            templateInspector.ClearData();
            messageForUser = string.Empty;
            templateInspector.messageForUser = string.Empty;
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Create UI Template In Scene", customButtonStyle, GUILayout.ExpandWidth(true)))
        {
            //Debug.Log("Create UI Template In Scene");
            templateInspector.CreateUiTemplateInScene();
            messageForUser = templateInspector.messageForUser;
            AssetDatabase.Refresh();
        }
        GUILayout.Space(20);

        GUIStyle customLabelStyle = new GUIStyle();
        customLabelStyle.fontSize = 25;
        customLabelStyle.fontStyle = FontStyle.Bold;
        customLabelStyle.wordWrap = true;
        customLabelStyle.normal.textColor = Color.red;

        GUILayout.Label(messageForUser, customLabelStyle);
        GUILayout.Space(10);
        ShowJsonData();

        GUILayout.EndVertical();
    }

    public void ShowJsonData()
    {

        GUILayout.Space(20);

        if (templateInspector.adTemplateJsonAsset != null && templateInspector.isDataLoaded)
        {
            GUIStyle customLabelStyle = new GUIStyle();
            customLabelStyle.fontSize = 15;
            customLabelStyle.fontStyle = FontStyle.Bold;
            customLabelStyle.wordWrap = true;
            customLabelStyle.normal.textColor = Color.yellow;

            EditorGUILayout.LabelField("ad_Headline", templateInspector.adJsonData.ad_Headline, customLabelStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("ad_Description", templateInspector.adJsonData.ad_Description, customLabelStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("ad_IconUrl", templateInspector.adJsonData.ad_IconUrl, customLabelStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("ad_maxStarRaing", templateInspector.adJsonData.ad_maxStarRating.ToString(), customLabelStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("ad_givenStarRaing", templateInspector.adJsonData.ad_givenStarRating.ToString(), customLabelStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("ad_priceValue", templateInspector.adJsonData.ad_priceValue.ToString(), customLabelStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.LabelField("ad_AppUrl", templateInspector.adJsonData.ad_AppUrl, customLabelStyle, GUILayout.ExpandWidth(true));
        }

        serializedObject.ApplyModifiedProperties();

    }

}
