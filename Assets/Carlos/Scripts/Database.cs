using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Database : MonoBehaviour
{

    public Dictionary<float, List<string>> pharsesDatabase = new Dictionary<float, List<string>>();
    private JSONObject phrasesData;

    private void Start()
    {
        phrasesData = new JSONObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Frases.json"));
        ConstructPhrasesDatabase(phrasesData);
        Debug.Log("Vamos a ver");
    }

    void ConstructPhrasesDatabase(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                float a = obj[obj.keys[0]].n;
                ExtractPhrases(a, obj["phrases"].list);
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    ConstructPhrasesDatabase(j);
                }
                break;
            case JSONObject.Type.STRING:
                //Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                //Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                //Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                //Debug.Log("NULL");
                break;
        }
    }

    void ExtractPhrases(float v, List<JSONObject> list)
    {
        List<String> toAdd = new List<string>();
        foreach (JSONObject obj in list)
            toAdd.Add(obj.str);
        pharsesDatabase.Add(v, toAdd);
    }
}
