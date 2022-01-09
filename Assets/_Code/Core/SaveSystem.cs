using System.Linq;
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
            PlayerPrefs.SetString("GameData", json);
        }

        public static GameData LoadGame()
        {
            string json = PlayerPrefs.GetString("GameData");
            if (string.IsNullOrEmpty(json))
            {
                GameData data = new GameData();
                data.Sessions = new SessionData[14];
                SessionData session = new SessionData();
                session.Name = "TutanDev";
                session.Score = 999;
                data.Sessions[0] = session;

                for (int i = 1; i < 14; i++)
                {
                    session.Name = "AAA";
                    session.Score = i + 2;
                    data.Sessions[i] = session;
                }

                data.Sessions = data.Sessions.OrderByDescending(x => x.Score).ToArray();

                return data;
            }
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