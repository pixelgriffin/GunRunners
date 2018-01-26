using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class RoundTimer : MonoBehaviour {

    public float minutes = 2;

    private float timeLeft = 0;
    private TextMesh textMesh;

	void Start () {
        textMesh = GetComponent<TextMesh>();

        timeLeft = minutes * 60f;
	}
	
	void Update () {
        timeLeft -= Time.deltaTime;
        
        if(timeLeft < 0)
        {
            timeLeft = 0;
            Statistics.Instance.allowDataEdit = false;
        }

        int minsLeft = ((int)timeLeft / 60);

        textMesh.text = minsLeft + ":" + (((int)timeLeft) - (minsLeft * 60));
	}
}
