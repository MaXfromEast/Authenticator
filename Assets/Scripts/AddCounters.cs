using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Отображение всех имеющихся ключей

public class AddCounters : MonoBehaviour
{
    [SerializeField] private Transform contentObj;
    [SerializeField] private GameObject objectKey;
    private List<Keys> allKeys;
    private string keys;
    private void Start()
    {
        
        keys = PlayerPrefs.GetString("Keys");
        allKeys = JsonConvert.DeserializeObject<List<Keys>>(keys);
        foreach(Keys key in allKeys)
        {
            GameObject OneLineKey = Instantiate(objectKey, contentObj);
            OneLineKey.transform.Find("Name").GetComponent<Text>().text = key.NameKey;
            OneLineKey.GetComponent<MakeKey>().StartOn(key.Period);
        }
        
    }
}
