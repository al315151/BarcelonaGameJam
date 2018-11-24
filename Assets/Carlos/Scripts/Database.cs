using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Database : MonoBehaviour
{

    public static Dictionary<float, List<string>> peoplePhrases;
    public static Dictionary<float, List<string>> bossPhrases;
    private JSONObject phrasesData;

    private void Start()
    {
        peoplePhrases = new Dictionary<float, List<string>>();
        bossPhrases = new Dictionary<float, List<string>>();
        phrasesData = new JSONObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Frases.json"));
        ConstructPhrasesDatabase(phrasesData, peoplePhrases);
        phrasesData = new JSONObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/BossFrases.json"));
        ConstructPhrasesDatabase(phrasesData, bossPhrases);
    }

    void ConstructPhrasesDatabase(JSONObject obj, Dictionary<float,List<string>> dicctionaryToAddPhrases)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                float a = obj[obj.keys[0]].n;
                ExtractPhrases(a, obj["phrases"].list, dicctionaryToAddPhrases);
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    ConstructPhrasesDatabase(j, dicctionaryToAddPhrases);
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

    void ExtractPhrases(float v, List<JSONObject> list, Dictionary<float, List<string>> dicctionaryToAddPhrases)
    {
        List<String> toAdd = new List<string>();
        foreach (JSONObject obj in list)
            toAdd.Add(obj.str);
        dicctionaryToAddPhrases.Add(v, toAdd);
    }
}
