using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollision : MonoBehaviour {

    public Collider us;

	void Start () {
        Physics.IgnoreCollision(us, GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Collider>());
        this.enabled = false;
	}
}
