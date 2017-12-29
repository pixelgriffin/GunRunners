using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreObjectCollision : MonoBehaviour {

    public Collider us, ignore;

	void Start () {
        Physics.IgnoreCollision(us, ignore);
        this.enabled = false;
	}
}
