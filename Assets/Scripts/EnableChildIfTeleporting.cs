using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildIfTeleporting : MonoBehaviour {
	void Update () {
        this.transform.GetChild(0).gameObject.SetActive(MenuSettings.Instance.USE_TELEPORT);
	}
}
