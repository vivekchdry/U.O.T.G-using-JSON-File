using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class TemplateCreator : MonoBehaviour
{
    [HideInInspector] public List<TextAsset> allTextAssets;
    //Space(5)]
    [HideInInspector] public string fileNameWillBe;
    [Space(5)]
    public AdJsonData adJsonData;
    public string messageForUser { get; set; }

    public bool IsEditedDataValid()
    {
        if (adJsonData.ad_Headline == string.Empty || adJsonData.ad_Headline == "" || adJsonData.ad_Headline == null)
        {
            messageForUser = $"ad_Headline field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_Description == string.Empty || adJsonData.ad_Description == "" || adJsonData.ad_Description == null)
        {
            messageForUser = $"ad_Description field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_IconUrl == string.Empty || adJsonData.ad_IconUrl == "" || adJsonData.ad_IconUrl == null)
        {
            messageForUser = $"ad_IconUrl field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_AppUrl == string.Empty || adJsonData.ad_AppUrl == "" || adJsonData.ad_AppUrl == null)
        {
            messageForUser = $"ad_AppUrl field cannot be Empty.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_maxStarRating >= 11 || adJsonData.ad_maxStarRating <= 4)
        {
            messageForUser = $"ad_maxStarRaing is invalid.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_givenStarRating >= (adJsonData.ad_maxStarRating + 1) || adJsonData.ad_givenStarRating <= -1)
        {
            messageForUser = $"ad_givenStarRaing is invalid.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_priceValue < 0f)
        {
            messageForUser = $"ad_priceValue is invalid.\nCheck the data entered.";
            return false;
        }
        if (adJsonData.ad_priceValue > 0f)
        {
            messageForUser = string.Empty;
            return true;
        }
        if (adJsonData.ad_priceValue == 0)
        {
            messageForUser = string.Empty;
            return true;
        }

        messageForUser = string.Empty;
        return true;
    }

    // [ContextMenu("LookForExistingTemplates")]
    public void LookForExistingTemplates()
    {

        allTextAssets = Resources.LoadAll<TextAsset>("JSONTemplates").ToList();
        if (allTextAssets.Count >= 1)
        {
            fileNameWillBe = $"JsonAssets_AdTemplate {allTextAssets.Count + 1}.txt";
        }
        else
        {
            fileNameWillBe = "JsonAssets_AdTemplate 1.txt";
        }
    }

    // [ContextMenu("CreateNewJsonFileTemplate")]
    public void CreateNewJsonFileTemplate()
    {
        if (IsEditedDataValid())
        {
            LookForExistingTemplates();
            string filePath = $"{Path.Combine(Application.dataPath, "Resources", "JSONTemplates", fileNameWillBe)}";

            string newText = JsonConvert.SerializeObject(adJsonData);
            try
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(newText);
                    ClearData();
                }
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
            messageForUser = $"Incorrect data is entered.\nPlease check the entered data again.";
            Debug.LogError(messageForUser);
        }
    }
    public void ClearData()
    {
        fileNameWillBe = string.Empty;
        allTextAssets.Clear();
        this.adJsonData.ad_Headline = string.Empty;
        this.adJsonData.ad_Description = string.Empty;
        this.adJsonData.ad_IconUrl = string.Empty;
        this.adJsonData.ad_AppUrl = string.Empty;
        this.adJsonData.ad_maxStarRating = Mathf.Min(5, 10);
        this.adJsonData.ad_givenStarRating = Mathf.Abs(0);
        this.adJsonData.ad_priceValue = Mathf.Abs(0);
    }
}
