using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
public class HttpMapDownloadAPI
{
    public static async Task DownloadFile()
    { 
    HttpClient client = new HttpClient();
    HttpResponseMessage res = await client.GetAsync("http://15.165.159.166:3000/file/downloads/d");
    byte[] resContent = await res.Content.ReadAsByteArrayAsync();
    System.IO.File.WriteAllBytes(@Application.dataPath + "/filename.json", resContent);
    }
    
}
