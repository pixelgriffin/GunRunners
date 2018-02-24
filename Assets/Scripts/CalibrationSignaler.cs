using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class CalibrationSignaler : MonoBehaviour {

    public TextMesh text;

    private Player player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Hand hand in player.hands)
        {
            if (hand.controller != null)
            {
                if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    text.text = "Calibration confirmed.";

                    Calibrator.Instance.playerHeight = player.hmdTransform.position.y;

                    Invoke("SwitchScene", 1f);
                }
            } 
        }
	}

    void SwitchScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
