using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDistanceMoved : MonoBehaviour {

    private Vector3 oldPos, oldLocalPos;

	void Start () {
        oldPos = this.transform.position;
        oldLocalPos = this.transform.GetChild(0).localPosition;
	}
	
	void Update () {
        if (!MenuSettings.Instance.USE_TELEPORT)
        {
            if (Statistics.Instance.allowDataEdit)
                Statistics.Instance.data.totalDistanceMoved += Vector3.Distance(oldPos, this.transform.position) + Vector3.Distance(oldLocalPos, this.transform.GetChild(0).localPosition);

            oldPos = this.transform.position;
            oldLocalPos = this.transform.GetChild(0).localPosition;
        }
	}
}
