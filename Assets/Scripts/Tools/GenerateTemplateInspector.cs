using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateTemplateInspector : MonoBehaviour
{
    [MenuItem("Custom Inspector/AdTemplateJsonInspector")]
    public static void CreateCustomGameObject()
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
}
