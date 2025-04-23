using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPassword : MonoBehaviour
{
    [SerializeField] private InputField textTitle;
    [SerializeField] private InputField textLogin;
    [SerializeField] private InputField textPassword;
    [SerializeField] private InputField textUrl;
    [SerializeField] private InputField textNote;
    [SerializeField] private GameObject panelOK;
    private PlayerPrefsSet playerPrefsSet;
    
    private string allPassStr;

    private void Start()
    {
        playerPrefsSet = GetComponent<PlayerPrefsSet>();
    }
    public void ButtonAddPassword()
    {
        Password newPass = new Password();
        newPass.Title = textTitle.text;
        newPass.Login = textLogin.text;
        newPass.Pass = textPassword.text;
        newPass.Url = textUrl.text;
        newPass.Note = textNote.text;
        PasswordToLine(newPass);
        textTitle.text = "";
        textLogin.text = "";
        textPassword.text = "";
        textUrl.text = "";
        textNote.text = "";
    }

    private void PasswordToLine(Password newPass)
    {
        allPassStr = playerPrefsSet.PlayerPrefsGetVoid("UserPasswords");
        
        
        if (allPassStr != "")
        {
            List<Password> allPass = JsonConvert.DeserializeObject<List<Password>>(allPassStr);
            allPass.Add(newPass);
            string newAllPass = JsonConvert.SerializeObject(allPass);
            playerPrefsSet.SetAnyPrefs("UserPasswords", newAllPass);
        }
        else
        {
            List<Password> allPass = new List<Password>() { newPass };
            string newAllPass = JsonConvert.SerializeObject(allPass);
            playerPrefsSet.SetAnyPrefs("UserPasswords", newAllPass);
        }
        panelOK.SetActive(true);
    }

}
