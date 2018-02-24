using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BulletShooter : MonoBehaviour {

    public Hand attachedHand;
    public TextMesh ammoText;

    public int bullets = 90;

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
        Hand hand = attachedHand;
        if(hand)
        {
            if(hand.GetStandardShootButton())
            {
                if(canShoot)
                {
                    if (bullets > 0)
                    {
                        Vector3 forward = (muzzle.forward + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)));

                        bool didHit = false;
                        RaycastHit hit;
                        if (Physics.Raycast(muzzle.position, forward, out hit, 100f))
                        {
                            //Damage
                            if (hit.collider.tag == "Enemy")
                            {
                                hit.collider.gameObject.GetComponent<DroneController>().Damage(1);

                                if (Statistics.Instance.allowDataEdit)
                                {
                                    if (hand.GuessCurrentHandType() == Hand.HandType.Left)
                                        Statistics.Instance.data.totalLeftBulletsHit++;
                                    else if (hand.GuessCurrentHandType() == Hand.HandType.Right)
                                        Statistics.Instance.data.totalRightBulletsHit++;
                                }
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

                        bullets--;
                        if (Statistics.Instance.allowDataEdit)
                        {
                            if (hand.GuessCurrentHandType() == Hand.HandType.Left)
                                Statistics.Instance.data.totalLeftBulletsFired++;
                            else if (hand.GuessCurrentHandType() == Hand.HandType.Right)
                                Statistics.Instance.data.totalRightBulletsFired++;
                        }

                        Destroy(bullet, 0.05f);

                        //if(!gunshotSound.isPlaying)
                        if (canSound)
                        {
                            canSound = false;
                            gunshotSound.Play();
                            Invoke("ResetSound", 0.05f);
                        }

                        canShoot = false;
                        Invoke("ResetShoot", fireRate);
                    }
                    else
                    {
                        if (canSound)
                        {
                            canSound = false;
                            //gunshotSound.Play();
                            Invoke("ResetSound", 0.05f);
                        }
                    }
                }
            }
        }
        else
        {
            //not attached to a hand
            //no bullets left
            if(bullets <= 0)
            {
                if(!IsInvoking("DestroyGun"))
                    Invoke("DestroyGun", 1f);
            }
        }

        if(ammoText != null)
            ammoText.text = "" + bullets;
	}

    private void DestroyGun()
    {
        Destroy(this.gameObject);
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
