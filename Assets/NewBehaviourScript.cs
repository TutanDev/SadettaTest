using System.Collections;
using System.Collections.Generic;
using TutanDev.SaveSystem;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        GameData data = new GameData();
        data.Sessions = new SessionData[14];
        
        SessionData session = new SessionData();
        session.Name = "TutanDev";
        session.Score = 9999;
        data.Sessions[0] = session;

        session.Name = "AAAA";
        session.Score = 200;
        data.Sessions[1] = session;

        session.Name = "BBBB";
        session.Score = 150;
        data.Sessions[2] = session;

        session.Name = "CCCC";
        session.Score = 125;
        data.Sessions[3] = session;

        session.Name = "DDDD";
        session.Score = 100;
        data.Sessions[4] = session;

        session.Name = "EEEE";
        session.Score = 98;
        data.Sessions[5] = session;

        session.Name = "FFFF";
        session.Score = 75;
        data.Sessions[6] = session;

        session.Name = "GGGG";
        session.Score = 50;
        data.Sessions[7] = session;

        session.Name = "HHHH";
        session.Score = 40;
        data.Sessions[8] = session;

        session.Name = "IIII";
        session.Score = 30;
        data.Sessions[9] = session;

        session.Name = "JJJJ";
        session.Score = 20;
        data.Sessions[10] = session;

        session.Name = "KKKK";
        session.Score = 15;
        data.Sessions[11] = session;

        session.Name = "LLLL";
        session.Score = 10;
        data.Sessions[12] = session;

        session.Name = "MMMM";
        session.Score = 5;
        data.Sessions[13] = session;

        SaveSystem.SaveGame(data);
    }
}
