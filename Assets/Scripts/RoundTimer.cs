using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMesh))]
public class RoundTimer : MonoBehaviour {

    public float minutes = 2;

    private float timeLeft = 0;
    private TextMesh textMesh;

	void Start () {
        textMesh = GetComponent<TextMesh>();

        timeLeft = minutes * 60f;

        Statistics.Instance.allowDataEdit = true;
	}
	
	void Update () {
        timeLeft -= Time.deltaTime * DroneController.DRONE_TIME;
        
        if(timeLeft < 0)
        {
            timeLeft = 0;
            Statistics.Instance.allowDataEdit = false;

            /*string moveType = "";
            if(MenuSettings.Instance.USE_JOGGING)
            {
                moveType = "jogging";
            }
            else if(MenuSettings.Instance.USE_TELEPORT)
            {
                moveType = "teleport";
            }
            else if(MenuSettings.Instance.USE_TRACKPAD)
            {
                moveType = "trackpad";
            }

            Statistics.Instance.SaveDataToReadableFile("runData_" + (MenuSettings.Instance.IS_EXPERIMENT ? "EXPERIMENT" : "TRIAL") + "_" + moveType + ".txt");
            Statistics.Instance.data = new Statistics.SaveData();

            Statistics.Instance.allowDataEdit = true;*/

            SceneManager.LoadScene("Submit");
        }

        int minsLeft = ((int)timeLeft / 60);

        if ((((int)timeLeft) - (minsLeft * 60)) < 10)//seconds less than ten, add a 0 (to look nice)
            textMesh.text = minsLeft + ":0" + (((int)timeLeft) - (minsLeft * 60));
        else
            textMesh.text = minsLeft + ":" + (((int)timeLeft) - (minsLeft * 60));
	}
}
