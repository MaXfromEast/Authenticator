using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchPassword : MonoBehaviour
{
    private string allPassStr;
    [SerializeField] private Dropdown downTitle;
    [SerializeField] private InputField textLogin;
    [SerializeField] private InputField textPassword;
    [SerializeField] private InputField textUrl;
    [SerializeField] private InputField textNote;
    private List<Password> allPass;
    private int selectedTitle;
    private PlayerPrefsSet playerPrefsSet;
    void Start()
    {
        //downTitle.onValueChanged.AddListener(delegate
        //{
        //    DropdownValueChanged(downTitle);
        //});
        playerPrefsSet = GetComponent<PlayerPrefsSet>();
        LoadPasswords();

    }

    public void DropdownValueChanged(int sT)
    {
        selectedTitle = sT;
        ToText(selectedTitle);
        

}

public void ButtonChangePassword()
    {
        allPass[selectedTitle].Login = textLogin.text;
        allPass[selectedTitle].Pass = textPassword.text;
        allPass[selectedTitle].Url = textUrl.text;
        allPass[selectedTitle].Note = textNote.text;
        SavePassword();
    }

    public void ButtonDeletePassword()
    {   
        allPass.RemoveAt(selectedTitle);
        //ToText(0);
        
        MakeList();
        downTitle.value = -1;
        SavePassword();
    }

    private void ToText(int selectedTitle)
    {
        textLogin.text = allPass[selectedTitle].Login;
        textPassword.text = allPass[selectedTitle].Pass;
        textUrl.text = allPass[selectedTitle].Url;
        textNote.text = allPass[selectedTitle].Note;
    }

    private void MakeList()
    {
        downTitle.options.Clear();
        foreach (Password pass in allPass)
        {
            
            Dropdown.OptionData m_NewData = new Dropdown.OptionData();
            m_NewData.text = pass.Title;
            downTitle.options.Add(m_NewData);
        }
        ToText(0);
    }

    private void LoadPasswords()
    {
        allPassStr = playerPrefsSet.PlayerPrefsGetVoid("UserPasswords");

        if (allPassStr != "")
        {
            allPass = JsonConvert.DeserializeObject<List<Password>>(allPassStr);
            MakeList();
        }
    }

    private void SavePassword()
    {
        string newAllPass = JsonConvert.SerializeObject(allPass);
        playerPrefsSet.SetAnyPrefs("UserPasswords", newAllPass);
    }
}
