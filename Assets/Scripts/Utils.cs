using UnityEngine;
using System.Collections;

public static class Utils
{
    public static GameObject FindObjectInChildWithTag(this GameObject parent, string tag)
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                return tr.gameObject;
            }
        }
        return null;
    }
}