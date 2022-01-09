using System.IO;
using TutanDev.Core;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    const string FILENAME = "/GameData.json";
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + FILENAME);
        PlayerPrefs.SetString("GameData", json);
    }

}
