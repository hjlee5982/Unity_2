using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JManagers : MonoBehaviour
{
    private static JManagers _instance;
    private static JManagers  Instance {  get { Init(); return _instance; } }

    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
    #region Contents Managers
    private JGameManager   _game   = new JGameManager();
    private JObjectManager _object = new JObjectManager();

    public static JGameManager   Game   { get { return Instance?._game;   } } 
    public static JObjectManager Object { get { return Instance?._object; } }
    #endregion
    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�

    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
    #region Core Managers
    private JDataManager     _data     = new JDataManager();
    private JPoolManager     _pool     = new JPoolManager();
    private JResourceManager _resource = new JResourceManager();
    private JSceneManager    _scene    = new JSceneManager();
    private JSoundManager    _sound    = new JSoundManager();
    private JUIManager       _ui       = new JUIManager();

    public static JDataManager     Data     { get { return Instance?._data;     } }
    public static JPoolManager     Pool     { get { return Instance?._pool;     } }
    public static JResourceManager Resource { get { return Instance?._resource; } }
    public static JSceneManager    Scene    { get { return Instance?._scene;    } }
    public static JSoundManager    Sound    { get { return Instance?._sound;    } }
    public static JUIManager       UI       { get { return Instance?._ui;       } }
    #endregion
    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�

    public static bool Initialized { get; set; } = false;

    public static void Init()
    {
        if(_instance == null && Initialized == false)
        {
            Initialized = true;

            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<JManagers>();
            }
            
            DontDestroyOnLoad(go);

            _instance = go.GetComponent<JManagers>();
        }
    }
}
