using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Player))]
public class ActivateWithButton : MonoBehaviour {

    public GameObject toActivate;

    private Player player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Hand hand in player.hands)
        {
            if(hand.GetStandardMenuButtonDown())
            {
                if (!toActivate.gameObject.activeSelf)
                {
                    toActivate.gameObject.SetActive(true);
                    toActivate.transform.position = player.transform.position + new Vector3(0f, 0f, 0f) + player.hmdTransform.forward * 2f;

                    //rotate to look at
                    toActivate.transform.rotation = Quaternion.LookRotation(toActivate.transform.position - this.transform.position);
                }
                else
                {
                    toActivate.gameObject.SetActive(false);
                }
            }
        }
	}
}
