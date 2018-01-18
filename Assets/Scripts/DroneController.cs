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
            Vector3 moveVector = Vector3.zero;

            foreach(GameObject otherDrone in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float dist = Vector3.Distance(this.transform.position, otherDrone.transform.position);

                moveVector += (this.transform.position - otherDrone.transform.position).normalized * (5f - Mathf.Min(dist, 5));
            }
            //stop from going under ground
            moveVector += (Vector3.up) * (5f - Mathf.Min(Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, 0f, this.transform.position.z)), 5f));

            moveVector -= (this.transform.position - target.position).normalized * Mathf.Min(Vector3.Distance(this.transform.position, target.position) - 2f, 7f);

            this.transform.position += moveVector * Time.deltaTime;
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
