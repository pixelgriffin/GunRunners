using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStatistics : MonoBehaviour {

	public void Save()
    {
        string moveType = "";
        if (MenuSettings.Instance.USE_JOGGING)
        {
            moveType = "jogging";
        }
        else if (MenuSettings.Instance.USE_TELEPORT)
        {
            moveType = "teleport";
        }
        else if (MenuSettings.Instance.USE_TRACKPAD)
        {
            moveType = "trackpad";
        }
        else if(MenuSettings.Instance.USE_TILT)
        {
            moveType = "tilt";
        }

        Statistics.Instance.SaveDataToReadableFile("runData_" + (MenuSettings.Instance.IS_EXPERIMENT ? "EXPERIMENT" : "TRIAL") + "_" + moveType + ".txt");
        Statistics.Instance.data = new Statistics.SaveData();
    }
}
