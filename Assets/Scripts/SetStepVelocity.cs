using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SetStepVelocity : MonoBehaviour {

    private Slider slide;

    private bool allowUpdate = false;

    private void Start()
    {
        slide = GetComponent<Slider>();
        slide.minValue = 5f;
        slide.maxValue = 15f;

        slide.value = MenuSettings.Instance.maxMoveSpeed;
        allowUpdate = true;
    }

    public void UpdateStepVelocity()
    {
        if(allowUpdate)
            MenuSettings.Instance.maxMoveSpeed = slide.value;
    }
}
