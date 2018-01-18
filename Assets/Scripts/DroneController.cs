using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStep;

public class DroneController : MonoBehaviour {

    public float shootChargeTime = 4f;

    public float health = 10f;
    public float speed = 3f;

    public Transform target;

    private float offsetY = 0;

    private bool isShooting = false;
    private Vector3 shootTarget;
    private float shootTimer = 0f;
    private LineRenderer lr;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();

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

            //Handle shooting mechanics
            if (!isShooting)
            {
                //Handle targeting mechanics
                if (Vector3.Distance(this.transform.position, target.transform.position) < 3f)
                {
                    lr.enabled = true;
                    isShooting = true;
                    shootTarget = target.transform.position;
                }
                else
                {
                    lr.enabled = false;
                }

                moveVector -= (this.transform.position - target.position).normalized * Mathf.Min(Vector3.Distance(this.transform.position, target.position) - 2f, 7f);
                this.transform.LookAt(target);
            }
            else
            {
                shootTimer += Time.deltaTime;

                lr.SetPosition(0, this.transform.position);
                lr.SetPosition(1, shootTarget - new Vector3(0f, 1f, 0f));
                lr.startColor = new Color(255, 0, 0, (shootTimer + 1f) / shootChargeTime);
                lr.endColor = new Color(255, 0, 0, (shootTimer + 1f) / shootChargeTime);

                lr.material.color = new Color(255, 0, 0, (shootTimer + 1f) / shootChargeTime);

                if (shootTimer >= shootChargeTime)
                {
                    //Shoot
                    RaycastHit hit;
                    Physics.Raycast(this.transform.position, this.transform.forward, out hit);
                    if(hit.collider)
                    {
                        if(hit.collider.tag == "Player")
                        {
                            //Do fake damage
                            Debug.Log("Took damage");
                            GameObject.FindGameObjectWithTag("Fader").GetComponent<MaterialFader>().ResetFade();
                            GameObject.FindGameObjectWithTag("Fader").GetComponent<MaterialFader>().fadeIn = true;
                        }
                    }


                    //Reset shoot ability
                    shootTimer = 0f;
                    isShooting = false;
                }

                this.transform.LookAt(shootTarget);
            }

            this.transform.position += moveVector * Time.deltaTime;
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
