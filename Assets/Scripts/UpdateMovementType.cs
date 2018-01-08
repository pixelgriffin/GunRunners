using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMovementType : MonoBehaviour {

    public enum MovementType
    {
        JOGGING,
        TRACKPAD,
        TELEPORT
    };

    public MovementType type;

    private Toggle tog;

	// Use this for initialization
	void Start () {
        tog = GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tog.isOn)
        {
            switch(type)
            {
                case MovementType.JOGGING:
                    MenuSettings.Instance.USE_JOGGING = true;
                    MenuSettings.Instance.USE_TRACKPAD = false;
                    MenuSettings.Instance.USE_TELEPORT = false;
                    break;
                case MovementType.TRACKPAD:
                    MenuSettings.Instance.USE_JOGGING = false;
                    MenuSettings.Instance.USE_TRACKPAD = true;
                    MenuSettings.Instance.USE_TELEPORT = false;
                    break;
                case MovementType.TELEPORT:
                    MenuSettings.Instance.USE_JOGGING = false;
                    MenuSettings.Instance.USE_TRACKPAD = false;
                    MenuSettings.Instance.USE_TELEPORT = true;
                    break;
            }
        }
	}
}
