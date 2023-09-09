using System;
using UnityEngine;

[System.Serializable]
public class AdJsonData
{
    public string ad_Headline;// { get; set; }
    public string ad_Description;// { get; set; }
    public string ad_IconUrl;// { get; set; }
    [Range(5, 10)]
    public int ad_maxStarRaing;// { get; set; }
    public int ad_givenStarRaing;// { get; set; }
    public float ad_priceValue;// { get; set; }
    public string ad_AppUrl;// { get; set; }

    public void ClearFields()
    {
        ad_Headline = string.Empty;
        ad_Description = string.Empty;
        ad_IconUrl = string.Empty;
        int defaultValue = Mathf.Clamp(ad_maxStarRaing, 5, 10);
        ad_maxStarRaing = defaultValue;
        ad_givenStarRaing = 0;
        ad_priceValue = 0;
        ad_AppUrl = string.Empty;
    }
}