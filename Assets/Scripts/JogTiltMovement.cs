using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class JogTiltMovement : MonoBehaviour {

    public Transform hmd;

    public float speed;
    public float tiltRangeMin = 0.995f;
    public float tiltRangeMax = 0.825f;

    private Player player;
    private Vector3 calibratedUp = Vector3.up;

    private Vector3 desiredPos;

    private bool isJogging = true;
    private float oldY, diff;

    void Start () {
        player = GetComponent<Player>();
        desiredPos = this.transform.position;

        oldY = hmd.position.y;
        diff = 0f;

        InvokeRepeating("IncrementalUpdate", 0f, 0.1f);
	}

    public void SetJogging(bool val)
    {
        isJogging = val;

        /*if(!isJogging)
        {
            desiredPos = this.transform.position;
        }*/
    }

    private void Update()
    {
        float dot = Vector3.Dot(calibratedUp, hmd.up);

        foreach (Hand hand in player.hands)
        {
            if (hand.GetStandardSecondaryButtonDown())
            {
                calibratedUp = hmd.up;
            }
        }

        if ((dot < tiltRangeMin && dot > tiltRangeMax))
        {
            Vector3 dir = hmd.up;
            dir.y = 0;
            dir.Normalize();
            if (diff > 0.2f)
            {
                this.transform.position += dir * speed * Time.deltaTime * diff;
            }
        }
    }
}
