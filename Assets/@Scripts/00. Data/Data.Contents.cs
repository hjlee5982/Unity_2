using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JData
{
    /* 게임에서 사용 될 데이터 타입*/

    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    #region JObjectData
    [Serializable]
    public class JObjectData
    {
        public int DataID;

        /* Object가 가져야 할 데이터들 */

        // TODO
    }

    #endregion
    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ


    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
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
    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ



    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    #region SkillData

    #endregion
    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
}
