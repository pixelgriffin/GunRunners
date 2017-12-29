using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SetGripToggle : MonoBehaviour {

    private Toggle tog;

    public void Start()
    {
        tog = GetComponent<Toggle>();
        tog.isOn = MenuSettings.Instance.toggleGrip;
    }

    public void UpdateToggle()
    {
        MenuSettings.Instance.toggleGrip = tog.isOn;
    }
}
