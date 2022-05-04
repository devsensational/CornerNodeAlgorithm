using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonMapLoader
{
    /*
    private JsonObject jo = new JsonObject();

    void jsonConfig()
    {
        var jtest = new JsonObject{width = 10, md = new List<byte>{1,1,1}};
        var json3 = JObject.FromObject(jtest);
        
        Debug.Log(json3.ToString());
    }

    void readJson()
    {
        string path = Application.dataPath + "/test.json";

        using (StreamReader file = File.OpenText(path))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject json = (JObject) JToken.ReadFrom(reader);
            jo.width = (int) json["width"];
            jo.height = (int) json["height"];

            var mData = json.SelectToken("mapDataArr");
            for (int i = 0; i < mData.Count(); i++)
            {
                jo.md.Add(byte.Parse(mData[i].ToString()));
            }
        }
        
        Debug.Log(jo.height);
        Debug.Log(jo.width);
        for(int i = 0; i<jo.md.Count(); i++)
            Debug.Log(jo.md[i]);
    }
    */
}
