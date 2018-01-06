using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupToggle : MonoBehaviour {

    public List<Toggle> groupToggles;

    private Toggle thisToggle;
    private bool oldValue = false;

	// Use this for initialization
	void Start () {
        thisToggle = GetComponent<Toggle>();
        oldValue = thisToggle.isOn;
	}

    public void OnPickToggle()
    {
        //if this toggle was on and we tried to turn it off
        /*if(oldValue)
        {
            //leave it on
            thisToggle.isOn = true;
        }
        else//this toggle was off and turned on
        {
            foreach(Toggle tog in groupToggles)
            {
                tog.isOn = false;
                tog.GetComponent<GroupToggle>().oldValue = false;
            }
        }

        oldValue = thisToggle.isOn;//update old value*/

        if (thisToggle.isOn)
        {
            foreach (Toggle tog in groupToggles)
            {
                tog.isOn = false;
            }
        }
    }
}
