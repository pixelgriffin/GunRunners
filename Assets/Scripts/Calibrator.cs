using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrator : SingletonComponent<Calibrator>
{

    public float playerHeight = 0f;//Should be read only
    public Vector3 naturalUp = Vector3.up;



	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
}
