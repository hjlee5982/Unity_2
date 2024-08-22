using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JData
{
    /* ���ӿ��� ��� �� ������ Ÿ��*/

    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
    #region JObjectData
    [Serializable]
    public class JObjectData
    {
        public int DataID;

        /* Object�� ������ �� �����͵� */

        // TODO
    }

    #endregion
    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�


    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
    #region JBlockData
    [Serializable]
    public class JBlockData : JObjectData {}
    [Serializable]
    public class JBlockDataLoader : ILoader<int, JBlockData>
    {
        public List<JBlockData> _block = new List<JBlockData>();

        public Dictionary<int, JBlockData> MakeDictionary()
        {
            Dictionary<int, JBlockData> dict = new Dictionary<int, JBlockData>();

            foreach(JBlockData block in _block)
            {
                dict.Add(block.DataID, block);
            }

            return dict;
        }
    }
    
    #endregion
    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�



    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
    #region SkillData

    #endregion
    // �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
}
