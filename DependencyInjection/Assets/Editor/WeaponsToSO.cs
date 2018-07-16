using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class WeaponsToSO:MonoBehaviour {
    [MenuItem("Utility/JsonConvert/WeaponSOAsset")]
    static void ConvertToTaskAsset() {
        string text = File.ReadAllText(Application.dataPath + "/Resources/WeaponSO/WeaponsJson.txt");
        Debug.Log(text);

        var asset = JsonConvert.DeserializeObject<AllWeapons>(text);
        Debug.Log(asset);

        AssetDatabase.CreateAsset(asset,"Assets/Resources/WeaponSO/WeaponsInfo.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        }

    }