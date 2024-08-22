using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDictionary();
}

public class JDataManager
{
    /* 데이터 종류별로 Dictionary 생성 */
    public Dictionary<int, JData.JBlockData> BlockDic { get; private set; } = new Dictionary<int, JData.JBlockData>();

    
    public void Init()
    {
        BlockDic = LoadJson<JData.JBlockDataLoader, int, JData.JBlockData>("BlockData").MakeDictionary();
    }

    private Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = JManagers.Resource.Load<TextAsset>(path);

        return JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }
}
