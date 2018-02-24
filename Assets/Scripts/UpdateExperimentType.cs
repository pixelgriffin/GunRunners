using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateExperimentType : MonoBehaviour {

    public bool isExperimentButton = false;

    private Toggle tog;

	// Use this for initialization
	void Start () {
        tog = GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tog.isOn)
        {
            MenuSettings.Instance.IS_EXPERIMENT = isExperimentButton;
        }
	}
}
