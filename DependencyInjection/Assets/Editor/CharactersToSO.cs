 using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CharactersToSO:MonoBehaviour {
    [MenuItem("Utility/JsonConvert/CharacterSOAsset")]
    static void ConvertToTaskAsset() {
        string text = File.ReadAllText(Application.dataPath + "/Resources/CharacterSO/CharactersJson.txt");
        var asset = JsonConvert.DeserializeObject<AllCharacters>(text);
        AssetDatabase.CreateAsset(asset,"Assets/Resources/CharacterSO/Characters.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        }

    }