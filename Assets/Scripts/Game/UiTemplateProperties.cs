using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;
using CommonCodedTools;

public class UiTemplateProperties : MonoBehaviour
{
    [SerializeField]
    private Toggle GO_StarRating;
    [SerializeField]
    private GameObject GO_StarRatingParent;
    [SerializeField]
    private List<Toggle> allStarObjects;
    [Space(10)]
    public TextMeshProUGUI Text_adHeadline;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI Text_body;
    [Space(5)]
    public RawImage Image_adIcon;
    [Space(5)]
    public Button Button_Cta;
    [Space(5)]
    public Holder_UiTemplateProperties myAdJsonData;

    private AdPriceType adPriceType;

    private void OnButtonCtaClick(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }

    IEnumerator LoadImageFromURL(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error loading image: " + request.error);
        }
        else
        {
            Image_adIcon.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    [ContextMenu("DisplayData")]
    public void DisplayData()
    {

        Text_adHeadline.text = myAdJsonData.ad_Headline;
        if (myAdJsonData.ad_priceValue > 0f)
        {
            adPriceType = AdPriceType.PAID;
            priceTxt.text = myAdJsonData.ad_priceValue.ToString();
        }
        if (myAdJsonData.ad_priceValue == 0)
        {
            adPriceType = AdPriceType.FREE;
            priceTxt.text = "FREE";
        }
        Text_body.text = myAdJsonData.ad_Description;
        Button_Cta.onClick.AddListener(() => OnButtonCtaClick(myAdJsonData.ad_AppUrl));

        StartCoroutine(LoadImageFromURL(myAdJsonData.ad_IconUrl));


        if (myAdJsonData.ad_maxStarRating >= 6 && myAdJsonData.ad_maxStarRating <= 10)
        {
            for (int i = 0; i < (myAdJsonData.ad_maxStarRating - 5); i++)
            {
                Toggle starRating = Instantiate(GO_StarRating, GO_StarRatingParent.transform);
                allStarObjects.Add(starRating);
            }
        }
        if (allStarObjects.Count >= 1 && myAdJsonData.ad_givenStarRating >= 1 && myAdJsonData.ad_givenStarRating <= allStarObjects.Count)
        {
            for (int i = 0; i < myAdJsonData.ad_givenStarRating; i++)
            {
                allStarObjects[i].isOn = true;
            }
        }
    }

    public void TransferProperties(AdJsonData adJsonData)
    {
        myAdJsonData = new Holder_UiTemplateProperties
        {
            ad_Headline = adJsonData.ad_Headline,
            ad_Description = adJsonData.ad_Description,
            ad_IconUrl = adJsonData.ad_IconUrl,
            ad_maxStarRating = adJsonData.ad_maxStarRating,
            ad_givenStarRating = adJsonData.ad_givenStarRating,
            ad_priceValue = adJsonData.ad_priceValue,
            ad_AppUrl = adJsonData.ad_AppUrl
        };
    }

    public struct Holder_UiTemplateProperties
    {
        public string ad_Headline;// { get; set; }
        public string ad_Description;// { get; set; }
        public string ad_IconUrl;// { get; set; }
        public int ad_maxStarRating;// { get; set; }
        public int ad_givenStarRating;// { get; set; }
        public float ad_priceValue;// { get; set; }
        public string ad_AppUrl;// { get; set; }
    }
}
