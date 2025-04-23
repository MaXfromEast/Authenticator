using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessingQR : MonoBehaviour
{
    [SerializeField] private Text textField;
    private PlayerPrefsSet playerPrefsSet;
    private ScenesManager scenesManager;
    

    void Start()
    {
        scenesManager = GetComponent<ScenesManager>();
        playerPrefsSet = GetComponent<PlayerPrefsSet>();
    }



    public void SetSecret()
    {
        string stringQR = textField.text;
        int secInd = stringQR.IndexOf("secret");
        int issuer = stringQR.IndexOf("issuer");
        int period = stringQR.IndexOf("period");
        string name;
        if(stringQR.Remove(0, issuer + 7).IndexOf("&")== -1)
        {
            name = stringQR.Remove(0, issuer + 7);
        }
        else
        {
            name = stringQR.Remove(0, issuer + 7).Substring(0, stringQR.Remove(0, issuer + 7).IndexOf("&"));
        }
        string qrSecretCode = stringQR.Substring(secInd + 7, 32);
        string time;
        if (period == -1)
        {
            time = "30";
        }
        else
        {
            time = stringQR.Remove(0, period + 7).Substring(0, 2);
        }
        playerPrefsSet.SetAnyPrefs(name, qrSecretCode);
        AddKeyToArray(name, time);
    }

    public void AddKeyToArray(string name, string time)
    {

        Keys newKey = new Keys();
        newKey.NameKey = name;
        newKey.Period = time;
        string keys = PlayerPrefs.GetString("Keys");
        if (keys != "")
        {
            List<Keys> allKeys = JsonConvert.DeserializeObject<List<Keys>>(keys);
            allKeys.Add(newKey);
            string newAllKeys = JsonConvert.SerializeObject(allKeys);
            PlayerPrefs.SetString("Keys", newAllKeys);
        }
        else
        {
            List<Keys> allKeys = new List<Keys>() { newKey };
            string newAllKeys = JsonConvert.SerializeObject(allKeys);

            PlayerPrefs.SetString("Keys", newAllKeys);

        }
        scenesManager.LoadSceneNo(2);
    }
}
