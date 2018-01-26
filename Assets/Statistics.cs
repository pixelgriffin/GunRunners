using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Statistics : SingletonComponent<Statistics> {

    public struct SaveData
    {
        public int damageTaken;
        public int totalBulletsHit;
        public int totalBulletsFired;
        public int totalBulletsCollected;
        public int totalEnemiesDestroyed;
        public float accuracy;//Calculate yourself
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
            sw.WriteLine("totalBulletsHit=" + data.totalBulletsHit);
            sw.WriteLine("totalBulletsFired=" + data.totalBulletsFired);
            sw.WriteLine("totalBulletsCollected=" + data.totalBulletsCollected);
            sw.WriteLine("totalEnemiesDestroyed=" + data.totalEnemiesDestroyed);
            sw.WriteLine("accuracy=" + (float)(((float)data.totalBulletsHit / (float)data.totalBulletsFired) * 100f));
        }
    }
}
