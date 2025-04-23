using System;
using UnityEngine;

public class Base32decode : MonoBehaviour
{
   //Т.к. нормального декодера для base32 я не нашел пишем руками

    /// <summary>
    /// Берем строку символов и через словарь превращаем ее в массив byte
    /// </summary>
    /// <param name="base32"></param>
    /// <returns></returns>
    public Byte[] MakeBytes(string base32)
    {
        int lengBase32 = base32.Length;
        string bytesString = null;
        for (int i = 0; i < lengBase32; i++)
        {
            bytesString = bytesString + СhoiceSymbol(base32[i].ToString());
        }
        Debug.Log(bytesString);
        int lengbytes = bytesString.Length / 8;
        Debug.Log(lengbytes);
        string secretByteString = null;
        Byte[] secretBytes = new Byte[lengbytes];
        for (int j = 0; j < lengbytes; j++)
        {
            secretByteString = bytesString.Substring(j*8, 8);
            secretBytes[j] = Convert.ToByte(secretByteString, 2);
        }
        return secretBytes;
    }

    /// <summary>
    /// Словарь для Base32 в byte
    /// </summary>
    /// <param name="symbol"></param>
    /// <returns></returns>
    public string СhoiceSymbol(string symbol)
    {
        switch (symbol)
        {
            case "A":
                return "00000";

            case "B":
                return "00001";

            case "C":
                return "00010";

            case "D":
                return "00011";

            case "E":
                return "00100";

            case "F":
                return "00101";

            case "G":
                return "00110";

            case "H":
                return "00111";

            case "I":
                return "01000";

            case "J":
                return "01001";

            case "K":
                return "01010";

            case "L":
                return "01011";

            case "M":
                return "01100";

            case "N":
                return "01101";

            case "O":
                return "01110";

            case "P":
                return "01111";

            case "Q":
                return "10000";

            case "R":
                return "10001";

            case "S":
                return "10010";

            case "T":
                return "10011";

            case "U":
                return "10100";

            case "V":
                return "10101";

            case "W":
                return "10110";

            case "X":
                return "10111";

            case "Y":
                return "11000";

            case "Z":
                return "11001";

            case "2":
                return "11010";

            case "3":
                return "11011";

            case "4":
                return "11100";

            case "5":
                return "11101";

            case "6":
                return "11110";

            case "7":
                return "11111";




            case "a":
                return "00000";

            case "b":
                return "00001";

            case "c":
                return "00010";

            case "d":
                return "00011";

            case "e":
                return "00100";

            case "f":
                return "00101";

            case "g":
                return "00110";

            case "h":
                return "00111";

            case "i":
                return "01000";

            case "j":
                return "01001";

            case "k":
                return "01010";

            case "l":
                return "01011";

            case "m":
                return "01100";

            case "n":
                return "01101";

            case "o":
                return "01110";

            case "p":
                return "01111";

            case "q":
                return "10000";

            case "r":
                return "10001";

            case "s":
                return "10010";

            case "t":
                return "10011";

            case "u":
                return "10100";

            case "v":
                return "10101";

            case "w":
                return "10110";

            case "x":
                return "10111";

            case "y":
                return "11000";

            case "z":
                return "11001";









            default:
                return "error";
        }
    }
    
   
}
