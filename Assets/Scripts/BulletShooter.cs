﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BulletShooter : MonoBehaviour {

    public float spread = 0.025f;
    public float fireRate = 0.1f;
    public Transform muzzle;
    public Material bulletTracerMaterial;

    public AudioSource gunshotSound;


    private Throwable throwable;

    private bool canShoot = true;
    private bool canSound = true;

	void Start () {
        throwable = GetComponent<Throwable>();
	}

	void Update () {
       Hand hand = throwable.GetAttachedHand();
        if(hand)
        {
            if(hand.GetStandardShootButton())
            {
                if(canShoot)
                {
                    Vector3 forward = (muzzle.forward + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)));

                    bool didHit = false;
                    RaycastHit hit;
                    if(Physics.Raycast(muzzle.position, forward, out hit, 100f))
                    {
                        //Damage
                        if(hit.collider.tag == "Enemy")
                        {
                            hit.collider.gameObject.GetComponent<DroneController>().Damage(1);
                        }

                        didHit = true;
                    }

                    GameObject bullet = new GameObject("Bullet");
                    bullet.transform.position = muzzle.position;
                    LineRenderer lr = bullet.AddComponent<LineRenderer>();
                    lr.useWorldSpace = true;
                    lr.SetPosition(0, muzzle.position);
                    lr.SetPosition(1, didHit ? hit.point : (muzzle.position + forward * 100f));

                    lr.material = bulletTracerMaterial;

                    lr.SetWidth(0.01f, 0f);

                    Destroy(bullet, 0.05f);

                    //if(!gunshotSound.isPlaying)
                    if (canSound)
                    {
                        canSound = false;
                        gunshotSound.Play();
                        Invoke("ResetSound", 0.15f);
                    }

                    canShoot = false;
                    Invoke("ResetShoot", fireRate);
                }
            }
        }
	}

    private void ResetShoot()
    {
        canShoot = true;
    }

    private void ResetSound()
    {
        canSound = true;
    }
}
