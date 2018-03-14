using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NauseaMeterUpdate : MonoBehaviour {

    public Slider nauseaSlider;

	public void UpdateStatistic()
    {
        if(nauseaSlider != null)
            Statistics.Instance.data.nauseaMeter = nauseaSlider.value;
    }
}
