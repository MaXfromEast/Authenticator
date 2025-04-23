using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Assets.Scripts;
using Newtonsoft.Json;

public class QRCodeScaner : MonoBehaviour
{
    [SerializeField] private RawImage rawImageBackGround; 
    [SerializeField] private AspectRatioFitter aspectRatioFitter;
    [SerializeField] private RectTransform scanZone;
    [SerializeField] private Text textField;
    private PlayerPrefsSet playerPrefsSet;
    private string stringQR;
    private ScenesManager scenesManager;






    private bool isCameraAvaible;
    private WebCamTexture camTexture;
    private string url;
    private int err; // переменная для отслеживания ошибки чтения qr кода


   
    void Start()
    {
        scenesManager = GetComponent<ScenesManager>();
        playerPrefsSet = GetComponent<PlayerPrefsSet>();
        SetUpCamera();
        err = 0;
       
    }

    void Update()
    {
        UpdateCameraRender();
        OnClickScan();
    }

    public void OnClickScan()
    {
        err = 0;
        Scan();
        if (err == 0)
        {
            //SetSecret();
            textField.text = stringQR;
        }
        
    }
    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if(devices.Length == 0)
        {
            isCameraAvaible = false;
            textField.text = isCameraAvaible.ToString();
            return;
        }
        for (int i=0; i<devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false)
            {
                camTexture = new WebCamTexture(devices[i].name, (int)scanZone.rect.width, (int)scanZone.rect.height);
            }
        }
        camTexture.Play();
        rawImageBackGround.texture = camTexture;
        isCameraAvaible = true;
    }
    private void Scan()
    {
       
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
            if(result != null)
            {
                stringQR = result.Text;
               
            }
            else
            {
                //errorField.text = "QR-код не читается";
                err = 1;
            }
        }
        catch
        {
            //errorField.text = "failed in try";
            err = 1;
        }

        
    }
    private void UpdateCameraRender()
    {
        if(isCameraAvaible == false)
        {
            return;
        }
        float ratio = camTexture.width / camTexture.height;
        aspectRatioFitter.aspectRatio = ratio;
        int orintation = -camTexture.videoRotationAngle;
        rawImageBackGround.rectTransform.localEulerAngles = new Vector3(0, 0, orintation);
    }

  





}
