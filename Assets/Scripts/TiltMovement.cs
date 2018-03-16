using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Player))]
public class TiltMovement : MonoBehaviour {

    public float tiltDeadzoneRadius = 0.2f;
    public float speed = 6f;

    private Player player;

	void Start () {
        player = GetComponent<Player>();
	}
	
	void Update () {
        if (MenuSettings.Instance.USE_TILT)
        {
            Vector3 dir = CalculateTilt();

            this.transform.position += dir * speed * Time.deltaTime;
            if(Statistics.Instance.allowDataEdit)
            {
                Statistics.Instance.data.totalTimeSpentMoving += Time.deltaTime;
                //Statistics.Instance.data.totalDistanceMoved += dir.magnitude * speed * Time.deltaTime;
            }
        }
	}

    private Vector3 CalculateTilt()
    {
        Vector3 dir;

        dir = player.hmdTransform.up;
        dir.y = 0;

        Vector3 headForward = player.hmdTransform.forward;
        headForward.y = 0;
        headForward.Normalize();

        if (dir.magnitude < tiltDeadzoneRadius)//tilt direction is within deadzone
        {
            if (Statistics.Instance.allowDataEdit)
                Statistics.Instance.data.deadZoneTime += Time.deltaTime;

            return Vector3.zero;//Do not move while in deadzone
        }
        dir.Normalize();

        float ang = Vector3.Dot(headForward, dir);

        // \ | /
        //__\|/__
        //  /|\
        // / | \

        if (ang <= 1f && ang > 0.5f)//45 degree angles from Y, 90 degrees total
        {
            dir = headForward;

            if (Statistics.Instance.allowDataEdit)
                Statistics.Instance.data.forwardTime += Time.deltaTime;
        }
        else if (ang <= 0.5f && ang > -0.5f)
        {
            //right/left
            Vector3 headRight = player.hmdTransform.right;
            headRight.y = 0;
            headRight.Normalize();

            float isRight = Vector3.Dot(headRight, dir);
            if (isRight > 0f)
            {
                dir = headRight;

                if (Statistics.Instance.allowDataEdit)
                    Statistics.Instance.data.rightTime += Time.deltaTime;
            }
            else
            {
                dir = -headRight;

                if (Statistics.Instance.allowDataEdit)
                    Statistics.Instance.data.leftTime += Time.deltaTime;
            }
        }
        else if (ang <= -0.5f && ang > -1f)
        {
            dir = -headForward;

            if (Statistics.Instance.allowDataEdit)
                Statistics.Instance.data.backTime += Time.deltaTime;
        }

        return dir;
    }
}
