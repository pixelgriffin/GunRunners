using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDistanceMoved : MonoBehaviour {

    private Vector3 oldPos;

	void Start () {
        oldPos = this.transform.position;
	}
	
	void Update () {
        if(Statistics.Instance.allowDataEdit)
            Statistics.Instance.data.totalDistanceMoved = Vector3.Distance(oldPos, this.transform.position);

        oldPos = this.transform.position;
	}
}
