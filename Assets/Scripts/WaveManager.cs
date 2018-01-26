using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : SingletonComponent<WaveManager> {


    public int dropRange = 30;

    public int desiredUnits = 5;
    //public int CURRENT_WAVE = 0;

    public GameObject ammo;
    public GameObject flyingEnemy;

    private int unitsAlive = 0;

	void Start () {
	}

	void Update () {
		/*if(unitsAlive == 0)
        {
            CURRENT_WAVE++;

            unitsAlive = CURRENT_WAVE;

            for(int i = 0; i < unitsAlive; i++)
            {
                Instantiate(flyingEnemy, this.transform.position + new Vector3(Random.Range(-dropRange, dropRange), 0, Random.Range(-dropRange, dropRange)), new Quaternion());
            }

            for(int i = 0; i < CURRENT_WAVE; i++)
            {
                Instantiate(ammo, this.transform.position + new Vector3(Random.Range(-dropRange, dropRange), 0, Random.Range(-dropRange, dropRange)), Quaternion.identity);
            }
        }*/

        if(unitsAlive < desiredUnits)
        {
            Instantiate(flyingEnemy, this.transform.position + new Vector3(Random.Range(-dropRange, dropRange), 0, Random.Range(-dropRange, dropRange)), new Quaternion());

            Instantiate(ammo, this.transform.position + new Vector3(Random.Range(-dropRange, dropRange), 0, Random.Range(-dropRange, dropRange)), Quaternion.identity);
            //Instantiate(ammo, this.transform.position + new Vector3(Random.Range(-dropRange, dropRange), 0, Random.Range(-dropRange, dropRange)), Quaternion.identity);

            unitsAlive++;
        }
	}

    public void DroneDied()
    {
        unitsAlive--;
    }
}
