using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.EventSystems;

public static class JExtension
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return JUtil.GetOrAddComponent<T>(go);
    }

    public static void BindEvent(this GameObject go, Action<PointerEventData> action = null, JDefine.EUIEvent type = JDefine.EUIEvent.Click)
    {
        JUI.BindEvent(go, action, type);
    }

    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeSelf;
    }

    //public static bool IsValid(this BaseObject bo)
    //{
    //    if (bo == null || bo.isActiveAndEnabled == false)
    //    {
    //        return false;
    //    }

    //    return true;
    //}

    public static void DestroyChilds(this GameObject go)
    {
        foreach (Transform child in go.transform)
        {
            JManagers.Resource.Destroy(child.gameObject);
        }
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]); //swap
        }
    }
}
