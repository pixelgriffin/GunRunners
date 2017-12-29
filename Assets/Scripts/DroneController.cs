using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

    public float health = 10f;
    public float speed = 3f;

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            if (Vector3.Distance(this.transform.position, target.position) > 1.5f)
            {
                float oldY = this.transform.position.y;

                this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, Time.deltaTime * speed);
                this.transform.position = new Vector3(this.transform.position.x, oldY, this.transform.position.z);
            }

            this.transform.LookAt(target);
        }

        if (health <= 0f)
        {
            EnemyManager.Instance.ReduceDroneCount();
            Destroy(this.gameObject);
        }
	}

    public void Damage(float dam)
    {
        health -= dam;
    }
}
