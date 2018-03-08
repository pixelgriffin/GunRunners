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
            if (hand.controller != null)
            {
                Vector2 handValue = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

                moveDirection += handValue;

                if(moveDirection.magnitude > 1f)
                {
                    moveDirection.Normalize();
                }
            }
        }

        Debug.Log(moveDirection);

        Vector3 forwardVector = player.hmdTransform.forward * (moveDirection.y * (MenuSettings.Instance.maxMoveSpeed) * Time.deltaTime);
        Vector3 sideVector = player.hmdTransform.right * (moveDirection.x * (MenuSettings.Instance.maxMoveSpeed) * Time.deltaTime);

        forwardVector.y = 0;
        sideVector.y = 0;

        this.transform.position += (forwardVector + sideVector);

        if (Statistics.Instance.allowDataEdit)
        {
            if ((forwardVector + sideVector) != Vector3.zero)
            {
                Statistics.Instance.data.totalTimeSpentMoving += Time.deltaTime;
            }
        }
	}
}
