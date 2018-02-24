using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseGame : MonoBehaviour {

    public void Unpause()
    {
        DroneController.DRONE_TIME = 1f;
    }
}
