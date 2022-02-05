using UnityEngine;
using System.Net;
using System.IO;

public static class APIHelper
{
    public const string API_URL = "https://clemsonhackman.com/api/word?key=";
    public const string API_KEY = "NUVGODM=";

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}
