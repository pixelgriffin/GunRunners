using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPositionSet : MonoBehaviour {

    public Transform setter;

	void Start () {
	}
	
	void Update () {
        this.transform.localPosition = new Vector3(setter.localPosition.x, this.transform.localPosition.y, setter.localPosition.z);
	}
}
