using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JUIManager
{
    private int _order = 10;

    private Stack<JUI_Popup> _popupStack = new Stack<JUI_Popup>();

    private JUI_Scene _sceneUI = null;
    public JUI_Scene SceneUI
    {
        set { _sceneUI = value; }
        get { return _sceneUI; }
    }

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");

            if (root == null)
            {
                root = new GameObject { name = "@UI_Root" };
            }

            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true, int sortOrder = 0)
    {
        Canvas canvas = JUtil.GetOrAddComponent<Canvas>(go);

        if (canvas == null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
        }

        CanvasScaler cs = go.GetOrAddComponent<CanvasScaler>();

        if (cs != null)
        {
            cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            cs.referenceResolution = new Vector2(1080, 1920);
        }

        go.GetOrAddComponent<GraphicRaycaster>();

        if (sort == true)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = sortOrder;
        }
    }

    public T GetSceneUI<T>() where T : JUI
    {
        return _sceneUI as T;
    }

    public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : JUI
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = JManagers.Resource.Instantiate($"{name}");

        if (parent != null)
        {
            go.transform.SetParent(parent);
        }

        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        return JUtil.GetOrAddComponent<T>(go);
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null, bool pooling = true) where T : JUI
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = JManagers.Resource.Instantiate(name, parent, pooling);
        go.transform.SetParent(parent);

        return JUtil.GetOrAddComponent<T>(go);
    }

    public T ShowBaseUI<T>(string name = null) where T : JUI
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = JManagers.Resource.Instantiate(name);
        T baseUI = JUtil.GetOrAddComponent<T>(go);

        go.transform.SetParent(Root.transform);

        return baseUI;
    }

    public T ShowSceneUI<T>(string name = null) where T : JUI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = JManagers.Resource.Instantiate(name);
        T sceneUI = JUtil.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : JUI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = JManagers.Resource.Instantiate(name);
        T popup = JUtil.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    public void ClosePopupUI(JUI_Popup popup)
    {
        if (_popupStack.Count == 0)
        {
            return;
        }

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");

            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
        {
            return;
        }

        JUI_Popup popup = _popupStack.Pop();
        JManagers.Resource.Destroy(popup.gameObject);
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }

    public int GetPopupCount()
    {
        return _popupStack.Count;
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }
}
