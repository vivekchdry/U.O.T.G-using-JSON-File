using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEditor.iOS;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;


public class AdTemplateJsonInspector : MonoBehaviour
{

    public TextAsset adTemplateJsonAsset;
    [Space(5)]
    public AdJsonData adJsonData;

    public AdPriceType adPriceType;// { get; set; }

    public bool isDataLoaded { get; set; }
    public string messageForUser { get; set; }

    [ContextMenu("LoadDataFromAsset")]
    public void LoadDataFromAsset()
    {
        if (adTemplateJsonAsset == null)
        {
            adTemplateJsonAsset = Resources.Load<TextAsset>($"{Path.Combine("JSONTemplates", "JsonAssets_AdTemplate 1")}");
        }

        adJsonData = JsonConvert.DeserializeObject<AdJsonData>(adTemplateJsonAsset.text);

        isDataLoaded = IsJsonDataValid(adJsonData) ? true : ClearData();
    }

    [ContextMenu("ClearData")]
    public bool ClearData()
    {
        isDataLoaded = false;
        adJsonData.ClearFields();
        adTemplateJsonAsset = null;
        adPriceType = AdPriceType.None;
        return isDataLoaded;
    }

    public bool IsJsonDataValid(AdJsonData ref_adJsonData)
    {
        if (ref_adJsonData.ad_Headline == string.Empty || ref_adJsonData.ad_Headline == "" || ref_adJsonData.ad_Headline == null)
        {
            messageForUser = $"ad_Headline field cannot be Empty.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_Description == string.Empty || ref_adJsonData.ad_Description == "" || ref_adJsonData.ad_Description == null)
        {
            messageForUser = $"ad_Description field cannot be Empty.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_IconUrl == string.Empty || ref_adJsonData.ad_IconUrl == "" || ref_adJsonData.ad_IconUrl == null)
        {
            messageForUser = $"ad_IconUrl field cannot be Empty.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_AppUrl == string.Empty || ref_adJsonData.ad_AppUrl == "" || ref_adJsonData.ad_AppUrl == null)
        {
            messageForUser = $"ad_AppUrl field cannot be Empty.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_maxStarRaing >= 11 || ref_adJsonData.ad_maxStarRaing <= 4)
        {
            messageForUser = $"ad_maxStarRaing is invalid.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_givenStarRaing >= (ref_adJsonData.ad_maxStarRaing + 1) || ref_adJsonData.ad_givenStarRaing <= -1)
        {
            messageForUser = $"ad_givenStarRaing is invalid.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_priceValue < 0f)
        {
            messageForUser = $"ad_priceValue is invalid.\nCheck JSON File.";
            return false;
        }
        if (ref_adJsonData.ad_priceValue > 0f)
        {
            adPriceType = AdPriceType.PAID;
            messageForUser = string.Empty;
            return true;
        }
        if (ref_adJsonData.ad_priceValue == 0)
        {
            adPriceType = AdPriceType.FREE;
            messageForUser = string.Empty;
            return true;
        }
        messageForUser = string.Empty;
        return true;
    }
    public bool IsEditedDataValid(AdJsonData ref_adJsonData)
    {
        if (ref_adJsonData.ad_Headline == string.Empty || ref_adJsonData.ad_Headline == "" || ref_adJsonData.ad_Headline == null)
        {
            messageForUser = $"ad_Headline field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_Description == string.Empty || ref_adJsonData.ad_Description == "" || ref_adJsonData.ad_Description == null)
        {
            messageForUser = $"ad_Description field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_IconUrl == string.Empty || ref_adJsonData.ad_IconUrl == "" || ref_adJsonData.ad_IconUrl == null)
        {
            messageForUser = $"ad_IconUrl field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_AppUrl == string.Empty || ref_adJsonData.ad_AppUrl == "" || ref_adJsonData.ad_AppUrl == null)
        {
            messageForUser = $"ad_AppUrl field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_maxStarRaing >= 11 || ref_adJsonData.ad_maxStarRaing <= 4)
        {
            messageForUser = $"ad_maxStarRaing is invalid.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_givenStarRaing >= (ref_adJsonData.ad_maxStarRaing + 1) || ref_adJsonData.ad_givenStarRaing <= -1)
        {
            messageForUser = $"ad_givenStarRaing is invalid.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_priceValue < 0f)
        {
            messageForUser = $"ad_priceValue is invalid.\nCheck the data entered.";
            return false;
        }
        if (ref_adJsonData.ad_priceValue > 0f)
        {
            adPriceType = AdPriceType.PAID;
            messageForUser = string.Empty;
            return true;
        }
        if (ref_adJsonData.ad_priceValue == 0)
        {
            adPriceType = AdPriceType.FREE;
            messageForUser = string.Empty;
            return true;
        }

        messageForUser = string.Empty;
        return true;
    }

    public void SaveJsonFile()
    {
        if (adTemplateJsonAsset == null)
        {
            messageForUser = "Load a Valid Json";
            return;
        }
        if (IsEditedDataValid(adJsonData))
        {
            string thePath = $"{Path.Combine(Application.dataPath, "Resources", "JSONTemplates", adTemplateJsonAsset.name)}.txt";
            string newText = JsonConvert.SerializeObject(adJsonData);

            if (File.Exists(thePath))
            {
                try
                {
                    File.WriteAllText(thePath, newText);
                    ClearData();
                    Debug.Log("Text saved to the file successfully!");
                }
                catch (IOException e)
                {
                    Debug.LogError("Error writing to the file: " + e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.LogError("Unauthorized access: " + e.Message);
                }
                catch (Exception e)
                {
                    Debug.LogError("An error occurred: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("File does not exist");
            }
        }
    }

    public void CreateUiTemplateInScene()
    {
        List<TextAsset> allTextAssets = Resources.LoadAll<TextAsset>("JSONTemplates").ToList();
        if (allTextAssets.Count >= 1)
        {
            Canvas canvasComponent = CreateCanvsParent();

        }
        else
        {
            messageForUser = $"No JSONTemplates found.\nPlease create a new JSON Template\nusing TemplateCreator.";
        }
    }

    public Canvas CreateCanvsParent()
    {
        GameObject existingCanvas = GameObject.Find("Canvas");
        if (existingCanvas == null)
        {
            //string canvasPath = $"{Path.Combine(Application.dataPath, "Resources", "Prefabs", "Canvas")}";

            GameObject templateParentCanvas = Resources.Load<GameObject>("Canvas");
            if (templateParentCanvas != null)
            {
                GameObject canvasInstance = Instantiate(templateParentCanvas);
                canvasInstance.gameObject.name = "Canvas";
                Canvas canvasComponent = canvasInstance.GetComponent<Canvas>();
                canvasComponent.worldCamera = Camera.main;
                return canvasComponent;
            }
            else
            {
                Debug.LogError("Canvas prefab not found in Resources folder.");
                return null;
            }
        }
        else
        {
            Debug.Log("Canvas Already Exists In The Scene");
            return existingCanvas.GetComponent<Canvas>();
        }
    }

    public enum AdPriceType
    {
        None,
        FREE,
        PAID
    }
}
