using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEditor.iOS;
using UnityEngine;
using System.IO;


public class AdTemplateJsonInspector : MonoBehaviour
{
    [SerializeField]
    public TextAsset adTemplateJsonAsset;
    [Space(5)]
    public AdJsonData adJsonData;
    public bool isDataLoaded = false;

    [ContextMenu("LoadDataFromAsset")]
    public void LoadDataFromAsset()
    {
        if (adTemplateJsonAsset == null)
        {
            adTemplateJsonAsset = Resources.Load<TextAsset>($"{Path.Combine("JSONTemplates", "JsonAssets_AdTemplate 1")}");
        }
        adJsonData = JsonConvert.DeserializeObject<AdJsonData>(adTemplateJsonAsset.text);
        isDataLoaded = true;
    }

    [ContextMenu("ClearData")]
    public void ClearData()
    {
        isDataLoaded = false;
        adJsonData.ClearFields();
        adJsonData = null;
    }
}
