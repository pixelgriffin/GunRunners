using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonComponent<EnemyManager> {

    public Transform center;

    public GameObject drone;

    private int droneCount = 0;
    private int droneMax = 25;

	void Start () {
		
	}

    public void ReduceDroneCount()
    {
        if(droneCount > 0)
            droneCount--;
    }
	
	// Update is called once per frame
	void Update () {
		if(droneCount < droneMax)
        {
            GameObject inst = Instantiate(drone, new Vector3(center.position.x + (Random.Range(0, 2f) > 1f ? Random.Range(10f, 25f) : Random.Range(-10f, -25f)), 2.5f, center.position.z + (Random.Range(0, 2f) > 1f ? Random.Range(10f, 25f) : Random.Range(-10f, -25f))), new Quaternion());
            inst.GetComponent<DroneController>().target = center;

            droneCount++;
        }
	}
}
