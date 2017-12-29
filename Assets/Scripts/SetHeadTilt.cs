using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SetHeadTilt : MonoBehaviour {

    private Slider slide;

    private bool allowUpdate = false;

    private void Start()
    {
        slide = GetComponent<Slider>();
        slide.minValue = 0f;
        slide.maxValue = 0.09f;

        slide.value = MenuSettings.Instance.headDeadZoneMin;
        allowUpdate = true;
    }

    public void UpdateHeadTilt()
    {
        if(allowUpdate)
            MenuSettings.Instance.headDeadZoneMin = slide.value;
    }
}
