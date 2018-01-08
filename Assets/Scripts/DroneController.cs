using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStep;

public class DroneController : MonoBehaviour {

    public float health = 10f;
    public float speed = 3f;

    public Transform target;

    private float offsetY = 0;

	// Use this for initialization
	void Start () {
        target = StepDetector.instance.hmd;
        offsetY = Random.Range(0f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            if (Vector3.Distance(this.transform.position, target.position) > 1.5f)
            {
                //float oldY = this.transform.position.y;

                this.transform.position = Vector3.MoveTowards(this.transform.position, target.position + new Vector3(0, offsetY, 0), Time.deltaTime * speed);
                //this.transform.position = new Vector3(this.transform.position.x, oldY, this.transform.position.z);
            }

            this.transform.LookAt(target);
        }

        if (health <= 0f)
        {
            WaveManager.Instance.DroneDied();
            Destroy(this.gameObject);
        }
	}

    public void Damage(float dam)
    {
        health -= dam;
    }
}
