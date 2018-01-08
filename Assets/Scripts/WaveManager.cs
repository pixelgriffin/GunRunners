using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : SingletonComponent<WaveManager> {


    public int CURRENT_WAVE = 0;

    public GameObject ammo;
    public GameObject flyingEnemy;

    private int unitsAlive = 0;

	void Start () {
	}

	void Update () {
		if(unitsAlive == 0)
        {
            CURRENT_WAVE++;

            unitsAlive = CURRENT_WAVE * 3;

            for(int i = 0; i < unitsAlive; i++)
            {
                Instantiate(flyingEnemy, this.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), new Quaternion());
            }

            for(int i = 0; i < CURRENT_WAVE; i++)
            {
                Instantiate(ammo, this.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), Quaternion.identity);
            }
        }


	}

    public void DroneDied()
    {
        unitsAlive--;
    }
}
