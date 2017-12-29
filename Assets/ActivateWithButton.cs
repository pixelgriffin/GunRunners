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
                toActivate.gameObject.SetActive(true);
                toActivate.transform.position = player.transform.position + new Vector3(0f, 0f, 0f);
                //rotate to look at
            }
        }
	}
}
