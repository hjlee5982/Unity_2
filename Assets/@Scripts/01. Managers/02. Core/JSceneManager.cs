using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JSceneManager
{
    public JScene CurrentScene { get { return GameObject.FindObjectOfType<JScene>(); } }

    public void LoadScene(JDefine.EScene type)
    {
        //Managers.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    private string GetSceneName(JDefine.EScene type)
    {
        string name = System.Enum.GetName(typeof(JDefine.EScene), type);

        return name;
    }

    public void Clear()
    {
        //CurrentScene.Clear();
    }
}
