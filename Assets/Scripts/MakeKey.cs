using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//Изменение значений ключей, вычисление хеша
public class MakeKey : MonoBehaviour
{
    private string secret;
    private string nameKey;
    private long counter;
    private long tmpCounter;
    private Base32decode base32Decode;
    private PlayerPrefsSet playerPrefsSet;
    private string textField;
    private DateTime currentTime;
    private long unixTime;
    private Image imgTimeCircle;
    private int timePeriod;

    public void StartOn(string period)
    {
        timePeriod = Convert.ToInt32(period);
        imgTimeCircle = gameObject.transform.GetChild(2).GetComponent<Image>();
        base32Decode = GetComponent<Base32decode>();
        playerPrefsSet = GetComponent<PlayerPrefsSet>();
        nameKey = transform.Find("Name").GetComponent<Text>().text; 
        secret = playerPrefsSet.PlayerPrefsGetVoid(nameKey);
        MakeHash();
    }

    private void Update()
    {
        currentTime = DateTime.UtcNow;
        unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
        counter = unixTime / timePeriod;
        tmpCounter = unixTime % timePeriod;
        imgTimeCircle.fillAmount = tmpCounter / (float)timePeriod;
        if (tmpCounter == 0)
        {
            MakeHash();
        }
    }
    public void MakeHash()
    {
        
        Byte[] secretBytes = base32Decode.MakeBytes(secret);
        Byte[] dataBytes = BitConverter.GetBytes(counter);
        dataBytes = ChangePlaceArray(dataBytes);
        HMACSHA1 hmac = new HMACSHA1(secretBytes);
        Byte[] calcHash = hmac.ComputeHash(dataBytes);
        

        // Use a bitwise operation to get a representative binary code from the hash
        // Refer section 5.4 at https://www.rfc-editor.org/rfc/rfc4226#page-7            
        int offset = calcHash[19] & 0xf;
        int binaryCode = (calcHash[offset] & 0x7f) << 24
            | (calcHash[offset + 1] & 0xff) << 16
            | (calcHash[offset + 2] & 0xff) << 8
            | (calcHash[offset + 3] & 0xff);

        // Generate the OTP using the binary code. As per RFC 4426 [link above] "Implementations MUST extract a 6-digit code at a minimum 
        // and possibly 7 and 8-digit code"
        int otp = binaryCode % (int)Math.Pow(10, 6); // where 6 is the password length

        textField = otp.ToString().PadLeft(6, '0');
        gameObject.transform.GetChild(0).GetComponent<Text>().text = textField;

    }

    public byte[] ChangePlaceArray(byte[] dataBytes)
    {
        int i = dataBytes.Length;
        byte[] bytesData = new byte[i];
        for (int j=0; j<i; j++)
        {
            bytesData[j] = dataBytes[i - 1 - j];
        }

        return bytesData;
    }


}
