#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace GGGGU
{
    public class MaplList
    {
        public string? Original { get; set; }
        public string? Save { get; set; }
        
        public string? OriImg { get; set; }
        public string? SaveImg { get; set; }
    }
    
    public class ServerAPI
    {
        private static string hostIP = ServerInfo.hostIP;
        public static string GlobalRes = "";

        public static string? getOneMap(int index)
        {
            var ml = ShowMapList();
            int i = 0;
            string? cc = null;
            foreach (var mli in ml)
            {
                if (i == index) 
                {
                    cc = mli.Save?.ToString();
                    break;
                }
                i++;
            }
            return cc;
        }
        
        public static string? getOneImg(int index)
        {
            var ml = ShowMapList();
            int i = 0;
            string? cc = null;
            foreach (var mli in ml)
            {
                if (i == index) 
                {
                    cc = mli.SaveImg?.ToString();
                    break;
                }
                i++;
            }
            return cc;
        }

        private static HttpClient SetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(hostIP);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return client;
        }
    
        public static void SetDownloadFile(string? file)
        {
            var path = "file/set/" + file;
            HttpResponseMessage res = SetClient().GetAsync(path).Result;
        }
        
        public static IEnumerable<MaplList> ShowMapList()
        {
            HttpResponseMessage res = SetClient().GetAsync("file/list").Result;
            if (res.IsSuccessStatusCode)
            {
                var maplist = res.Content.ReadAsAsync<IEnumerable<MaplList>>().Result;
                return maplist;
            }
            else
            {
                return new List<MaplList>();
            }
        }
    
        public static async Task UploadFile(string path)
        {
            HttpClient client = new HttpClient();
            var multiForm = new MultipartFormDataContent();
    
            FileStream fs = File.OpenRead(path);
            multiForm.Add(new StreamContent(fs), "file",  Path.GetFileName(path));
    
            var url = hostIP + "file/upload";
            var res = await client.PostAsync(url, multiForm);
            Thread.Sleep(100);
            GlobalRes =  res.Content.ReadAsStringAsync().Result.Split('/')[4].Split('"')[0];
        }

        public static async Task UploadImg(string path)
        {
            HttpClient client = new HttpClient();
            var multiForm = new MultipartFormDataContent();
            FileStream fs = File.OpenRead(path);
            multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(path));
            var url = hostIP + "/file/imgupload/" + GlobalRes;
            await client.PostAsync(url, multiForm);
        }
    }
}