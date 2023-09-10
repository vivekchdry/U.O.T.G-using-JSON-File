using System;
using UnityEngine;

[System.Serializable]
public class AdJsonData
{
    public string ad_Headline;// { get; set; }
    public string ad_Description;// { get; set; }
    public string ad_IconUrl;// { get; set; }
    public int ad_maxStarRaing;// { get; set; }
    public int ad_givenStarRaing;// { get; set; }
    public float ad_priceValue;// { get; set; }
    public string ad_AppUrl;// { get; set; }


    public void ClearFields()
    {
        ad_Headline = string.Empty;
        ad_Description = string.Empty;
        ad_IconUrl = string.Empty;
        ad_AppUrl = string.Empty;

        ad_maxStarRaing = Mathf.Min(5, 10);
        ad_givenStarRaing = Mathf.Abs(0);
        ad_priceValue = Mathf.Abs(0);
    }

}