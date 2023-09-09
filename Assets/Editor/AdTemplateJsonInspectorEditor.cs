using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;


[CustomEditor(typeof(AdTemplateJsonInspector))]
public class AdTemplateJsonInspectorEditor : Editor
{
    public AdTemplateJsonInspector templateInspector;
    public List<TemplateList> templateLists = new List<TemplateList>();

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.BeginVertical();
        templateInspector = (AdTemplateJsonInspector)target;

        GUILayout.Space(20);
        if (GUILayout.Button("Load Json Data"))
        {
            Debug.Log("Load Json Data");
            templateInspector.LoadDataFromAsset();
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Clear Loaded Data"))
        {
            Debug.Log("Clear Loaded Data");
            templateInspector.ClearData();
        }
        GUILayout.Space(20);
        ShowJsonData();

        GUILayout.EndVertical();
    }

    public void ShowJsonData()
    {
        serializedObject.Update();

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

    [Serializable]
    public class TemplateList
    {
        public TextAsset textAsset;

    }

}
