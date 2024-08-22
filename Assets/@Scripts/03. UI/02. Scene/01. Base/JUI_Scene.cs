using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JUI_Scene : JUI
{
    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        JManagers.UI.SetCanvas(gameObject, false);

        return true;
    }
}
