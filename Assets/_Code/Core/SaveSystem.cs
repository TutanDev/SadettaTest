using System.IO;
using UnityEngine;

namespace TutanDev.Core
{
    public static class SaveSystem
    {
        static string STORAGE = Application.dataPath;//persistentDataPath;
        const string FILENAME = "/GameData.json";

        public static void SaveGame(GameData data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(STORAGE + FILENAME, json);
        }

        public static GameData LoadGame()
        {
            string json = File.ReadAllText(STORAGE + FILENAME);
            return JsonUtility.FromJson<GameData>(json);
        }
    }

    [System.Serializable]
    public struct GameData
    {
        public SessionData[] Sessions;
    }

    [System.Serializable]
    public struct SessionData
    {
        public string Name;
        public int Score;
    }
}