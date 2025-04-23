﻿using UnityEngine;
using System.Collections;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

public class PlayerPrefsSet : MonoBehaviour {
	
	//секретные коды, которые используются для шифровки
	static readonly string PasswordHash = "1234567890";
	static readonly string SaltKey = "1234567890";
	static readonly string VIKey = "1234567890";
	
	//Функция получения текстовой переменной из префов

	public string PlayerPrefsGetVoid(string key)
	{
		string getPrefs = Decrypt(PlayerPrefs.GetString(key));
		
		return getPrefs ;
	}
	
	
	//функция, которая овтечает за установку различных префов
	public void SetAnyPrefs(string key, string value1)
	{
		PlayerPrefs.SetString(key, Encrypt(value1));
	}
	//функция, которая шифрает переменную
	public string Encrypt(string plainText)
	{
		byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
		
		byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
		var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
		var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
		
		byte[] cipherTextBytes;
		
		using (var memoryStream = new MemoryStream())
		{
			using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
			{
				cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
				cryptoStream.FlushFinalBlock();
				cipherTextBytes = memoryStream.ToArray();
				cryptoStream.Close();
			}
			memoryStream.Close();
		}
		return Convert.ToBase64String(cipherTextBytes);
	}
	
	//функция дешифровки, такж, как и функция шифвровки 
	
	public string Decrypt(string encryptedText)
	{
		byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
		byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
		var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
		
		var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
		var memoryStream = new MemoryStream(cipherTextBytes);
		var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
		byte[] plainTextBytes = new byte[cipherTextBytes.Length];
		
		int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
		memoryStream.Close();
		cryptoStream.Close();
		return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
	}
}
