using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateCustomInspector : MonoBehaviour
{
    [MenuItem("Custom Inspector/AdTemplateJsonInspector")]
    public static void Create_AdTemplateJsonInspector()
    {
        GameObject myObject = GameObject.Find("AdTemplateJsonInspector");
        if (myObject != null)
        {
            DestroyImmediate(myObject);
        }
        // Create a custom game object
        GameObject gameObject = new GameObject("AdTemplateJsonInspector");
        gameObject.AddComponent<AdTemplateJsonInspector>();
    }

    [MenuItem("Custom Inspector/TemplateCreator")]
    public static void Create_TemplateCreator()
    {
        GameObject myObject = GameObject.Find("TemplateCreator");
        if (myObject != null)
        {
            DestroyImmediate(myObject);
        }
        // Create a custom game object
        GameObject gameObject = new GameObject("TemplateCreator");
        gameObject.AddComponent<TemplateCreator>();
    }
}
