using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Statistics : SingletonComponent<Statistics> {

    public struct SaveData
    {
        public int damageTaken;
        public int totalLeftBulletsHit;
        public int totalLeftBulletsFired;
        public int totalRightBulletsHit;
        public int totalRightBulletsFired;
        public int totalBulletsCollected;
        public int totalEnemiesDestroyed;
        public float leftAccuracy;//Calculate yourself
        public float rightAccuracy;//Calculate yourself
        public float rightTime;
        public float leftTime;
        public float forwardTime;
        public float backTime;
        public float deadZoneTime;
        public float totalTimeSpentMoving;
    };

    public SaveData data;

    public bool allowDataEdit = true;

    private void Start()
    {
        data = new SaveData();

        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveDataToReadableFile(string fname)
    {
        using (StreamWriter sw = new StreamWriter(fname))
        {
            sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            sw.WriteLine("damageTaken=" + data.damageTaken);
            sw.WriteLine("totalLeftBulletsHit=" + data.totalLeftBulletsHit);
            sw.WriteLine("totalLeftBulletsFired=" + data.totalLeftBulletsFired);
            sw.WriteLine("totalRightBulletsHit=" + data.totalRightBulletsHit);
            sw.WriteLine("totalRightBulletsFired=" + data.totalRightBulletsFired);
            sw.WriteLine("totalBulletsCollected=" + data.totalBulletsCollected);
            sw.WriteLine("totalEnemiesDestroyed=" + data.totalEnemiesDestroyed);
            sw.WriteLine("leftAccuracy=" + (float)(((float)data.totalLeftBulletsHit / (float)data.totalLeftBulletsFired) * 100f));
            sw.WriteLine("rightAccuracy=" + (float)(((float)data.totalRightBulletsHit / (float)data.totalRightBulletsFired) * 100f));
            sw.WriteLine("rightTiltTime=" + data.rightTime);
            sw.WriteLine("leftTiltTime=" + data.leftTime);
            sw.WriteLine("forwardTiltTime=" + data.forwardTime);
            sw.WriteLine("backTiltTime=" + data.backTime);
            sw.WriteLine("deadZoneTime=" + data.deadZoneTime);
            sw.WriteLine("totalTimeSpentMoving=" + data.totalTimeSpentMoving);
        }
    }
}
