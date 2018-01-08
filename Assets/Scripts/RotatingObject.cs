using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RotatingObject : MonoBehaviour {

    private Rigidbody item;

	// Use this for initialization
	void Start () {
        item = this.transform.GetChild(0).GetComponent<Rigidbody>();

        if(item != null)
        {
            item.isKinematic = true;
        }

        Physics.IgnoreCollision(item.transform.Find("Model").GetComponent<Collider>(), this.GetComponent <Collider>());

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(this.GetComponent<Collider>(), playerObj.transform.GetChild(0).GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + 1f, this.transform.rotation.eulerAngles.z);

        if (this.transform.childCount == 0)
            Destroy(this.gameObject);
	}
}
