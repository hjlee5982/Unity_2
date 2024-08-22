using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JInitBase : MonoBehaviour
{
    protected bool _init = false;

    public virtual bool Init()
    {
        if (_init == true)
        {
            return false;
        }

        _init = true;

        return true;
    }

    private void Awake()
    {
        Init();
    }
}
