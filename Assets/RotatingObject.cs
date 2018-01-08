using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

    private Rigidbody item;

	// Use this for initialization
	void Start () {
        item = this.transform.GetChild(0).GetComponent<Rigidbody>();

        if(item != null)
        {
            item.isKinematic = true;
        }

        Physics.IgnoreCollision(this.transform.GetChild(0).GetComponent<Collider>(), this.GetComponent <Collider>());
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + 1f, this.transform.rotation.eulerAngles.z);
	}
}
