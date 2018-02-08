using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmoOnCollision : MonoBehaviour {

    public GameObject reloadSoundPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if(collision.collider.tag == "Player")
        {
            Debug.Log("added ammo");

            //collision.collider.transform.GetChild(0).GetChild(0).GetChild(0).Find("SMG").GetComponent<BulletShooter>().bullets += 20;
            //collision.collider.transform.GetChild(0).GetChild(0).GetChild(1).Find("SMG").GetComponent<BulletShooter>().bullets += 20;

            foreach(GameObject smg in GameObject.FindGameObjectsWithTag("SMG"))
            {
                smg.GetComponent<BulletShooter>().bullets += 20;
                if (Statistics.Instance.allowDataEdit)
                    Statistics.Instance.data.totalBulletsCollected += 20;
            }

            Instantiate(reloadSoundPrefab, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
