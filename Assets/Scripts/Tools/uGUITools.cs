using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class uGUITools : MonoBehaviour
{
    [MenuItem("uGUI/Anchors to Corners %Q")]
    static void AnchorsToCorners()
    {
        RectTransform t = Selection.activeTransform as RectTransform;
        RectTransform pt = Selection.activeTransform.parent as RectTransform;

        if (t == null || pt == null)
            return;

        Vector2 newAnchorsMin = new Vector2(
            t.anchorMin.x + t.offsetMin.x / pt.rect.width,
            t.anchorMin.y + t.offsetMin.y / pt.rect.height
        );
        Vector2 newAnchorsMax = new Vector2(
            t.anchorMax.x + t.offsetMax.x / pt.rect.width,
            t.anchorMax.y + t.offsetMax.y / pt.rect.height
        );

        t.anchorMin = newAnchorsMin;
        t.anchorMax = newAnchorsMax;
        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    [MenuItem("uGUI/Corners to Anchors %]")]
    static void CornersToAnchors()
    {
        RectTransform t = Selection.activeTransform as RectTransform;

        if (t == null)
            return;

        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    [MenuItem("uGUI/Corners to Anchors %Space")]
    static void CreateABox()
    {
        RectTransform _parent = Selection.activeTransform as RectTransform;
        GameObject childObj =
            Instantiate(Resources.Load("clickareabox"), _parent.transform) as GameObject;
        RectTransform _mRect = childObj.transform.GetChild(0) as RectTransform;

        _mRect.anchoredPosition = _parent.position;
        _mRect.anchorMin = new Vector2(1, 0);
        _mRect.anchorMax = new Vector2(0, 1);
        _mRect.pivot = new Vector2(0.5f, 0.5f);
        _mRect.sizeDelta = _parent.rect.size;
        _mRect.transform.SetParent(_parent);

        // Transform[] tempArray = Selection.transforms;

        // foreach (Transform item in tempArray)
        // {
        //     RectTransform _parent = item.GetComponent<RectTransform>();
        //     GameObject childObj =
        //         Instantiate(Resources.Load("clickareabox"), _parent.transform) as GameObject;
        //     RectTransform _mRect = childObj.transform.GetChild(0) as RectTransform;

        //     _mRect.anchoredPosition = _parent.position;
        //     _mRect.anchorMin = new Vector2(1, 0);
        //     _mRect.anchorMax = new Vector2(0, 1);
        //     _mRect.pivot = new Vector2(0.5f, 0.5f);
        //     _mRect.sizeDelta = _parent.rect.size;
        //     _mRect.transform.SetParent(_parent);
        // }
    }
}
#endif
