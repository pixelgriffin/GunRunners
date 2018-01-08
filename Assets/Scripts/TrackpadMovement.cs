using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TrackpadMovement : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!MenuSettings.Instance.USE_TRACKPAD)
            return;

        Vector2 moveDirection = Vector2.zero;

        foreach (Hand hand in player.hands)
        {
            if(hand.controller != null)
                moveDirection += hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
        }

        this.transform.position += player.hmdTransform.forward * (moveDirection.y * MenuSettings.Instance.maxMoveSpeed * Time.deltaTime);
        this.transform.position += player.hmdTransform.right * (moveDirection.x * MenuSettings.Instance.maxMoveSpeed * Time.deltaTime);
	}
}
