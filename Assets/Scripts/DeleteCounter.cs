using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCounter : MonoBehaviour
{
    private string nameKey;

    /// <summary>
    /// Удаляем не нужный ключ
    /// </summary>
    public void DeleteKey()
    {
        nameKey = transform.Find("Name").GetComponent<Text>().text;
        PlayerPrefs.DeleteKey(nameKey);
        string keys = PlayerPrefs.GetString("Keys");
        List<Keys> allKeys = JsonConvert.DeserializeObject<List<Keys>>(keys);
        int i = 0;
        foreach (Keys allKey in allKeys)
        {
            if(allKey.NameKey == nameKey)
            {
                break;
            }
            i++;
        }
        allKeys.Remove(allKeys[i]);
        string newAllKeys = JsonConvert.SerializeObject(allKeys);
        PlayerPrefs.SetString("Keys", newAllKeys);
        Destroy(gameObject, 0.2f);
    }
}
